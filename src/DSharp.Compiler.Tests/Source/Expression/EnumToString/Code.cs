using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    enum Mode { A = 0, B = 1 }
    
    enum Color { Red = 1, Green = 2, Blue = 3 }

    [ScriptConstants(UseNames = true)]
    public enum State {
        Starting = 1,
        Running = 2,
        Completed = 3
    }

    [Flags]
    public enum Types {
        None = 0,
        Type1 = 1,
        Type2 = 2,
        Type3 = 4
    }

    public class App {

        public void Test(int arg) {
            string s1 = Mode.A.ToString();
            string s2 = Color.Green.ToString();
            string s3 = State.Starting.ToString();
            string s4 = Types.None.ToString();
        }

        private void Display(Mode m, Color c, State s, Types t) {
            string mstr = m.ToString();
            string cstr = c.ToString();
            string sstr = s.ToString();
            string tstr = t.ToString();
        }
    }
}
