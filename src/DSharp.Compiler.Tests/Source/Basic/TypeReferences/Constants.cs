using System;
using Library;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public class App
    {
        private const string COPY_OF_TEXT_CONSTANT = ConstantsInLib.TEXT;
        public const int COMPLEX_NUMBER_CONSTANT = 0 + ConstantsInLib.NUMBER;

        public string Foo()
        {
            const int localConstant = ConstantsInLib.NUMBER;

            return "Consts: " + localConstant + "; " + ConstantsInLib.TEXT + "; ";
        }
    }
}
