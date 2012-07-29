// Json.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace Photos.FlickrClient {

    [Imported]
    public sealed class PhotoSearchResponse {

        [ScriptName("photos")]
        public PhotoCollection Photos;
    }

    [Imported]
    public sealed class PhotoCollection {

        [ScriptName("photo")]
        public List<PhotoResult> Results;
    }

    [Imported]
    public sealed class PhotoResult {

        public string ID;
        public string Owner;
        public string Title;
        public string Url_sq;
        public string Url_m;
        public string Url_t;
        public string Height_m;
        public string Width_m;
        public string Height_t;
        public string Width_t;
    }
}
