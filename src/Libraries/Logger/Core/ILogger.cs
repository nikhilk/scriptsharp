// ILogger.cs
// Script#/Libraries/Logger
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using Logger.Formatters;

namespace Logger.LogProviders {

    public interface ILogger {

        LogLevel Level {
            get; set; 
        }

        IFormatter Formatter {
            get;
            set;
        }

        void Writer(string message);
    }
}