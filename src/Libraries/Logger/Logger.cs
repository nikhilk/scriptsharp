// Logger.cs
// Script#/Libraries/Logger
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using Logger.LogProviders;

namespace Logger {

    public sealed class Logger {

        private readonly List<ILogger> _providers;

        public Logger() {
            _providers = new List<ILogger>();
        }

        public void AddProvider(ILogger provider) {
            _providers.Add(provider);
        }

        public void LogWarn(string message) {
            Log(LogLevel.Warn, message);
        }

        public void LogError(string message) {
            Log(LogLevel.Error, message);
        }

        public void LogInfo(string message) {
            Log(LogLevel.Info, message);
        }

        public void LogDebug(string message) {
            Log(LogLevel.Debug, message);
        }

        private void Log(LogLevel level, string message) {
            foreach (ILogger provider in _providers) {
                if (provider.Level >= level) {
                    provider.Writer(message);
                }
            }
        }
    }
}
