// ExpressSettings.cs
// Script#/Libraries/Node/Express
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.ExpressJS {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptConstants(UseNames = true)]
    public enum ExpressSettings {

        [ScriptName("env")]
        Environment,

        [ScriptName("trust proxy")]
        ReverseProxy,

        [ScriptName("jsonp callback name")]
        JsonpCallbackName,

        [ScriptName("json replacer")]
        JsonReplacerCallback,

        [ScriptName("json spaces")]
        JsonSpaces,

        [ScriptName("case sensitive routing")]
        CaseSensitiveRouting,

        [ScriptName("strict routing")]
        StrictRouting,

        [ScriptName("view cache")]
        ViewCaching,

        [ScriptName("view engine")]
        ViewEngine,

        [ScriptName("views")]
        ViewsPath
    }
}
