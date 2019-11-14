using System;
using System.Collections.Generic;

[assembly: ScriptAssembly("test")]

namespace TypeTests
{
    class Usages
    {
        public void Use()
        {
            GenericClass<int> genericClass = new GenericClass<int>(1);
            genericClass.DoSomethingWith<bool>(false, 1);
            genericClass.Register<IBase, ImplementsBase>();

            GenericClass<int> newClass = DoSomethingAwesome<int>(1);
            var success1 = newClass.GetType() == typeof(GenericClass<string>);
            var success2 = genericClass.GetType() == newClass.GetType();

            GenericClass<GenericClass<int>> instance = new GenericClass<GenericClass<int>>(new GenericClass<int>(1));
            var outInt = instance.Value.Value;

            ParseTheList<int>(new List<int>() { 1, 2, 3 }).Add(4);

            Wrapper wrapper = new Wrapper();
            wrapper.Invokee.Invoke<GenericClass<int>>("").DoSomethingWith<bool>(true, 0);

            int val = new Invoker().InvokeAll<int>("1");
        }

        public interface IBase { }

        public class ImplementsBase : IBase { }

        public static GenericClass<T> DoSomethingAwesome<T>(T value)
        {
            return new GenericClass<T>(value);
        }

        public IList<T> ParseTheList<T>(IList<T> what)
        {
            return what;
        }
    }

    public class GenericClass<T>
    {
        private readonly T value;

        public T Value
        {
            get { return value; }
        }

        public Type Type
        {
            get { return typeof(T); }
        }

        public GenericClass(T value)
        {
            this.value = value;
        }

        public void DoSomethingWith<TNew>(TNew n, T o)
        {
            Type tnewType = typeof(TNew);
            Type oldType = typeof(T);

            if (tnewType == oldType)
            {
                return;
            }
        }

        public void Register<TBase, TImplementation>()
            where TImplementation : TBase
        {
            Type baseT = typeof(TBase);
            Type implT = typeof(TImplementation);
        }
    }

    public class Wrapper
    {
        public Invoker Invokee { get; }
    }

    public class Invoker
    {
        public T Invoke<T>(string value)
            where T : class
        {
            return default;
        }

        public T InvokeAll<T>(string value)
        {
            return default;
        }
    }
}
