// WebTestPageBuilder.cs
// Script#/Tools/Testing
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptSharp.Testing {

    public sealed class WebTestPageBuilder {

        private const string PageMarkupFormat =
@"{0}
<html>
<head>
  <title>{1}</title>
  <link rel=""stylesheet"" href=""/QUnit/QUnit.css"" type=""text/css"" />
</head>
<body>
  {2}
  <div>
    <h1 id=""qunit-header"">{1}</h1>
    <h2 id=""qunit-banner""></h2>
    <h2 id=""qunit-userAgent""></h2>
    <ol id=""qunit-tests""></ol>
    <br />
    <textarea id=""qunit-log"" rows=""10"" cols=""100""></textarea>
  </div>
  <script type=""text/javascript"" src=""/QUnit/QUnit.js""></script>
  <script type=""text/javascript"" src=""/QUnit/QUnitExt.js""></script>
{3}
</body>
</html>
";

        private const string ScriptFormat =
@"  <script type=""text/javascript"" src=""{0}""></script>";

        public static readonly string StrictDocType =
            @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">";

        public static readonly string TransitionalDocType =
            @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">";

        public static readonly string Html5DocType =
            @"<!DOCTYPE html>";

        private string _docType;
        private string _title;
        private List<string> _scripts;
        private string _content;

        public WebTestPageBuilder()
            : this("Tests", TransitionalDocType) {
        }

        public WebTestPageBuilder(string title)
            : this(title, TransitionalDocType) {
        }

        public WebTestPageBuilder(string title, string docType) {
            _title = title;
            _docType = docType;
            _content = String.Empty;
            _scripts = new List<string>();
        }

        public WebTestPageBuilder AddScript(string scriptPath) {
            _scripts.Add(scriptPath);
            return this;
        }

        public WebTestPageBuilder AddScripts(params string[] scriptPaths) {
            _scripts.AddRange(scriptPaths);
            return this;
        }

        public WebTestPageBuilder SetContent(string content) {
            _content = content;
            return this;
        }

        public string ToHtml() {
            StringBuilder scriptsBuilder = new StringBuilder();
            foreach (string s in _scripts) {
                scriptsBuilder.AppendFormat(ScriptFormat, s);
                scriptsBuilder.AppendLine();
            }

            return String.Format(PageMarkupFormat,
                                 _docType, _title, _content,
                                 scriptsBuilder.ToString());
        }
    }
}
