// Plugin.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Microsoft
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public sealed class Plugin {

        private Plugin() {
        }

        /// <summary>
        /// A human readable description of the plugin.
        /// </summary>
        [ScriptProperty]
        public string Description {
            get {
                return null;
            }
        }

        /// <summary>
        /// The filename of the plugin file.
        /// </summary>
        [ScriptProperty]
        [ScriptName("filename")]
        public string FileName {
            get {
                return null;
            }
        }

        /// <summary>
        /// The name of the plugin.
        /// </summary>
        [ScriptProperty]
        public string Name {
            get {
                return null;
            }
        }

        /// <summary>
        /// The plugin's version number string.
        /// </summary>
        [ScriptProperty]
        public string Version {
            get {
                return null;
            }
        }
    }
}
