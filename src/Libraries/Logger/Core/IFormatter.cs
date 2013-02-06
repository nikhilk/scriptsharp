// ILogFormatter.cs
// Script#/Libraries/Logger
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;

namespace Logger.Formatters {

    public interface IFormatter {
        string Format { get; }
    }
}
