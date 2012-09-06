using System;
using My.Lib;

namespace My.App {

    public sealed class MyApp {

        private string _name;
        private AppFeature _appfeature;
        private MyLib _lib;

        public string Name {
            get { return _name; }            
        }

        public MyLib Lib {
            get { return _lib; }
            set { _lib = value; }
        }

        public MyApp(string name, string appFeatureName, string libName, string libFeatureName) {
            _name = name;
            _appfeature = new AppFeature(appFeatureName);
            _lib = new MyLib("lib1", libName);
            _lib.Feature = new Feature(libFeatureName);
        }
    }
}
