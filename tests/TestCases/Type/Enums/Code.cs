using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace TypeTests {

    public enum Colors {
        Red = 0, Green = 1, Blue = 2
    }

    public enum Sequence {
        Item1 = 1, Item2 = 2, Item3 = 3, Item4 = 5
    }

    [Flags]
    public enum Mode {
        [PreserveCase]
        Public = 1,
        [PreserveCase]
        Protected = 2,
        [PreserveCase]
        Private = 4
    }

    public enum UInt32Mask : uint {

        V = 0xF0000000,
        A = 0xFF000000
    }

    public enum ShortMask : short {
        V = 0x0001,
        A = 0x1000
    }

    public enum Errors {

        [PreserveCase]
        S_OK = 0,
        [PreserveCase]
        S_FALSE = 1,
        [PreserveCase]
        E_FAIL = -1
    }

    public class App {
        public static void Main() {
            Mode m = Mode.Public;
            m = Mode.Public | Mode.Private;

            Colors c = Colors.Red;
        }
    }

    [ScriptConstants(UseNames = true)]
    [ScriptImport]
    public enum HttpMethod {
        GET = 0,
        POST = 1,
        PUT = 2,
        DELETE = 3,
    }

    [ScriptConstants(UseNames = true)]
    internal enum SortMode {
        Status = 1,
        [PreserveCase]
        Group = 2,
        [ScriptName("Ct")]
        Count = 3
    }

    [ScriptConstants(UseNames = true)]
    public enum Size {
        Small = 0,
        [PreserveCase]
        Medium = 1,
        Large = 2,
    }

    [ScriptConstants]
    public enum Chars {
        A = 65, B = 66
    }

    public class App2 {

        private HttpMethod httpMethod;
        private SortMode sortMode;

        public void Run() {

           HttpMethod method = HttpMethod.POST;

           Run1(HttpMethod.GET);
           Run2(SortMode.Status);
           Run2(SortMode.Group);
           Run2(SortMode.Count);

           string s = Size.Medium.ToString();
        }

        public void Run1(HttpMethod m) {
           string s = m.ToString();
        }

        public void Run2(SortMode m) {
            Chars aCode = Chars.A;
            Chars bCode = Chars.B;
        }
    }
}
