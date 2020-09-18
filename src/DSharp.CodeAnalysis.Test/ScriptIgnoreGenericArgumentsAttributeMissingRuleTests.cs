using DSharp.CodeAnalysis;
using DSharp.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace DSharp.Test
{
    // 1. Check for Attribute usages and test for cases:
    //      - Attribute applied to self, but invoked method has no attribute
    //      - Attribute applied to type of interface and interface has no attribute - must be there.
    [TestClass]
    public class ScriptIgnoreGenericArgumentsAttributeMissingRuleTests : CodeFixVerifier
    {
        //TODO: Return from local asset and compile from syntaxtrees.
        private static readonly string codeUnderTest = @"using System;

namespace ConsoleApp1
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ScriptIgnoreGenericArgumentsAttribute : Attribute
    {
    }

    public class GenericType<T>
    {
        public T MyField { get; }

        public T DoSomething()
        {
            return default(T);
        }

        public T PassValue(T value)
        {
            return value;
        }

        public T Mutate<TM>(TM mutable)
            where TM : T
        {
            return mutable;
        }

        [ScriptIgnoreGenericArguments]
        public T MutateWithAttribute<TM>(TM mutable)
            where TM : T
        {
            return mutable;
        }
    }

    public class PropertyWrapper<T>
    {
        public T ValIn { get; }

        public PropertyWrapper(T valIn)
        {
            ValIn = valIn;
        }
    }

    public class Normal
    {
        public void Store<T>(T value)
        {
        }
    }

    public interface IUpdater
    {
        T Update<T>(T instance);
    }

    public interface IUpdaterOfT<T1> : IUpdater
    {
        T1 UpdateOfT(T1 instance);
    }

    public class Updater<T> : IUpdaterOfT<T>
    {
        public T1 Update<T1>(T1 instance)
        {
            return instance;
        }

        public T UpdateOfT(T instance)
        {
            throw new NotImplementedException();
        }
    }

    public static class MyStatic
    {
        public static T2 Magic<T1, T2>(T1 valIn, Func<T1, T2> parser)
        {
            return parser.Invoke(valIn);
        }
    }

    public static class UsagesExtensions
    {
        public static void ValIn<T>(this Normal normal, T valIn)
        {
        }
    }
}
";

        [TestMethod]
        public void CallerMarkedWithAttribute_InvokedMethodNoAttribute_ReportsDiagnostic()
        {
            var test = @"namespace ConsoleApp1
{
    public class SuperNonGeneric : GenericType<int>
    {
        [ScriptIgnoreGenericArguments]
        public void InvokeIt<T>(T val)
        {
            int myValue = Mutate(1);
        }
    }
}";
            var expected = new DiagnosticResult
            {
                Id = Consts.ScriptIgnoreGenericArgumentsAttributeMissingId,
                Severity = DiagnosticSeverity.Error,
                Message = "Missing ScriptIgnoreGenericArguments on 'Mutate' method invocation and should be added.",
                Locations =
                    new[] {
                            new DiagnosticResultLocation("Test1.cs", 8, 27)
                        }
            };

            VerifyCSharpDiagnostic(new string[] { codeUnderTest, test }, expected);
        }

        [TestMethod]
        public void NoAttributeOnCaller_InvokedMethodNoAttribute_NoDiagnosticsReported()
        {
            var test = @"namespace ConsoleApp1
{
    public class SuperNonGeneric : GenericType<int>
    {
        public void InvokeIt(int val)
        {
            int myValue = Mutate<int>(1);
        }
    }
}";
            VerifyCSharpDiagnostic(new string[] { codeUnderTest, test });
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new DSharpAnalyzer(AvailableDiagnostics.ScriptIgnoreGenericArgumentsAttributeMissing.Rule);
        }
    }
}
