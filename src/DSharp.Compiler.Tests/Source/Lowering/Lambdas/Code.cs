using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace LoweringTests {

    public class Test {

        private Func<bool> getFalse;

        public Test() {
            this.getFalse = () => false;
            Func<int, int> addOne = a => a + 1;
#if TEST
            Func<int, int, int> sumFail = (a, b) => a + b;
#else
            Func<int, int, int> sum = (a, b) => a + b;
#endif
            Action doNothing = () => { };
            Action<bool> doSomething = a => {
                if(!a)
                {
                    return;
                };
            };
            GenericClass<Test> foo = new GenericClass<Test>();

            Action<GenericClass<Test>> nested = x => x.Method(a => a.Bar++);
            foo.Method(a => a.Bar++);
        }

        public int Bar;
    }

    public class GenericClass<T>
    {
        public void Method(Action<T> action)
        {

        }
    }

    public interface ILogger
    {
        void Info(string message, string channel, params object[] args);
    }

    public static class LoggerExtensions
    {
        public static void Info<T>(this ILogger logger, string message)
        {
            ExecuteLogger<T>(logger, inner => inner.Info, message);
        }

        public static void FormatInfo<T>(this ILogger logger, string messageFormat, params object[] parameters)
        {
            ExecuteLogger<T>(logger, inner => inner.Info, messageFormat, parameters);
        }

        private static void ExecuteLogger<T>(this ILogger logger, Func<ILogger, Action<string, string, object[]>> method, string message, params object[] parameters)
        {
            Action<string, string, object[]> loggerMethod = method.Invoke(logger);
            Type type = typeof(T);
            string channelName = type.Name;
            loggerMethod.Invoke(message, channelName, parameters ?? new object[0]);
        }
    }
}
