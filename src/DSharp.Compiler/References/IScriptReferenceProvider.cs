namespace DSharp.Compiler.References
{
    public interface IScriptReferenceProvider
    {
        ScriptReference GetReference(string name, string identifier);

        void Reset();
    }
}
