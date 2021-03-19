using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Library1;

[assembly: ScriptAssembly("test")]

namespace DSharp.Compiler.Tests.Source.Type.GenericClasses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OpenGenericClass<int> genericClass = new OpenGenericClass<int>(1, DoubleIt);
            OpenGenericClass<MyType> genericClass2 = new OpenGenericClass<MyType>(new MyType(), Identity<MyType>);

            Type openGenericType = typeof(OpenGenericClass<>);
            Type constructedGenericType = typeof(OpenGenericClass<int>);

            SpecificClassOfGeneric genericClass3 = new SpecificClassOfGeneric(1, DoubleIt);
        }

        private static int DoubleIt(int value)
        {
            return value * 2;
        }

        private static T Identity<T>(T value)
        {
            return value;
        }
    }

    public class MyType
    {
        public string Name;
    }

    public class OpenGenericClass<T> : IGenericInterface<T>
    {
        private readonly Func<T, T> mutator;
        private T value;

        public T Value
        {
            get { return value; }
        }

        public Type Type
        {
            get { return typeof(T); }
        }

        public OpenGenericClass(T value, Func<T, T> mutator)
        {
            this.value = value;
            this.mutator = mutator;
        }

        public void Mutate()
        {
            value = mutator.Invoke(value);
        }

        public OpenGenericClass<T> CreateContainer()
        {
            return new OpenGenericClass<T>(value, mutator);
        }
    }

    public interface IGenericInterface<T> : IReferencedGenericInterface<T>
    {
        T Value { get; }
    }    

    public class GenericWithMultipleParams<T1, T2, T3>
    {

    }

    public class SpecificClassOfGeneric : IGenericInterface<int>
    {
        private readonly Func<int, int> mutator;
        private int value;

        public int Value
        {
            get { return value; }
        }

        public Type Type
        {
            get { return typeof(int); }
        }

        public SpecificClassOfGeneric(int value, Func<int, int> mutator)
        {
            this.value = value;
            this.mutator = mutator;
        }

        public void Mutate()
        {
            value = mutator.Invoke(value);
        }
    }
    
    [ScriptIgnoreGenericArgumentsAttribute]
    public interface GenericInterfaceWithIgnore<T1, T2>
    {

    }
}
