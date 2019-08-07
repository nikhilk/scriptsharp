using DSharp.Compiler.CodeModel;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    internal interface IParseNodeValidator
    {
        bool Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler);
    }
}
