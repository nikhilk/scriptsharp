// WebRequest.cs
//

using System;
using System.Collections.Generic;

namespace WebREPL {

    [ScriptObject]
    internal sealed class WebRequest {

        public Dictionary<string, string> Query;
        public Dictionary<string, string> Headers;
        public object Data;
        public string UserName;
        public string Password;

        public WebRequest() {
            Query = new Dictionary<string, string>();
            Headers = new Dictionary<string, string>();
            Data = null;
            UserName = null;
            Password = null;
        }
    }
}
