using System.Runtime.CompilerServices;

namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    [ScriptIgnore]
    [ScriptImport]
    public sealed class SuppressMessageAttribute : Attribute
    {
        public SuppressMessageAttribute(string category, string checkId)
        {
            Category = category;
            CheckId = checkId;
        }

        public string Category { get; }

        public string CheckId { get; }

        public string Justification { get; set; }

        public string Scope { get; set; }

        public string Target { get; set; }

        public string MessageId { get; set; }
    }
}
