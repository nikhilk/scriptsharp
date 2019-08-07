using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// This attribute can be placed on a static class that only contains static string
    /// fields representing a set of resource strings.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [ScriptIgnore]
    public sealed class ScriptResourcesAttribute : Attribute
    {
    }
}
