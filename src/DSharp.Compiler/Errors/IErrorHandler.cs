namespace DSharp.Compiler.Errors
{
    public interface IErrorHandler
    {
        void ReportError(CompilerError error);

        void ReportWarning(CompilerError error);
    }
}
