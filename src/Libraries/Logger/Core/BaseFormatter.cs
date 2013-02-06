// BaseFormatter.cs
//

using System;
using System.Collections.Generic;

namespace Logger.Formatters {

    public class BaseFormatter :IFormatter{
        public string Format {
            get { return "{0}, {1}"; }
        }
         
        public Date Now {
            get {
                return Date.Now;
            }
        }
    }
}
