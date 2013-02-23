// WebResponse.cs
//

using System;
using System.Collections.Generic;
using NodeApi.Network;

namespace WebREPL {

    [ScriptObject]
    internal sealed class WebResponse {

        public Dictionary<string, string> Headers;
        public HttpStatusCode StatusCode;
        public string ResponseText;
        public object Response;
    }
}
