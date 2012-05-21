// DownloadStatus.cs
// Script#/Libraries/Windows
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.Feeds {

    [IgnoreNamespace]
    [Imported]
    [NumericValues]
    public enum DownloadStatus {

        None = 0,

        Pending = 1,

        Downloading = 2,

        Downloaded = 3,

        Failed = 4
    }
}
