// Interop.cs
// Script#/Tools/VisualStudio
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ScriptSharp {

    internal static class Interop {

        public const int S_OK = 0;
        public const int E_FAIL = unchecked(-2147467259);
        public const int E_INVALIDARG = unchecked(-2147024809);
        public const int E_OUTOFMEMORY = unchecked(-2147024882);

        [
        ComImport,
        Guid("FC4801A3-2BA9-11CF-A229-00AA003D7352"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)
        ]
        internal interface IObjectWithSite {

            [PreserveSig]
            int SetSite([MarshalAs(UnmanagedType.Interface)] object pUnkSite);

            [PreserveSig]
            int GetSite([In] ref Guid riid, [Out, MarshalAs(UnmanagedType.Interface)] out IntPtr ppunkSite);
        }

        [
        ComImport,
        Guid("BED89B98-6EC9-43CB-B0A8-41D6E2D6669D"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)
        ]
        internal interface IVsGeneratorProgress {

            [PreserveSig]
            int GeneratorError(bool fWarning, int dwLevel, [MarshalAs(UnmanagedType.BStr)] string bstrError, int dwLine, int dwColumn);

            [PreserveSig]
            int Progress(int nComplete, int nTotal);
        }

        [
        ComImport,
        Guid("3634494C-492F-4F91-8009-4541234E4E99"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)
        ]
        internal interface IVsSingleFileGenerator {

            [PreserveSig]
            int GetDefaultExtension([Out, MarshalAs(UnmanagedType.BStr)] out string extension);

            [PreserveSig]
            int Generate([MarshalAs(UnmanagedType.LPWStr)] string wszInputFilePath, [MarshalAs(UnmanagedType.BStr)] string bstrInputFileContents, [MarshalAs(UnmanagedType.LPWStr)] string wszDefaultNamespace, out IntPtr pbstrOutputFileContents, out int pbstrOutputFileContentsSize, IVsGeneratorProgress pGenerateProgress);
        }
    }
}
