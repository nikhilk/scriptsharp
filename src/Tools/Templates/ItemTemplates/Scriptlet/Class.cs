// $safeitemrootname$.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace $rootnamespace$
{
    [Imported]
    public sealed class $safeitemrootname$Arguments {
    
        private $safeitemrootname$Arguments() {
            // Not meant to be instantiated in application code.
        }
        
        // TODO: Create fields corresponding to arguments passed
        //       in, into your scriptlet.
    }
    
    [GlobalMethods]
    public static partial class Scriptlets
    {
        public static void $safeitemrootname$($safeitemrootname$Arguments args) {
            // This is the entry point for your scriptlet.
            // Scriptlets are generally used in conjunction with ASP.NET MVC (Ajax.AddScriptlet)
            // where the server can emit script to invoke the scriptlet, and pass in some
            // data as an arguments object.
            // However you can directly/manually use a scriptlet as well, by using the
            // following script:
            // $safeitemrootname$({...})
        }
    }
}
