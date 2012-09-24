// Json.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace Flickr.FlickrClient {

    [ScriptImport]
    public sealed class PhotoSearchResponse {

        [ScriptName("photos")]
        public PhotoCollection Photos;
    }

    [ScriptImport]
    public sealed class PhotoCollection {

        [ScriptName("photo")]
        public List<PhotoResult> Results;
    }

    [ScriptImport]
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
