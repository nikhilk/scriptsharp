// BaseProvider.cs
// Script#/Libraries/Logger
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using Logger.Formatters;
using Logger.LogProviders;

namespace Logger.Core {

    public abstract class BaseLogger : ILogger {

        private Action<string> _logger;
        private LogLevel _level;
        private IFormatter _formatter;

        public LogLevel Level {
            get {
                return this._level;
            }
            set {
                this._level = value;
            }
        }

        public IFormatter Formatter { 
            get {
                return this._formatter;
            }
            set {
                this._formatter = value;
            } 
        }

        public abstract void Writer(string message);

        protected BaseLogger(LogLevel level, IFormatter formatter) {
            this.Formatter = formatter;
            this.Level = level;
            this._logger = this.Writer;
        }
    }
}
