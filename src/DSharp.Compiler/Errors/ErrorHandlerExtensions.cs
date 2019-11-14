using System;
using DSharp.Compiler.CodeModel;
using DSharp.Compiler.Parser;

namespace DSharp.Compiler.Errors
{
    internal static class ErrorHandlerExtensions
    {
        public static void ReportNodeValidationError(this IErrorHandler errorHandler, string message, ParseNode parseNode)
        {
            string location = parseNode?.Token?.SourcePath;
            CompilerError error = new CompilerError((ushort)CompilerErrorCode.NodeValidationError, message, location, parseNode?.Token?.Position.Line + 1, parseNode?.Token?.Position.Column + 1);
            errorHandler.ReportError(error);
        }

        public static void ReportGeneralError(this IErrorHandler errorHandler, Exception exception)
        {
            CompilerError error = new CompilerError(
                (ushort)CompilerErrorCode.GeneralError,
                exception.Message + Environment.NewLine + exception.StackTrace,
                exception.TargetSite.Name);
            errorHandler.ReportError(error);
        }

        public static void ReportGeneralError(this IErrorHandler errorHandler, string message)
        {
            CompilerError error = new CompilerError((ushort)CompilerErrorCode.GeneralError, message);
            errorHandler.ReportError(error);
        }

        public static void ReportInputError(this IErrorHandler errorHandler, string filePath)
        {
            string message = $"Unable to load file {filePath}";
            CompilerError error = new CompilerError((ushort)CompilerErrorCode.InputFileError, message, filePath);
            errorHandler.ReportError(error);
        }

        public static void ReportFileLexerError(this IErrorHandler errorHandler, string filePath, FileLexerErrorEventArgs fileLexerErrorEventArgs)
        {
            string messageFormat = fileLexerErrorEventArgs.Error.Message;
            string message = string.Format(messageFormat, fileLexerErrorEventArgs.Args);

            CompilerError error = new CompilerError((ushort)CompilerErrorCode.FileLexerError, message, filePath, fileLexerErrorEventArgs.Position.Position.Line, fileLexerErrorEventArgs.Position.Position.Column);
            errorHandler.ReportError(error);
        }

        public static void ReportAssemblyError(this IErrorHandler errorHandler, string assemblyName, string message)
        {
            CompilerError error = new CompilerError((ushort)CompilerErrorCode.AssemblyError, message, assemblyName);
            errorHandler.ReportError(error);
        }

        public static void ReportAssemblyLoadError(this IErrorHandler errorHandler, string assemblyName, string path)
        {
            string message = $"The referenced assembly '{assemblyName}' could not be loaded as an assembly.";
            CompilerError error = new CompilerError((ushort)CompilerErrorCode.AssemblyLoadError, message, path);
            errorHandler.ReportError(error);
        }

        public static void ReportMissingAssemblyReferenceError(this IErrorHandler errorHandler, string assemblyReferencePath)
        {
            string message = string.Format(DSharpStringResources.MISSING_ASSEMBLY_REFERENCE_FORMAT, assemblyReferencePath);
            CompilerError error = new CompilerError((ushort)CompilerErrorCode.MissingReferenceError, message, assemblyReferencePath);
            errorHandler.ReportError(error);
        }

        public static void ReportDuplicateAssemblyReferenceError(this IErrorHandler errorHandler, string assemblyName, string assemblyReferencePath)
        {
            string message = string.Empty;
            if (string.Equals(assemblyName, DSharpStringResources.DSHARP_MSCORLIB_ASSEMBLY_NAME))
            {
                message = $"The core runtime assembly, {DSharpStringResources.DSHARP_MSCORLIB_ASSEMBLY_NAME} must be referenced only once.";
            }

            message = $"The referenced assembly '{assemblyReferencePath}' is a duplicate reference.";

            CompilerError error = new CompilerError((ushort)CompilerErrorCode.DuplicateAssemblyReferenceError, message, assemblyReferencePath);
            errorHandler.ReportError(error);
        }

        public static void ReportUnsupportedFeatureError(this IErrorHandler errorHandler, string feature, ParseNode node)
        {
            string message = $"{feature} is not supported.";
            CompilerError error = new CompilerError((ushort)CompilerErrorCode.UnsupportedFeatureError, message, node.Token.SourcePath, node.Token.Position.Line, node.Token.Position.Column);
            errorHandler.ReportError(error);
        }

        public static void ReportExpressionError(this IErrorHandler errorHandler, string message, ParseNode node)
        {
            CompilerError error = new CompilerError((ushort)CompilerErrorCode.ExpressionError, message, node.Token.SourcePath, node.Token.Position.Line, node.Token.Position.Column);
            errorHandler.ReportError(error);
        }

        public static void ReportMissingReferenceError(this IErrorHandler errorHandler, string referenceName)
        {
            string message = string.Format(DSharpStringResources.UNRESOLVED_TYPE_REFERENCE_FORMAT, referenceName);
            CompilerError error = new CompilerError((ushort)CompilerErrorCode.MissingReferenceError, message);
            errorHandler.ReportError(error);
        }

        public static void ReportMissingStreamError(this IErrorHandler errorHandler, string filePath)
        {
            string message = string.Format(DSharpStringResources.MISSING_SCRIPT_OUTPUT_STREAM_FORMAT, filePath);
            CompilerError error = new CompilerError((ushort)CompilerErrorCode.MissingStreamError, message);
            errorHandler.ReportError(error);
        }
    }
}
