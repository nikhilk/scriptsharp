using DSharp.CodeAnalysis;
using DSharp.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace DSharp.Test
{
    //TODO: Rewrite the testing layer to use XUnit and be a proper library
    [TestClass]
    public class GenericTypeArgumentsMissingRuleTests : CodeFixVerifier
    {
        //TODO: Return from local asset and compile from syntaxtrees.
        private static readonly string codeUnderTest = @"using System;

namespace ConsoleApp1
{
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
        //TODO: Return from local asset and compile from syntaxtrees.
        private static readonly string codeUnderTestWithAttributes = @"using System;

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

        [ScriptIgnoreGenericArguments]
        public T Mutate<TM>(TM mutable)
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
        [ScriptIgnoreGenericArguments]
        public void Store<T>(T value)
        {
        }
    }

    public interface IUpdater
    {
        [ScriptIgnoreGenericArguments]
        T Update<T>(T instance);
    }

    public interface IUpdaterOfT<T1> : IUpdater
    {
        T1 UpdateOfT(T1 instance);
    }

    public interface ITypeIgnored<T>
    {
        [ScriptIgnoreGenericArguments]
        void Ignore<T>(T a);
    }

    public class Updater<T> : IUpdaterOfT<T>
    {
        [ScriptIgnoreGenericArguments]
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
        [ScriptIgnoreGenericArguments]
        public static T2 Magic<T1, T2>(T1 valIn, Func<T1, T2> parser)
        {
            return parser.Invoke(valIn);
        }
    }

    public static class UsagesExtensions
    {
        [ScriptIgnoreGenericArguments]
        public static void ValIn<T>(this Normal normal, T valIn)
        {
        }
    }
}";

        [TestMethod]
        public void NoSource_NoDiagnosticsReported()
        {
            var test = @"";

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void StaticMethod_NoTypeArgumentsIn_ReportsDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class Usages
    {
        public void Tests()
        {
            string value = MyStatic.Magic(1, delegate (int valIn) { return valIn.ToString(); });
        }
    }
}";
            var expected = new DiagnosticResult
            {
                Id = Consts.GenericTypeArgumentsMissingId,
                Severity = DiagnosticSeverity.Error,
                Message = "Method 'Magic' is missing type arguments and should be included.",
                Locations =
                    new[] {
                            new DiagnosticResultLocation("Test1.cs", 7, 28)
                        }
            };

            VerifyCSharpDiagnostic(new string[] { codeUnderTest, test }, expected);
        }

        [TestMethod]
        public void StaticMethodWithIgnoreAttribute_NoTypeArgumentsIn_NoReportedDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class Usages
    {
        public void Tests()
        {
            string value = MyStatic.Magic(1, delegate (int valIn) { return valIn.ToString(); });
        }
    }
}";

            VerifyCSharpDiagnostic(new string[] { codeUnderTestWithAttributes, test });
        }

        [TestMethod]
        public void StaticMethod_TypeArgumentsIn_NoReportedDiagnostics()
        {
            var test = @"
namespace ConsoleApp1
{
    public class Usages
    {
        public void Tests()
        {
            string value = MyStatic.Magic<int, string>(1, delegate (int valIn) { return valIn.ToString(); });
        }
    }
}";

            VerifyCSharpDiagnostic(new string[] { codeUnderTest, test });
        }

        [TestMethod]
        public void InstanceMethod_NoTypeArgumentsIn_ReportsDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class Usages
    {
        public void Tests()
        {
            var c = new Normal();
            c.Store(1);
        }
    }
}";
            var expected = new DiagnosticResult
            {
                Id = Consts.GenericTypeArgumentsMissingId,
                Severity = DiagnosticSeverity.Error,
                Message = "Method 'Store' is missing type arguments and should be included.",
                Locations =
                    new[] {
                            new DiagnosticResultLocation("Test1.cs", 8, 13)
                        }
            };

            VerifyCSharpDiagnostic(new string[] { codeUnderTest, test }, expected);
        }

        [TestMethod]
        public void InstanceMethod_TypeArgumentsIn_NoReportedDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class Usages
    {
        public void Tests()
        {
            var c = new Normal();
            c.Store<int>(1);
        }
    }
}";

            VerifyCSharpDiagnostic(new string[] { codeUnderTest, test });
        }

        [TestMethod]
        public void InstanceMethodWithIgnoreAttribute_NoTypeArgumentsIn_NoReportedDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class Usages
    {
        public void Tests()
        {
            var c = new Normal();
            c.Store(1);
        }
    }
}";

            VerifyCSharpDiagnostic(new string[] { codeUnderTestWithAttributes, test });
        }

        [TestMethod]
        public void ExtensionMethod_NoTypeArgumentsIn_ReportsDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class Usages
    {
        public void Tests()
        {
            var c = new Normal();
            c.ValIn(1);
        }
    }
}";
            var expected = new DiagnosticResult
            {
                Id = Consts.GenericTypeArgumentsMissingId,
                Severity = DiagnosticSeverity.Error,
                Message = "Method 'ValIn' is missing type arguments and should be included.",
                Locations =
                    new[] {
                            new DiagnosticResultLocation("Test1.cs", 8, 13)
                        }
            };

            VerifyCSharpDiagnostic(new string[] { codeUnderTest, test }, expected);
        }

        [TestMethod]
        public void ExtensionMethod_TypeArgumentsIn_NoReportedDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class Usages
    {
        public void Tests()
        {
            var c = new Normal();
            c.ValIn<int>(1);
        }
    }
}";

            VerifyCSharpDiagnostic(new string[] { codeUnderTest, test });
        }

        [TestMethod]
        public void ExtensionMethodWithIgnoreAttribute_NoTypeArgumentsIn_NoReportedDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class Usages
    {
        public void Tests()
        {
            var c = new Normal();
            c.ValIn(1);
        }
    }
}";

            VerifyCSharpDiagnostic(new string[] { codeUnderTestWithAttributes, test });
        }

        [TestMethod]
        public void BaseClassGenericMethodWithNewTypeArguments_NoTypeArgumentsIn_ReportsDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class SuperNonGeneric : GenericType<int>
    {
        public void InvokeIt(int val)
        {
            int myValue = Mutate(1);
        }
    }
}";
            var expected = new DiagnosticResult
            {
                Id = Consts.GenericTypeArgumentsMissingId,
                Severity = DiagnosticSeverity.Error,
                Message = "Method 'Mutate' is missing type arguments and should be included.",
                Locations =
                    new[] {
                            new DiagnosticResultLocation("Test1.cs", 7, 27)
                        }
            };

            VerifyCSharpDiagnostic(new string[] { codeUnderTest, test }, expected);
        }

        [TestMethod]
        public void BaseClassGenericMethodWithNewTypeArguments_TypeArgumentsIn_NoReportedDiagnostics()
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

        [TestMethod]
        public void BaseClassGenericMethodWithNewTypeArgumentsAndIgnoreAttribute_NoTypeArgumentsIn_NoReportedDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class SuperNonGeneric : GenericType<int>
    {
        public void InvokeIt(int val)
        {
            int myValue = Mutate(1);
        }
    }
}";

            VerifyCSharpDiagnostic(new string[] { codeUnderTestWithAttributes, test });
        }

        [TestMethod]
        public void BaseClassWithPretypedGenericMethod_TypeArgumentsIn_NoReportedDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class SuperNonGeneric : GenericType<int>
    {
        public void InvokeIt(int val)
        {
            int myValue = PassValue(val);
        }
    }
}";

            VerifyCSharpDiagnostic(new string[] { codeUnderTest, test });
        }

        [TestMethod]
        public void TypedGenericClassInstance_NoTypeArgumentsIn_NoReportedDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class Usages
    {
        public void Tests()
        {
            GenericType<int> genericType = new GenericType<int>();
            int value = genericType.DoSomething();
            value = genericType.PassValue(value);
        }
    }
}";

            VerifyCSharpDiagnostic(new string[] { codeUnderTest, test });
        }

        [TestMethod]
        public void NonGenericInterfaceWithGenericMethod_NoTypeArgumentsIn_ReportsDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class Usages
    {
        public void Tests()
        {
            IUpdater updater = new Updater<int>();
            updater.Update(1);
        }
    }
}";
            var expected = new DiagnosticResult
            {
                Id = Consts.GenericTypeArgumentsMissingId,
                Severity = DiagnosticSeverity.Error,
                Message = "Method 'Update' is missing type arguments and should be included.",
                Locations =
                    new[] {
                            new DiagnosticResultLocation("Test1.cs", 8, 13)
                        }
            };

            VerifyCSharpDiagnostic(new string[] { codeUnderTest, test }, expected);
        }

        [TestMethod]
        public void NonGenericInterfaceWithGenericMethod_TypeArgumentsIn_NoReportedDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class Usages
    {
        public void Tests()
        {
            IUpdater updater = new Updater<int>();
            updater.Update<int>(1);
        }
    }
}";

            VerifyCSharpDiagnostic(new string[] { codeUnderTest, test });
        }

        [TestMethod]
        public void NonGenericInterfaceWithGenericMethodAndIgnoreAttribute_NoTypeArgumentsIn_NoReportedDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class Usages
    {
        public void Tests()
        {
            IUpdater updater = new Updater<int>();
            updater.Update(1);
        }
    }
}";

            VerifyCSharpDiagnostic(new string[] { codeUnderTestWithAttributes, test });
        }

        [TestMethod]
        public void GenericInterfaceWithPretypedMethod_TypeArgumentsIn_NoReportedDiagnostics()
        {
            var test = @"namespace ConsoleApp1
{
    public class Usages
    {
        public void Tests()
        {
            IUpdaterOfT<int> updater = new Updater<int>();
            updater.UpdateOfT(1);
        }
    }
}";

            VerifyCSharpDiagnostic(new string[] { codeUnderTest, test });
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new DSharpAnalyzer(AvailableDiagnostics.GenericTypeArgumentMissing.Rule);
        }
    }
}
