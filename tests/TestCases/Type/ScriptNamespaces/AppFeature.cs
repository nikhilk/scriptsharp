using System;
using System.Runtime.CompilerServices;
using My.Lib;

namespace My.App {
    [ScriptNamespace("MAF")]
    public class AppFeature {
        string _name;
        Feature _feature;

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public AppFeature(string name) {
            _name = name;
            _feature = new Feature(name);            
        }
    }
}


