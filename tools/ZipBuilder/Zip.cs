/*
Copyright © 2005 Paul Welter. All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

1. Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
2. Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
3. The name of the author may not be used to endorse or promote products
   derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE AUTHOR "AS IS" AND ANY EXPRESS OR
IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
*/

using System;
using System.Globalization;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace MSBuild.Community.Tasks {

    /// <summary>
    /// Create a zip file with the files specified.
    /// </summary>
    /// <example>Create a zip file
    /// <code><![CDATA[
    /// <ItemGroup>
    ///     <ZipFiles Include="**\*.*" Exclude="*.zip" />
    /// </ItemGroup>
    /// <Target Name="Zip">
    ///     <Zip Files="@(ZipFiles)" 
    ///         ZipFileName="MSBuild.Community.Tasks.zip" />
    /// </Target>
    /// ]]></code>
    /// Create a zip file using a working directory.
    /// <code><![CDATA[
    /// <ItemGroup>
    ///     <RepoFiles Include="D:\svn\repo\**\*.*" />
    /// </ItemGroup>
    /// <Target Name="Zip">
    ///     <Zip Files="@(RepoFiles)" 
    ///         WorkingDirectory="D:\svn\repo" 
    ///         ZipFileName="D:\svn\repo.zip" />
    /// </Target>
    /// ]]></code>
    /// </example>
    public sealed class Zip : Task {

        private string _zipFileName;
        private int _zipLevel;
        private bool _flatten;
        private string _comment;
        private string _workingDirectory;

        private ITaskItem[] _files;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Zip"/> class.
        /// </summary>
        public Zip() {
            _zipLevel = 6;
        }

        /// <summary>
        /// Gets or sets the name of the zip file.
        /// </summary>
        /// <value>The name of the zip file.</value>
        [Required]
        public string ZipFileName {
            get {
                return _zipFileName;
            }
            set {
                _zipFileName = value;
            }
        }

        /// <summary>
        /// Gets or sets the zip level.
        /// </summary>
        /// <value>The zip level.</value>
        /// <remarks>0 - store only to 9 - means best compression</remarks>
        public int ZipLevel {
            get {
                return _zipLevel;
            }
            set {
                _zipLevel = value;
            }
        }

        /// <summary>
        /// Gets or sets the files to zip.
        /// </summary>
        /// <value>The files to zip.</value>
        [Required]
        public ITaskItem[] Files {
            get {
                return _files;
            }
            set {
                _files = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Zip"/> is flatten.
        /// </summary>
        /// <value><c>true</c> if flatten; otherwise, <c>false</c>.</value>
        /// <remarks>
        /// Flattening the zip means that all directories will be removed 
        /// and the files will be place at the root of the zip file
        /// </remarks>
        public bool Flatten {
            get {
                return _flatten;
            }
            set {
                _flatten = value;
            }
        }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>The comment.</value>
        public string Comment {
            get {
                return _comment;
            }
            set {
                _comment = value;
            }
        }

        /// <summary>
        /// Gets or sets the working directory for the zip file.
        /// </summary>
        /// <value>The working directory.</value>
        /// <remarks>
        /// The working directory is the base of the zip file.  
        /// All files will be made relative from the working directory.
        /// </remarks>
        [Required]
        public string WorkingDirectory {
            get {
                return _workingDirectory;
            }
            set {
                _workingDirectory = value;
            }
        }

        /// <summary>
        /// When overridden in a derived class, executes the task.
        /// </summary>
        /// <returns>
        /// true if the task successfully executed; otherwise, false.
        /// </returns>
        public override bool Execute() {
            return ZipFiles();
        }

        private bool ZipFiles() {
            Crc32 crc = new Crc32();
            ZipOutputStream zs = null;

            try {
                string zipFileName = Path.GetFullPath(_zipFileName);
                string outputDirectory = Path.GetDirectoryName(zipFileName);

                string baseDirectory = null;
                if (String.IsNullOrEmpty(_workingDirectory) == false) {
                    baseDirectory = Path.GetFullPath(_workingDirectory);
                }

                if (Directory.Exists(outputDirectory) == false) {
                    Directory.CreateDirectory(outputDirectory);
                }

                Log.LogMessage("Creating zip file \"{0}\".", zipFileName);

                using (zs = new ZipOutputStream(File.Create(zipFileName))) {
                    // make sure level in range
                    _zipLevel = Math.Max(0, _zipLevel);
                    _zipLevel = Math.Min(9, _zipLevel);

                    zs.SetLevel(_zipLevel);
                    if (!String.IsNullOrEmpty(_comment)) {
                        zs.SetComment(_comment);
                    }

                    byte[] buffer = new byte[32768];

                    // add files to zip
                    foreach (ITaskItem fileItem in _files) {
                        string name = Path.GetFullPath(fileItem.ItemSpec);

                        FileInfo file = new FileInfo(name);
                        if (!file.Exists) {
                            Log.LogWarning("File Not Found: {0}.", file.FullName);
                            continue;
                        }

                        // clean up name
                        if (_flatten) {
                            name = file.Name;
                        }
                        else if (!String.IsNullOrEmpty(baseDirectory) &&
                                 name.StartsWith(baseDirectory, StringComparison.OrdinalIgnoreCase)) {
                            name = name.Substring(baseDirectory.Length);
                        }
                        name = ZipEntry.CleanName(name, true);

                        ZipEntry entry = new ZipEntry(name);
                        entry.DateTime = file.LastWriteTime;
                        entry.Size = file.Length;

                        using (FileStream fs = file.OpenRead()) {
                            crc.Reset();
                            long len = fs.Length;
                            while (len > 0) {
                                int readSoFar = fs.Read(buffer, 0, buffer.Length);
                                crc.Update(buffer, 0, readSoFar);
                                len -= readSoFar;
                            }
                            entry.Crc = crc.Value;
                            zs.PutNextEntry(entry);

                            len = fs.Length;
                            fs.Seek(0, SeekOrigin.Begin);
                            while (len > 0) {
                                int readSoFar = fs.Read(buffer, 0, buffer.Length);
                                zs.Write(buffer, 0, readSoFar);
                                len -= readSoFar;
                            }
                        }
                        Log.LogMessage("  added \"{0}\".", name);
                    }
                    zs.Finish();
                }
                Log.LogMessage("Created zip file \"{0}\" successfully.", _zipFileName);
                return true;
            }
            catch (Exception exc) {
                Log.LogErrorFromException(exc);
                return false;
            }
            finally {
                if (zs != null) {
                    zs.Close();
                }
            }
        }
    }
}
