// DownloadError.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.Feeds {

    [IgnoreNamespace]
    [Imported]
    [NumericValues]
    public enum DownloadError {

        None = 0,

        Failed = 1,

        InvalidFeedFormat = 2,

        NormalizationFailed = 3,

        PersistenceFailed = 4,

        DownloadBlocked = 5,

        Canceled = 6,

        UnsupportedAuthentication = 7,

        BackgroundDownloadDisabled = 8,

        NotExist = 9,

        UnsupportedMSXML = 10,

        UnsupportedDTD = 11,

        SizeLimitExceeded = 12
    }
}
