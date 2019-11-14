using System.Collections.Concurrent;

namespace DSharp.Compiler.References
{
    public class ScriptReferenceProvider : IScriptReferenceProvider
    {
        private static readonly ScriptReferenceProvider instance;
        private readonly ConcurrentDictionary<string, ScriptReference> references;

        public static IScriptReferenceProvider Instance
        {
            get { return instance; }
        }

        static ScriptReferenceProvider()
        {
            instance = new ScriptReferenceProvider();
        }

        public ScriptReferenceProvider()
        {
            references = new ConcurrentDictionary<string, ScriptReference>();
        }

        public ScriptReference GetReference(string name, string identifier)
        {
            string referenceKey = identifier ?? name;
            ScriptReference reference = references.GetOrAdd(referenceKey, (key) => new ScriptReference(name, identifier));
            return reference;
        }

        public void Reset()
        {
            references.Clear();
        }
    }
}
