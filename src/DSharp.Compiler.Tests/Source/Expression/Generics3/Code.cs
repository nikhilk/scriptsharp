using System.Collections.Generic;

[assembly: ScriptAssembly("test")]

namespace DSharp.Compiler.Tests.Source.Expression.Generics3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IReadonlyProperties props = new ReadonlyProperties();
            Dictionary<string, string> dict = props["someDictionary"] as Dictionary<string, string>;
        }
    }

    public interface IReadonlyProperties
    {
        object this[string key] { get; }
    }

    public class ReadonlyProperties : IReadonlyProperties
    {
        public object this[string key]
        {
            get { return null; }
        }
    }
}
