// RestifyStringClient.cs
// Script#/Libraries/Node/Restify
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace NodeApi.Restify {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public class RestifyStringClient {

        protected RestifyStringClient() {
        }

        public void BasicAuth(string login, string password) {
        }

         /// <summary>
        /// del doesn't take content, since you know, it should't:
        /// </summary>
        public void Del(string path, object content, RestifyCallback callback) {
        }
        
        /// <summary>
        /// Performs an HTTP get; if no payload was returned, obj defaults to {} for you (so you don't get a bunch of null pointer errors).
        /// </summary>
        /// <param name="path"></param>
        /// <param name="callback"></param>
        public void Get(string path, RestifyCallback callback) {
        }

        /// <summary>
        /// Just like get, but without obj:
        /// </summary>
        /// <param name="path"></param>
        /// <param name="callback"></param>
        public void Head(string path, RestifyCallback callback) {
        }

        /// <summary>
        /// Takes a complete object to serialize and send to the server.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <param name="callback"></param>
        public void Post(string path, object content, RestifyCallback callback) {
        }

        /// <summary>
        /// Just like post:
        /// </summary>
        public void Put(string path, object content, RestifyCallback callback) {
        }
    }
}
