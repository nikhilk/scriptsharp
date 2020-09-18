using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace MemberTests {

    public interface ITest
    {
        int XYZ { get; set; }
        bool IsFoo { get; }
        string ISet { set; }
        object Object { get; set; }
    }

    public class Program
    {
        public static int Main(string[] args)
        {
            Properties properties = new Properties("Private String");
            properties.Standard = "Standard Property!";
            properties.Normal = "test2";
            var readWrite = properties.ReadLocalWrite;
            var readonlyValue = properties.ReadonlyValue;
        }
    }

    public class Test {

        public bool isFoo;

        public static int StaticProp {
            get { return 2006; }
        }

        public int XYZ {
            get { return 0; }
            set {  }
        }

        public bool IsFoo {
            get { return isFoo; }
            set { isFoo = value; }
        }

        public string ISet
        {
            set {  }
        }

        public string Object { get; set; }

        extern object ITest.Object { get; set; }

        protected string Name { get { return "nk"; } }

        private bool IsInitialized { get { return false; } }

        public Test() {
            XYZ = 1;
            this.XYZ = this.Name.Length;

            ITest inter = (ITest)this;

            inter.XYZ = Name.Length;

            inter.XYZ++;
            --this.XYZ;

            int v = StaticProp;
            v = Test.StaticProp;

            bool foo = IsFoo;
            IsFoo = true;

            ISet = "set me";
        }
    }

    public class Test2 : Test {

        public Test2() {
            int n = base.XYZ;
            base.XYZ = 6;
            if (n == XYZ) {
            }
            if (XYZ == n) {
            }

            n = Test.StaticProp;
        }
    }

    public class Properties
    {
        private string readWriteWithBacking;

        public string Normal { get; set; }

        public string Standard { get; set; }

        public string ReadLocalWrite { get; private set; }

        public string ReadonlyValue { get; } //CSharp 6!

        public bool BoolAutoProp { get; set; }

        public int IntAutoProp { get; set; }

        public string ReadWriteWithBacking
        {
            get { return readWriteWithBacking; }
            set { readWriteWithBacking = value; }
        }

        public Properties(string readonlyVal)
        {
            ReadonlyValue = readonlyVal ?? "InitialState_ReadonlyValue";
            ReadLocalWrite = "InitialState_ReadLocalWrite";
            Normal = ReadLocalWrite ?? CreateNormalExpression(delegate ()
            {
                return "TestValue";
            });
        }

        public void Change(string value)
        {
            ReadLocalWrite = value;
        }

        private static string CreateNormalExpression(Func<string> returnValue)
        {
            returnValue.Invoke();
        }
    }

    public abstract class AbstractPropertiesContainer
    {
        protected abstract string MyAbstractProp { get; set; }
        protected virtual string MyVirtualProp { get; set; }
    }

    public sealed class ImplementedContainer : AbstractPropertiesContainer
    {
        private string InstanceProp { get; set; }

        private string value = "";

        protected override string MyAbstractProp
        {
            get { return value; }
            set { this.value = value; }
        }

        protected override string MyVirtualProp
        {
            get { return base.MyVirtualProp; }
            set { base.MyVirtualProp = value; }
        }
    }

    public class StaticProps
    {
        public static string Prop { get; set; }

        public static StaticProps Instance { get; private set; }

        public int Index { get; set; }

        static StaticProps()
        {
            Instance = new StaticProps();
        }

        private StaticProps()
        {
            Index = NestedStaticProps.Val;
        }

        public class NestedStaticProps
        {
            public static int Val { get; set; }
        }
    }
}
