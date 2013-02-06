// TestProvider.cs
// Script#/Libraries/Logger
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using Logger.Core;
using Logger.Formatters;

namespace Logger.LogProviders {

    public sealed class TestProvider : BaseLogger {
        
        private readonly Action<string> _callback;

        public TestProvider(LogLevel level, IFormatter formatter, Action<string> callback) : base(level, formatter){
            this.Formatter = formatter;
            this.Level = level;
            this._callback = callback;
        }

        public override void Writer(string message) {
            if (this._callback != null) {
                this._callback(message);
            }
        }
    }
}
