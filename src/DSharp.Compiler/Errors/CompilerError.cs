using System;

namespace DSharp.Compiler.Errors
{
    public struct CompilerError : IEquatable<CompilerError>
    {
        public CompilerError(ushort errorCode, string description)
            : this(errorCode, description, string.Empty)
        {
        }

        public CompilerError(ushort errorCode, string description, string file)
            : this(errorCode, description, file, null, null)
        {
        }

        public CompilerError(ushort errorCode, string description, string file, int? lineNumber, int? columnNumber)
        {
            ErrorCode = errorCode;
            Description = description;
            File = file;
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
        }

        public ushort ErrorCode { get; }

        public string Description { get; }

        public string File { get; }

        public int? LineNumber { get; }

        public int? ColumnNumber { get; }

        public string FormattedErrorCode
        {
            get { return $"DS{ErrorCode.ToString("D4")}"; }
        }

        public bool Equals(CompilerError other)
        {
            return ErrorCode == other.ErrorCode
                && Description == other.Description
                && File == other.File
                && LineNumber == other.LineNumber
                && ColumnNumber == other.ColumnNumber;
        }

        public override bool Equals(object obj)
        {
            return obj is CompilerError compilerError
                && Equals(compilerError);
        }

        public override int GetHashCode()
        {
            return HashingUtils.CombineHashCodes(ErrorCode, Description, File, LineNumber);
        }

        public override string ToString()
        {
            return $"[{FormattedErrorCode}] {File}({LineNumber},{ColumnNumber}): {Description}";
        }
    }
}
