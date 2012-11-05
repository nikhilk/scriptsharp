// ScriptInfo.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp {

    public sealed class ScriptInfo {

        private static readonly string DefaultScriptTemplate = @"
""use strict"";

define('{name}', [{requires}], function({dependencies}) {
  var $global = this;

  {script}
  return $exports;
});
";

        public ScriptInfo() {
            Template = DefaultScriptTemplate;
        }

        public string Copyright {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public string Template {
            get;
            set;
        }

        public string Version {
            get;
            set;
        }
    }
}
