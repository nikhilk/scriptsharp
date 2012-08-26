// Loader.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    [IgnoreNamespace]
    [Imported]
    [ScriptName("loader")]
    public static class Loader {

        /// <summary>
        /// Loads the specified scripts.
        /// </summary>
        /// <param name="scriptNames">The names of scripts that are required and must be loaded.</param>
        public static void LoadScripts(string[] scriptNames) {
        }

        /// <summary>
        /// Loads the specified scripts and invokes the specified callback once they have been
        /// loaded.
        /// </summary>
        /// <param name="scriptNames">The names of scripts that are required and must be loaded.</param>
        /// <param name="callback">A callback to be invoked once the scripts have been loaded.</param>
        public static void LoadScripts(string[] scriptNames, Action callback) {
        }

        /// <summary>
        /// Loads the specified scripts and invokes the specified callback once they have been
        /// loaded.
        /// </summary>
        /// <param name="scriptNames">The names of scripts that are required and must be loaded.</param>
        /// <param name="callback">A callback to be invoked once the scripts have been loaded.</param>
        /// <param name="context">The object to be passed in into the callback.</param>
        /// <typeparam name="TContext">The type of the context object.</typeparam>
        public static void LoadScripts<TContext>(string[] scriptNames, Action<TContext> callback, TContext context) {
        }

        /// <summary>
        /// Registers the specified callback to be invoked when the DOM is ready,
        /// and before any script loading has begun.
        /// </summary>
        /// <param name="callback">The callback to invoke.</param>
        [ScriptName("init")]
        public static void OnInit(Action callback) {
        }

        /// <summary>
        /// Registers a callback to be invoked once any necessary scripts
        /// have been loaded.
        /// </summary>
        /// <param name="callback">The callback to be invoked.</param>
        [ScriptName("ready")]
        public static void OnReady(Action callback) {
        }

        /// <summary>
        /// Registers information about a script.
        /// </summary>
        /// <param name="scriptInfo">The information about a script.</param>
        public static void RegisterScript(ScriptInfo scriptInfo) {
        }
    }
}
