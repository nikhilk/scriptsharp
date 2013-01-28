// MongoWineRepository.cs
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Cellar.DataModels;
using NodeApi.MongoDB;

namespace Cellar.Services.MongoLab {

    internal sealed class MongoWineRepository : IWineRepository {

        private MongoDatabase _database;
        private MongoCollection _winesCollection;

        private MongoWineRepository(MongoDatabase database, MongoCollection winesCollection) {
            _database = database;
            _winesCollection = winesCollection;
        }

        public Task<int> CountWines() {
            Deferred<int> deferred = Deferred.Create<int>();

            _winesCollection.Count(delegate(Exception error, int count) {
                if (error == null) {
                    deferred.Resolve(count);
                    return;
                }

                deferred.Reject(error);
            });

            return deferred.Task;
        }

        public static Task<MongoWineRepository> Create(string dbHost, int dbPort, string dbName, string userName, string password) {
            Deferred<MongoWineRepository> deferred = Deferred.Create<MongoWineRepository>();

            Dictionary<string, object> serverOptions = new Dictionary<string, object>("auto_reconnect", true);
            Dictionary<string, object> dbOptions = new Dictionary<string, object>("w", "0");

            MongoServer dbServer = new MongoServer(dbHost, dbPort, serverOptions);
            MongoConnector dbConnector = new MongoConnector(dbName, dbServer, dbOptions);

            dbConnector.Open(delegate(Exception openError, MongoDatabase db) {
                db.Authenticate(userName, password, delegate(Exception authError, bool success) {
                    if (success) {
                        db.CreateCollection("wines", delegate(Exception collectionError, MongoCollection collection) {
                            if (collection != null) {
                                MongoWineRepository repository = new MongoWineRepository(db, collection);
                                deferred.Resolve(repository);
                            }
                            else {
                                deferred.Reject();
                            }
                        });
                    }
                    else {
                        deferred.Reject();
                    }
                });
            });

            return deferred.Task;
        }

        public Task InsertWines(Wine[] wines) {
            Deferred deferred = Deferred.Create();

            _winesCollection.Insert(wines, null, delegate(Exception error) {
                if (error == null) {
                    deferred.Resolve();
                    return;
                }

                deferred.Reject(error);
            });

            return deferred.Task;
        }

        public Task<Wine> LookupWine(int id) {
            Deferred<Wine> deferred = Deferred.Create<Wine>();

            Dictionary<string, object> query = new Dictionary<string, object>("_id", id);
            _winesCollection.FindOne(query,
                delegate(Exception error, object item) {
                    if (error == null) {
                        deferred.Resolve((Wine)item);
                        return;
                    }

                    deferred.Reject(error);
                });

            return deferred.Task;
        }

        public Task<Wine[]> QueryWines(int skip, int count) {
            Deferred<Wine[]> deferred = Deferred.Create<Wine[]>();

            MongoCursor cursor = _winesCollection.Find(null)
                                                 .Sort(new object[] { "_id" })
                                                 .Skip(skip).Limit(count);

            cursor.ToArray(delegate(Exception error, object[] items) {
                if (error == null) {
                    deferred.Resolve((Wine[])items);
                    return;
                }

                deferred.Reject(error);
            });

            return deferred.Task;
        }
    }
}
