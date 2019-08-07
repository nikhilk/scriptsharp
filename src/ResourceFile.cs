// ResourceFile.cs
// Script#/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.IO;

namespace DSharp
{
    internal static class ResourceFile
    {
        public static string GetLocale(string fileName)
        {
            string extension = Path.GetExtension(fileName);

            if (string.Compare(extension, ".resx", StringComparison.OrdinalIgnoreCase) == 0)
            {
                fileName = Path.GetFileNameWithoutExtension(fileName);

                extension = Path.GetExtension(fileName);
                if (string.IsNullOrEmpty(extension) == false)
                {
                    return extension.Substring(1);
                }
            }

            return string.Empty;
        }
    }
}
