using System;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests
{
    public class Program
    {
        public static int Main(string[] args)
        {
            ConcreteClass concreteClass = new ConcreteClass();
            concreteClass.Execute();
        }
    }

    public class BaseClass
    {
        protected virtual void OnResourceLoaded()
        {
        }
    }

    public class ConcreteClass : BaseClass
    {
        private readonly IExecutor executor = null;

        public ConcreteClass(IExecutor executor)
        {
            this.executor = executor;
        }

        public void Execute()
        {
            executor.Execute(base.OnResourceLoaded, OnResourceFailed);
        }

        public void OnResourceFailed()
        {
        }

        public override void OnResourceLoaded()
        {
        }
    }

    public interface IExecutor
    {
        void Execute(Action success, Action failure);
    }

    public class Executor : IExecutor
    {
        public void Execute(Action success, Action failure)
        {
            success.Invoke();
            failure.Invoke();
        }
    }

    public class Foo
    {
        public Foo(int i, int j)
        {
        }

        public override string ToString()
        {
            return "Foo";
        }

        public virtual int Sum(int i)
        {
            return 0;
        }
    }

    public class Bar : Foo
    {
        public Bar(int i, int j, Foo f) : base(i, j)
        {
        }

        public override int Sum()
        {
            return base.Sum(1) + 1;
        }

        public override string ToString()
        {
            return base.ToString() + " -> Bar";
        }
    }
}
