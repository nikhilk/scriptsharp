// Wine.cs
//

using System;
using System.Collections.Generic;

namespace Cellar.DataModels {

    [ScriptObject]
    public sealed class Wine {

        [ScriptName("_id")]
        public int ID;
        public string Name;
        public int Year;
        public string Grapes;
        public string Country;
        public string Region;
        public string Description;
        public string Image;
    }
}
