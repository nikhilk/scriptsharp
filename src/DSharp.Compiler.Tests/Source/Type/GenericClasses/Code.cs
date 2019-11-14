using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace DSharp.Compiler.Tests.Source.Type.GenericClasses
{
    public class Program
    {
        public static int Main(string[] args)
        {
            GenericClass<int> genericClass = new GenericClass<int>(1);
            GenericClass<MyType> genericClass2 = new GenericClass<MyType>(new MyType());

            bool isSame = genericClass2.Type == genericClass.Type;
            Type genericClassType = typeof(GenericClass<int>);

            int[] array = new int[] { 1, 2, 3, 4, 5 };
            int[] newArr = Copy(array, 0, array.Length);

            Dictionary<string, object> values = new Dictionary<string, object>();
            Dictionary<string, Dictionary<string, Dictionary<string, object>>> values2 = new Dictionary<string, Dictionary<string, Dictionary<string, object>>>();
            Dictionary<string, object> copiedValues = CopyDictionary(values);
            Dictionary<string, Dictionary<string, Dictionary<string, object>>> copiedValues2 = CopyDictionary(values2);

            IDictionary<string, object> copiedValuesOfStrings = CopyDictionary(CopyDictionaryOfStringKeys(values));

            IBulkAsyncExecutionManager<string> bem = new BulkAsyncExecutionManager<string>();
            bem.AddExecutionKey("");
            bem.AddExecutionKeys(new string[] { "Lol", "asdasd", "hashasd" });
            bem.StartExecution();

            if (bem.GetType() == typeof(BulkAsyncExecutionManager<int>))
            {

            }
            if (bem.GetType() == typeof(BulkAsyncExecutionManager<string>))
            {

            }
            if (typeof(IBulkAsyncExecutionManager<string>).IsAssignableFrom(bem.GetType()))
            {

            }

            GenericWithMultipleParams<int, bool, string> genericWithMultipleParams = new GenericWithMultipleParams<int, bool, string>();
            string str = genericWithMultipleParams.ToString();

            SpecificClassOfGeneric specificClassOfGeneric = new SpecificClassOfGeneric();
            bool isInt = specificClassOfGeneric.Type == typeof(int);
            GenericClass<int> myContainer = specificClassOfGeneric.CreateContainer();
            isInt = myContainer.Type == typeof(int);
        }

        public static T[] Copy<T>(T[] source, int startIndex, int count)
        {
            T[] destination = new T[source.Length];
            Array.Copy(source, startIndex, destination, 0, count);
            return destination;
        }

        public static IDictionary<TKey, TValue> CopyDictionary<TKey, TValue>(IDictionary<TKey, TValue> source)
        {
            IDictionary<TKey, TValue> newDictionary = new Dictionary<TKey, TValue>();
            foreach (KeyValuePair<TKey, TValue> item in source)
            {
                newDictionary.Add(item.Key, item.Value);
            }

            return newDictionary;
        }

        public static Dictionary<string, TValue> CopyDictionaryOfStringKeys<TValue>(IDictionary<string, TValue> source)
        {
            IDictionary<string, TValue> newDictionary = new Dictionary<string, TValue>();
            foreach (KeyValuePair<string, TValue> item in source)
            {
                newDictionary.Add(item.Key, item.Value);
            }

            return newDictionary;
        }
    }

    public class MyType
    {
        public string Name;
    }

    public class GenericClass<T> : BaseGenericClass<T>
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

        public GenericClass(T value, Func<T, T> mutator)
            : base(value)
        {
            this.value = value;
            this.mutator = mutator;
        }

        public void Mutate()
        {
            value = mutator.Invoke(value);
        }

        public GenericClass<T> CreateContainer()
        {
            return new GenericClass<T>(value, mutator);
        }
    }

    public abstract class BaseGenericClass<T>
    {
        protected T baseField;

        public BaseGenericClass(T baseField)
        {
            this.baseField = baseField;
        }

        public T BaseField
        {
            get { return baseField; }
        }
    }

    public interface IBulkAsyncExecutionManager<T>
    {
        void AddExecutionKey(T executionKey);

        void AddExecutionKeys(IEnumerable<T> executionKeys);

        void StartExecution();
    }

    public class BulkAsyncExecutionManager<T> : IBulkAsyncExecutionManager<T>
    {
        public void AddExecutionKey(T executionKey)
        {
            Type typeOfT = typeof(T);
        }

        public void AddExecutionKeys(IEnumerable<T> executionKeys)
        {
            Type typeOfT = executionKeys.GetType();
        }

        public void StartExecution()
        {
        }
    }

    public class GenericWithMultipleParams<T1, T2, T3>
    {

    }

    public class SpecificClassOfGeneric : GenericClass<int>
    {
        public SpecificClassOfGeneric(int value)
            : base(value, MyMutator)
        {
        }

        public int ReturnMyField()
        {
            return BaseField;
        }

        private static int MyMutator(int valIn)
        {
            return valIn + 1;
        }
    }
}
