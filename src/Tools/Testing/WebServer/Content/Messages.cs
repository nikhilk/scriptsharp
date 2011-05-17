// Messages.cs
// Script#/Tools/Testing
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.IO;
using System.Text;
using System.Web;

namespace ScriptSharp.Testing.WebServer.Content {

    internal static class Messages {

        public static string VersionString = typeof(Messages).Assembly.GetName().Version.ToString();

        private const string _httpErrorFormat =
@"<html>
<head>
  <title>{0}</title>
  <style>
	body {{font-family:""Verdana"";font-weight:normal;font-size:8pt;color:black;}} 
	p {{font-family:""Verdana"";font-weight:normal;color:black;margin-top: -5px;}}
	b {{font-family:""Verdana"";font-weight:bold;color:black;margin-top: -5px;}}
	h1 {{font-family:""Verdana"";font-weight:normal;font-size:18pt;color:red;}}
	h2 {{font-family:""Verdana"";font-weight:normal;font-size:14pt;color:maroon;}}
	pre {{font-family:""Lucida Console"";font-size: 8pt;}}
	.marker {{font-weight: bold; color: black;text-decoration: none;}}
	.version {{color: gray;}}
	.error {{margin-bottom: 10px;}}
	.expandable {{text-decoration:underline; font-weight:bold; color:navy; cursor:hand;}}
  </style>
</head>
<body>
  <span><h1>Server Error in '{1}' Application.<hr width=100% size=1 color=silver></h1>
  <h2> <i>HTTP Error {2} - {3}.</i> </h2></span>
  <hr size=1 color=silver>
  <b>Version Information:</b>&nbsp;ASP.NET Web Server {4}</b>
</body>
</html>
";

        private const string _dirListingFormat =
@"<html>
<head>
  <title>Directory Listing -- {0}</title>
  <style>
	body {{font-family:""Verdana"";font-weight:normal;font-size:8pt;color:black;}}
	p {{font-family:""Verdana"";font-weight:normal;color:black;margin-top: -5px;}}
	b {{font-family:""Verdana"";font-weight:bold;color:black;margin-top: -5px;}}
	h1 {{font-family:""Verdana"";font-weight:normal;font-size:18pt;color:red;}}
	h2 {{font-family:""Verdana"";font-weight:normal;font-size:14pt;color:maroon;}}
	pre {{font-family:""Lucida Console"";font-size: 8pt;}}
	.marker {{font-weight: bold; color: black;text-decoration: none;}}
	.version {{color: gray;}}
	.error {{margin-bottom: 10px;}}
	.expandable {{text-decoration:underline; font-weight:bold; color:navy; cursor:hand;}}
  </style>
</head>
<body>
  <h2><i>Directory Listing -- {0}</i> </h2></span>
  <hr size=1 color=silver>
  <pre>
";

        private static string _dirListingTail =
@"  </pre>
  <hr width=100% size=1 color=silver>
  <b>Version Information:</b>&nbsp;ASP.NET Web Server {0}</b>
</body>
</html>
";

        private const string _dirListingParentFormat =
@"<a href=""{0}"">[To Parent Directory]</a>

";

        private const string _dirListingFileFormat =
@"{0,38:dddd, MMMM dd, yyyy hh:mm tt} {1,12:n0} <a href=""{2}"">{3}</a>
";

        private const string _dirListingDirFormat =
@"{0,38:dddd, MMMM dd, yyyy hh:mm tt}        &lt;dir&gt; <a href=""{1}/"">{2}</a>
";


        public static string FormatErrorMessageBody(int statusCode, String appName) {
            string desc = HttpWorkerRequest.GetStatusDescription(statusCode);
            return String.Format(_httpErrorFormat, desc, appName, statusCode, desc, VersionString);
        }

        public static string FormatDirectoryListing(String dirPath, String parentPath, FileSystemInfo[] elements) {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(_dirListingFormat, dirPath);

            if (parentPath != null) {
                if (!parentPath.EndsWith("/")) {
                    parentPath += "/";
                }
                sb.Append(String.Format(_dirListingParentFormat, parentPath));
            }

            if (elements != null) {
                for (int i = 0; i < elements.Length; i++) {
                    if (elements[i] is FileInfo) {
                        FileInfo fi = (FileInfo)elements[i];
                        sb.AppendFormat(_dirListingFileFormat,
                                        fi.LastWriteTime, fi.Length, fi.Name, fi.Name);
                    }
                    else if (elements[i] is DirectoryInfo) {
                        DirectoryInfo di = (DirectoryInfo)elements[i];
                        sb.AppendFormat(_dirListingDirFormat,
                                        di.LastWriteTime, di.Name, di.Name);
                    }
                }
            }

            sb.AppendFormat(_dirListingTail, VersionString);
            return sb.ToString();
        }
    }
}
