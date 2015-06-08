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

        public Wine(int id, string name, int year, string grapes, string country, string region, string description, string image) {
            ID = id;
            Name = name;
            Year = year;
            Grapes = grapes;
            Country = country;
            Region = region;
            Description = description;
            Image = image;
        }
    }
}
