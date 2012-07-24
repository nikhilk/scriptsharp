// WebTestHttpServer.cs
// Script#/Tools/Testing
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ScriptSharp.Testing.WebServer {

    internal sealed class WebTestHttpServer : HttpServer {

        private Uri _baseUri;
        private string _contentRoot;

        private Dictionary<string, Tuple<string, string>> _registeredContent;

        public WebTestHttpServer(string contentRoot) {
            _contentRoot = contentRoot;
            _baseUri = new Uri("http://localhost/", UriKind.Absolute);

            Initialize(HandleGetRequest, HandlePostRequest);

            _registeredContent =
                new Dictionary<string, Tuple<string, string>>(StringComparer.OrdinalIgnoreCase);
        }

        public event EventHandler<WebTestLogEventArgs> Log;

        private string GetContentType(string path) {
            string extension = Path.GetExtension(path).ToLowerInvariant();

            if ((String.CompareOrdinal(extension, ".htm") == 0) ||
                (String.CompareOrdinal(extension, ".html") == 0)) {
                return "text/html";
            }
            else if (String.CompareOrdinal(extension, ".js") == 0) {
                return "text/javascript";
            }
            else if (String.CompareOrdinal(extension, ".css") == 0) {
                return "text/css";
            }
            else if (String.CompareOrdinal(extension, ".png") == 0) {
                return "image/png";
            }

            return "text/plain";
        }

        private string GetResolvedPath(string urlPath) {
            Uri relativeUri = new Uri(urlPath, UriKind.Relative);
            Uri resolvedUri = new Uri(_baseUri, relativeUri);

            // Get the cleaned up path with the leading slash trimmed off
            string path = resolvedUri.LocalPath.Substring(1);

            return Path.Combine(_contentRoot, path);
        }

        private void HandleGetRequest(HttpMessage message) {
            string path = GetResolvedPath(message.Path);

            Tuple<string, string> content;
            if (_registeredContent.TryGetValue(path, out content)) {
                message.WriteContent(content.Item1, content.Item2);
            }
            else if (File.Exists(path)) {
                message.WriteFile(path, GetContentType(path));
            }
            else {
                message.WriteError(HttpStatusCode.NotFound);
            }
        }

        private void HandlePostRequest(HttpMessage message) {
            string path = message.Path;

            bool? success = null;
            if (String.CompareOrdinal(path, "/log/success") == 0) {
                success = true;
            }
            else if (String.CompareOrdinal(path, "/log/failure") == 0) {
                success = false;
            }

            if (success.HasValue) {
                if (Log != null) {
                    string log = new StreamReader(message.RequestStream).ReadToEnd();

                    WebTestLogEventArgs logEvent = new WebTestLogEventArgs(success.Value, log);
                    Log(this, logEvent);
                }
            }

            message.WriteError(HttpStatusCode.NotFound);
        }

        public void RegisterContent(string path, string data, string contentType) {
            Tuple<string, string> content = new Tuple<string, string>(data, contentType);
            _registeredContent[path] = content;
        }
    }
}
