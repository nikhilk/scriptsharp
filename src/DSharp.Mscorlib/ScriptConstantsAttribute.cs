using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// This attribute is used to mark an enum as a set of constant values, i.e. if
    /// specified, the enum does not exist/is not generated, but rather its values
    /// are inlined as constants. If the UseName property is set to true, then instead
    /// of actual values, the names of the fields are used as string constants.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptConstantsAttribute : Attribute
    {
        public bool UseNames { get; set; }
    }
}
