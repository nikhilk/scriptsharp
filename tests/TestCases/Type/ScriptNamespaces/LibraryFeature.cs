using System;
using System.Runtime.CompilerServices;

namespace My.Lib {
    [ScriptNamespace("MLF")]
    public class Feature {
        string _name;

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public Feature(string name) {
            _name = name;
        }
    }
}
