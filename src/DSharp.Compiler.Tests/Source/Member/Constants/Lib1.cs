using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("lib1")]

namespace Library1 {

    public class DefinedConstants
    {
        public const string TEXT = "[example" + " text " + "constant]";

        public const byte NUMBER_BYTE = 42;
        public const short NUMBER_SHORT = 40 + 02;
        public const int NUMBER_INT = NUMBER_BYTE;
        private const long NUMBER_LONG = NUMBER_SHORT;

        public const double DECIMAL_DOUBLE = 42.42;
        internal const float DECIMAL_FLOAT = .42f;
    }
}
