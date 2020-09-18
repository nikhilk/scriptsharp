namespace DSharp.Compiler.Errors
{
    public enum CompilerErrorCode : ushort
    {
        AssemblyError = 0,
        AssemblyLoadError = 1,
        DuplicateAssemblyReferenceError = 2,
        ExpressionError = 3,
        FileLexerError = 4,
        GeneralError = 5,
        InputFileError = 6,
        MissingReferenceError = 7,
        MissingStreamError = 8,
        NodeValidationError = 9,
        UnsupportedFeatureError = 10,
        UnsupportedFrameworkError = 11,
        LowererError = 12,
    }
}
