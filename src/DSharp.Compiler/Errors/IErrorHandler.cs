namespace DSharp.Compiler.Errors
{
    public interface IErrorHandler
    {
        void ReportError(CompilerError error);
    }
}
