using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library1;

[assembly: ScriptAssembly("test")]

namespace DSharp.Shell.src
{
    public class UsageOfConstants
    {
        private const string COPY_OF_TEXT_CONSTANT = DefinedConstants.TEXT;

        public const string COMPLEX_TEXT_CONSTANT = "Hello, " + DefinedConstants.TEXT + " world!";
        public const double COMPLEX_NUMBER_CONSTANT = -21 + DefinedConstants.NUMBER_INT + DefinedConstants.DECIMAL_DOUBLE - 21;

        public string Foo()
        {
            const int localIntConstant = DefinedConstants.NUMBER_INT;
            const short localFloatConstant = DefinedConstants.DECIMAL_DOUBLE;

            // TIP: this line will add an output reference to the lib1
            // DefinedConstants reference = new DefinedConstants();

            return "Consts: " + localIntConstant + "; " + localFloatConstant + "; " + DefinedConstants.TEXT;
        }
    }
}
