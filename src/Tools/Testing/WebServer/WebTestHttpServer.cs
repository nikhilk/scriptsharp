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
        private string[] _contentRoots;

        private Dictionary<string, Tuple<string, string>> _registeredContent;

        public WebTestHttpServer(string[] contentRoots) {
            _contentRoots = contentRoots;
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

        private string GetResolvedPath(string urlPath, out string cleanedUrlPath) {
            Uri relativeUri = new Uri(urlPath, UriKind.Relative);
            Uri resolvedUri = new Uri(_baseUri, relativeUri);

            // Get the cleaned up path with the leading slash trimmed off
            cleanedUrlPath = resolvedUri.LocalPath;
            return resolvedUri.LocalPath.Substring(1);
        }

        private void HandleGetRequest(HttpMessage message) {
            string urlPath;
            string path = GetResolvedPath(message.Path, out urlPath);

            Tuple<string, string> content;
            if (_registeredContent.TryGetValue(urlPath, out content)) {
                message.WriteContent(content.Item1, content.Item2);
                return;
            }

            foreach (string contentRoot in _contentRoots) {
                string possiblePath = Path.Combine(contentRoot, path);
                if (File.Exists(possiblePath)) {
                    message.WriteFile(possiblePath, GetContentType(possiblePath));
                    return;
                }
            }

            message.WriteStatus(HttpStatusCode.NotFound);
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

                message.WriteStatus(HttpStatusCode.NoContent);
                return;
            }

            message.WriteStatus(HttpStatusCode.NotFound);
        }

        public void RegisterContent(string path, string data, string contentType) {
            Tuple<string, string> content = new Tuple<string, string>(data, contentType);
            _registeredContent[path] = content;
        }
    }
}
