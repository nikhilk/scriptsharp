// Model.cs
//

using System;
using System.Html;

namespace AroundMe.Core {

    internal sealed class PropertyChangedEventArgs : EventArgs {

        private string _propertyName;

        public PropertyChangedEventArgs(string propertyName) {
            _propertyName = propertyName;
        }

        public string PropertyName {
            get {
                return _propertyName;
            }
        }
    }
}
