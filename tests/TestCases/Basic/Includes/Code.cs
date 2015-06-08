// Code.cs
//

using System;
using System.Collections;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("basic")]

#if MULTIPLE_INCLUDE
[assembly: ScriptTemplate(@"
// {name}.js
""use strict"";

(function($global) {
  {include:pre.js}
  {script}
  {include:post.js}
})(this);
")]
#else
[assembly: ScriptTemplate(@"
// {name}.js {version}
//

{include:pre.js}
{script}
")]
#endif


namespace Basic {

    public class App {
    }
}
