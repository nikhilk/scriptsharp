using System.ComponentModel;

namespace System.Runtime.CompilerServices
{
    [ScriptIgnore]
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    public sealed class InternalsVisibleToAttribute : Attribute
    {
        private string _assemblyName;
        private bool _allInternalsVisible = true;

        public InternalsVisibleToAttribute(string assemblyName)
        {
            this._assemblyName = assemblyName;
        }

        public string AssemblyName
        {
            get
            {
                return _assemblyName;
            }
        }

        public bool AllInternalsVisible
        {
            get { return _allInternalsVisible; }
            set { _allInternalsVisible = value; }
        }
    }
}
