// DownloadError.cs
// Script#/Libraries/Windows
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
