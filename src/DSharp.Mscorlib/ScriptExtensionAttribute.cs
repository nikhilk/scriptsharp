using System.Runtime.CompilerServices;

namespace System
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptExtensionAttribute : Attribute
    {
        public ScriptExtensionAttribute(string extendeeExpression)
        {
            Expression = extendeeExpression;
        }

        public string Expression { get; }
    }
}
