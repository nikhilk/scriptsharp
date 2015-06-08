// CellarApplication.cs
//

using System;
using System.Diagnostics;
using System.Serialization;
using System.Threading;
using NodeApi.IO;
using NodeApi.Network;
using Cellar.Controllers;
using Cellar.DataModels;
using Cellar.Services;
using Cellar.Services.MongoLab;

namespace Cellar {

    internal sealed class CellarApplication {

        private IWineRepository _repository;

        public WinesController CreateWinesController() {
            return new WinesController(_repository);
        }

        public void Initialize(string dbUrl, Action<Exception> callback) {
            UrlData urlData = Url.Parse(dbUrl);
            string[] credentials = urlData.Auth.Split(':');

            MongoWineRepository.Create(urlData.HostName, Number.ParseInt(urlData.Port, 10),
                                       urlData.Path.Substr(1),
                                       credentials[0], credentials[1])
                .Done(delegate(MongoWineRepository repository) {
                    _repository = repository;
                    _repository.CountWines()
                        .ContinueWith(delegate(Task<int> countTask) {
                            if ((countTask.Error != null) ||
                                (countTask.Result == 0)) {
                                PopulateRepository(callback);
                            }
                            else {
                                Debug.WriteLine("Repository initialized (and already populated).");
                                callback(null);
                            }
                        });
                })
                .Fail(delegate(Exception error) {
                    callback(new Exception("Unable to create repository."));
                });
        }

        private void PopulateRepository(Action<Exception> callback) {
            Debug.WriteLine("Populating repository...");

            string data = FileSystem.ReadFileTextSync("data.json", Encoding.UTF8);
            Wine[] wines = Json.ParseData<Wine[]>(data);

            _repository.InsertWines(wines)
                .Done(delegate() {
                    Debug.WriteLine("Repository populated.");
                    callback(null);
                })
                .Fail(delegate(Exception error) {
                    callback(new Exception("Could not populate repository."));
                });
        }
    }
}
