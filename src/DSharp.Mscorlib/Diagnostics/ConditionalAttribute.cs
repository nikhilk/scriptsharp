using System.Runtime.CompilerServices;

namespace System.Diagnostics
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    [ScriptIgnore]
    [ScriptImport]
    public sealed class ConditionalAttribute : Attribute
    {
        public ConditionalAttribute(string conditionString)
        {
            ConditionString = conditionString;
        }

        public string ConditionString { get; }
    }
}
