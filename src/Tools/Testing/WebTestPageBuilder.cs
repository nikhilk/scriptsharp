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
@"<!DOCTYPE html>
<html>
<head>
  <title>{0}</title>
  <link rel=""stylesheet"" href=""/QUnit.css"" type=""text/css"" />
</head>
<body>
  {1}
  <div>
    <h1 id=""qunit-header"">{1}</h1>
    <h2 id=""qunit-banner""></h2>
    <h2 id=""qunit-userAgent""></h2>
    <ol id=""qunit-tests""></ol>
    <br />
    <textarea id=""qunit-log"" rows=""10"" cols=""100""></textarea>
  </div>
  <script type=""text/javascript"" src=""/QUnit.js""></script>
  <script type=""text/javascript"" src=""/QUnitExt.js""></script>
{2}
</body>
</html>
";

        private const string ScriptFormat =
@"  <script type=""text/javascript"" src=""{0}""></script>";

        private string _title;
        private List<string> _scripts;
        private string _content;

        public WebTestPageBuilder()
            : this("Tests") {
        }

        public WebTestPageBuilder(string title) {
            _title = title;
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
                                 _title, _content,
                                 scriptsBuilder.ToString());
        }
    }
}
