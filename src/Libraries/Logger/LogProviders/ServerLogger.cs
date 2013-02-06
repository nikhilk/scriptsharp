// ServerProvider.cs
//

using System;
using System.Net;
using Logger.Core;
using Logger.Formatters;

namespace Logger.LogProviders {

    public sealed class ServerProvider : BaseLogger {
        
        private readonly bool _asyncRequest = true;
        private readonly string _url = String.Empty;

        public ServerProvider(LogLevel level, IFormatter formatter, bool asyncRequest, string url) : base(level, formatter) {
            this.Formatter = formatter;
            this.Level = level;
            this._asyncRequest = asyncRequest;
            this._url = url;
        }

        public override void Writer(string message) {
            XmlHttpRequest request = new XmlHttpRequest();
            request.Open(HttpVerb.Post, _url, _asyncRequest);
            request.Send(message);
        }
    }
}
