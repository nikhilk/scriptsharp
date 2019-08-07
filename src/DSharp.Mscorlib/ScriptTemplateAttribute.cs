using System.Runtime.CompilerServices;

namespace System
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptTemplateAttribute : Attribute
    {
        public ScriptTemplateAttribute(string template)
        {
            Template = template;
        }

        public string Template { get; }
    }
}
