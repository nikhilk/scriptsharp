// WinesController.cs
//

using System;
using System.Collections.Generic;
using System.Threading;
using Cellar.DataModels;
using Cellar.Services;
using NodeApi.ExpressJS;
using NodeApi.Network;

namespace Cellar.Controllers {

    public sealed class WinesController {

        private IWineRepository _repository;

        public WinesController(IWineRepository repository) {
            _repository = repository;
        }

        public void LookupWine(ExpressServerRequest request, ExpressServerResponse response) {
            int id = Number.ParseInt(request.Parameters["id"], 10);
            if (Number.IsNaN(id)) {
                response.Send(HttpStatusCode.BadRequest);
                return;
            }

            _repository.LookupWine(id)
                .Done(delegate(Wine wine) {
                    response.SetType("json");
                    response.SendJson(wine);
                })
                .Fail(delegate(Exception error) {
                    response.Send(HttpStatusCode.NotFound);
                });
        }

        public void QueryWines(ExpressServerRequest request, ExpressServerResponse response) {
            int skip = 0;
            int count = 8;

            if (request.Query.ContainsKey("skip")) {
                skip = Number.ParseInt(request.Query["skip"], 10);
            }
            if (request.Query.ContainsKey("count")) {
                count = Number.ParseInt(request.Query["count"], 10);
            }

            if (Number.IsNaN(skip) || Number.IsNaN(count)) {
                response.Send(HttpStatusCode.BadRequest);
                return;
            }

            Dictionary<string, object> data = new Dictionary<string, object>();
            Task dataTask = _repository.QueryWines(skip, count)
                .Done(delegate(Wine[] wines) {
                    data["wines"] = wines;
                });

            if (skip == 0) {
                dataTask = Task.All(dataTask,
                    _repository.CountWines().Done(delegate(int totalCount) {
                        data["count"] = totalCount;
                    }));
            }

            dataTask.Done(delegate() {
                response.SetType("json");
                response.SendJson(data);
            })
            .Fail(delegate(Exception error) {
                response.Send(HttpStatusCode.InternalServerError);
            });
        }
    }
}
