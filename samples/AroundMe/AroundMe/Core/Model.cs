// Model.cs
//

using System;
using System.Html;

namespace AroundMe.Core {

    internal abstract class Model {

        public event EventHandler<PropertyChangedEventArgs> PropertyChanged;

        protected void RaisePropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
