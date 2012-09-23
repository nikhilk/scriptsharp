using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace BasicTests {

    public delegate void DoStuff(int i);

    public class App : IApp {

        public App() {
        }

        public event DoStuff Event1;

        public event DoStuff Event2 {
            add {
            }
            remove {
            }
        }

        public void Run() {
        }

        private void Initialize() {
        }
    }

    [Flags]
    public enum AppFlags {

        AAA = 1,

        BBB = 2
    }

    public enum Mode {

        Mode1 = 0,

        Mode2 = 1
    }

    internal class AppHelper {

        public int Prop1 { get { return 0; } }
        public int Prop2 { get { return 0; } set { } }

        public int this[string name] { get { return 0; } }

        internal void ShowHelp() { }
    }

    internal interface IFoo {
    }

    public interface IApp {

        void Run();
    }

    [ScriptExtension("$global")]
    internal static class Util {

        internal static void ShowHelp() { }
    }

    [ScriptObject]
    internal sealed class Point {
         public int x;
         public int y;

         public Point(int x, int y) {
             this.x = x;
             this.y = y;
         }
    }
}
