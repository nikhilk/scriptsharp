using System.Runtime.CompilerServices;

namespace System.Html
{
    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public sealed class Plugin
    {
        /// <summary>
        /// A human readable description of the plugin.
        /// </summary>
        [IntrinsicProperty]
        public string Description
        {
            get {
                return null;
            }
        }

        /// <summary>
        /// The filename of the plugin file.
        /// </summary>
        [IntrinsicProperty]
        [ScriptName("filename")]
        public string FileName
        {
            get {
                return null;
            }
        }

        /// <summary>
        /// The name of the plugin.
        /// </summary>
        [IntrinsicProperty]
        public string Name
        {
            get {
                return null;
            }
        }

        /// <summary>
        /// The plugin's version number string.
        /// </summary>
        [IntrinsicProperty]
        public string Version
        {
            get {
                return null;
            }
        }
    }
}
