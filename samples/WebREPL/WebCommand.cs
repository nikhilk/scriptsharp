// WebCommand.cs
//

using System;
using System.Collections.Generic;
using System.Serialization;
using NodeApi;
using NodeApi.IO;
using NodeApi.Network;

namespace WebREPL {

    internal sealed class WebCommand {

        private HttpVerb _verb;
        private UrlData _urlData;

        private WebRequest _webRequest;
        private WebResponse _webResponse;

        private AsyncResultCallback<object> _commandCallback;

        private WebCommand(HttpVerb verb, UrlData urlData, WebRequest webRequest, WebResponse webResponse) {
            _verb = verb;
            _urlData = urlData;

            _webRequest = webRequest;
            _webResponse = webResponse;
        }

        private HttpClientOptions BuildHttpOptions() {
            HttpClientOptions options = new HttpClientOptions();

            options.HostName = _urlData.HostName;
            if (String.IsNullOrEmpty(_urlData.Port) == false) {
                options.Port = Int32.Parse(_urlData.Port);
            }

            Dictionary<string, string> query = new Dictionary<string, string>();
            bool appendQuery = false;
            if ((_webRequest.Query != null) || (_urlData.Query != null)) {
                if (_webRequest.Query != null) {
                    foreach (KeyValuePair<string, string> param in _webRequest.Query) {
                        query[param.Key] = param.Value;
                        appendQuery = true;
                    }
                }
                if (_urlData.Query != null) {
                    foreach (KeyValuePair<string, string> param in _urlData.Query) {
                        query[param.Key] = param.Value;
                        appendQuery = true;
                    }
                }
            }

            StringBuilder pathBuilder = new StringBuilder();
            if (String.IsNullOrEmpty(_urlData.PathName) == false) {
                pathBuilder.Append(_urlData.PathName);
            }
            else {
                pathBuilder.Append("/");
            }
            if (appendQuery) {
                pathBuilder.Append("?");

                bool first = true;
                foreach (KeyValuePair<string, string> param in query) {
                    if (first == false) {
                        pathBuilder.Append("&");
                    }
                    pathBuilder.Append(param.Key);
                    pathBuilder.Append("=");
                    pathBuilder.Append(param.Value.EncodeUriComponent());
                }
            }

            options.Path = pathBuilder.ToString();

            options.Headers = new Dictionary<string, string>();
            options.Headers["Accept"] = "*/*";
            if (_webRequest.Headers != null) {
                foreach (KeyValuePair<string, string> header in _webRequest.Headers) {
                    options.Headers[header.Key] = header.Value;
                }
            }
            options.Headers["Host"] = _urlData.HostName;
            if ((String.IsNullOrEmpty(_webRequest.UserName) == false) &&
                (String.IsNullOrEmpty(_webRequest.Password) == false)) {
                    string creds = _webRequest.UserName + ':' + _webRequest.Password;
                    options.Headers["Authorization"] = "Basic " + new Buffer(creds).ToString(Encoding.Base64);
            }

            return options;
        }

        public void HandleCommand(AsyncResultCallback<object> callback) {
            _commandCallback = callback;

            HttpClientOptions options = BuildHttpOptions();
            string requestData = null;

            if ((_verb == HttpVerb.POST) || (_verb == HttpVerb.PUT)) {
                if (_webRequest.Data != null) {
                    string data;
                    if (_webRequest.Data.GetType() == typeof(string)) {
                        data = (string)_webRequest.Data;
                        if (options.Headers.ContainsKey("Content-Type") == false) {
                            options.Headers["Content-Type"] = "text/plain";
                        }
                    }
                    else {
                        data = Json.Stringify(_webRequest.Data);
                        options.Headers["Content-Type"] = "application/json";
                    }

                    Buffer requestBuffer = new Buffer(data);
                    requestData = requestBuffer.ToString(Encoding.UTF8);

                    options.Headers["Content-Length"] = requestData.Length.ToString();
                }
            }

            HttpClientRequest request;
            if (_urlData.Protocol == "http:") {
                request = Http.Request(options, HandleResponse);
            }
            else {
                request = Https.Request(options, HandleResponse);
            }

            if (requestData != null) {
                request.Write(requestData);
            }

            request.End();
        }

        private void HandleResponse(HttpClientResponse response) {
            string responseData = String.Empty;

            response.SetEncoding(Encoding.UTF8);
            response.Data += delegate(string chunk) {
                responseData += chunk;
            };
            response.End += delegate() {
                _webResponse.StatusCode = response.StatusCode;
                _webResponse.Headers = response.Headers;
                _webResponse.ResponseText = responseData;

                if (response.Headers["Content-Type"] == "application/json") {
                    _webResponse.Response = Json.Parse(responseData);
                }
                else {
                    _webResponse.Response = responseData;
                }

                _commandCallback(null, _webResponse.Response);
            };
        }

        public static WebCommand TryParseCommand(string command, WebRequest webRequest, WebResponse webResponse) {
            HttpVerb verb = HttpVerb.GET;
            string uri  = null;

            string altCommand = command.ToLowerCase();
            if (altCommand.StartsWith("get ")) {
                verb = HttpVerb.GET;
                uri = command.Substring(4);
            }
            else if (altCommand.StartsWith("post ")) {
                verb = HttpVerb.POST;
                uri = command.Substring(5);
            }
            else if (altCommand.StartsWith("put ")) {
                verb = HttpVerb.PUT;
                uri = command.Substring(4);
            }
            else if (altCommand.StartsWith("delete ")) {
                verb = HttpVerb.DELETE;
                uri = command.Substring(7);
            }
            else if (altCommand.StartsWith("head ")) {
                verb = HttpVerb.HEAD;
                uri = command.Substring(5);
            }
            else if (altCommand.StartsWith("options ")) {
                verb = HttpVerb.OPTIONS;
                uri = command.Substring(8);
            }

            if (uri != null) {
                uri = uri.Trim();

                if (String.IsNullOrEmpty(uri) == false) {
                    UrlData urlData = Url.Parse(uri, /* parseQueryString */ true);
                    if ((urlData.Protocol == "http:") ||
                        (urlData.Protocol == "https:")) {
                        return new WebCommand(verb, urlData, webRequest, webResponse);
                    }
                }
            }

            return null;
        }
    }
}
