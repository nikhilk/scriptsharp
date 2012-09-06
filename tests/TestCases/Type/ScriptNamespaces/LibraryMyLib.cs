using System;

namespace My.Lib {

    public sealed class MyLib {
        private string _name;
        private Feature _feature;

        public MyLib(string name, string featureName) {
            _name = name;
            _feature = new Feature(featureName);
        }

        public string Name {
            get { return _name; }
        }
        
        public Feature Feature {
            get { return _feature; }
            set { _feature = value; }
        }
    }
}
