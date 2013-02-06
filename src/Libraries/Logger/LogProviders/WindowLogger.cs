// WindowProvider.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using Logger.Core;
using Logger.Formatters;

namespace Logger.LogProviders {

    public sealed class WindowProvider : BaseLogger {
        private WindowInstance _window;

        public WindowProvider(LogLevel level, IFormatter formatter) : base(level, formatter) {
            this._window = Window.Open("", "Logger");
        }

        public override void Writer(string message) {
            this._window.Document.Body.AppendChild(Document.CreateTextNode(message));
        }
    }
}
