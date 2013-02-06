// DefaultProvider.cs
// Script#/Libraries/Logger
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using Logger.Core;
using Logger.Formatters;

namespace Logger.LogProviders {

    public sealed class ConsoleLogger : BaseLogger {

        public ConsoleLogger(LogLevel level, IFormatter formatter) : base(level, formatter) {
        }

        public override void Writer(string message) {
            Debug.WriteLine(message);
        }
    }
}
