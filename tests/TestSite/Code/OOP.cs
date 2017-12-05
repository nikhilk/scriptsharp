using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Test;

[assembly:ScriptAssembly("oop")]

namespace Test {

    public interface IMammal {
    }

    public interface IAnimal
    {
        string Species { get; }
    }

    public interface IPet : IAnimal {
    
        string Name {
            get;
        }
        
        string Owner {
            get;
        }
    }

    public class Animal
    {
    
        private string _species;
        
        public Animal(string species) {
            _species = species;
        }

        public string Species {
            get {
                return _species;
            }
        }

        public virtual string Live(int i) {
            return "[" + i + "] ...";
        }

        public virtual string Die() {
            return "...";
        }
    }

    public class Cat : Animal, IMammal {

        private string speak;

        public Cat() : base("Cat") {
            this.speak = "meow";
        }

        public bool SetSpeak
        {
            set { speak = value; }
        }

        public virtual string Speak() {
            return speak;
        }

        public override string Die() {
            return base.Die();
        }
    }
}

namespace Test.More {

    public interface ICharacter {
    }

    public class Garfield : Cat, IPet, ICharacter {

        public string Name {
            get {
                return "Garfield";
            }
        }

        public string Owner {
            get {
                return "Jon";
            }
        }

        public override string Speak() {
            return base.Speak() + "\r\n" +
                   "Translation: " +
                   "I am fat, lazy, and cynical, but still, a favorite cat...";
        }

        public override string Live(int i) {
            return base.Live(i) + " zzz";
        }
    }

    public class Comic {

        private string _name;
        private ICharacter _star;

        public Comic(string name, ICharacter star) {
            _name = name;
            _star = star;
        }

        public string Name {
            get {
                return _name;
            }
        }
        
        public ICharacter Star {
            get {
                return _star;
            }
        }
    }
}

namespace Test.Misc {

    public interface IObject {
    }

    public class Zoo {
    }
}


namespace Test.Bases {

    // A series of classes with different combinations of overrides at different
    // levels in the class hierarchy. Tests issues #379, #384 as applied to properties,
    // methods, and index operators.

    public class C1 {
        private string _valueA = "A";

        public virtual string PropertyA {
            get {
                return _valueA + "-PC1";
            }
            set {
                _valueA = value + "+PC1";
            }
        }

        public virtual string MethodA() {
            return _valueA + "-MC1";
        }

        public virtual string this[int key] {
            get {
                return _valueA + "-" + key.ToString() + "IC1";
            }
            set {
                _valueA = value + "+" + key.ToString() + "IC1";
            }
        }
    }

    public class C2 : C1 {
        public override string PropertyA {
            get {
                return base.PropertyA + "-PC2";
            }
            set {
                base.PropertyA = value + "+PC2";
            }
        }

        public override string MethodA() {
            return base.MethodA() + "-MC2";
        }

        public override string this[int key] {
            get {
                return base[key] + "-" + key.ToString() + "IC2";
            }
            set {
                base[key] = value + "+" + key.ToString() + "IC2";
            }
        }
    }

    public class C3 : C2 {
        public override string PropertyA {
            get {
                return base.PropertyA + "-PC3";
            }
            set {
                base.PropertyA = value + "+PC3";
            }
        }

        public override string MethodA() {
            return base.MethodA() + "-MC3";
        }

        public override string this[int key] {
            get {
                return base[key] + "-" + key.ToString() + "IC3";
            }
            set {
                base[key] = value + "+" + key.ToString() + "IC3";
            }
        }
    }

    public class C4 : C3 {
        // intentionally skip this generation of overrides
    }

    public class C5 : C4 {
        public override string PropertyA {
            get {
                return base.PropertyA + "-PC5";
            }
            set {
                base.PropertyA = value + "+PC5";
            }
        }

        public override string MethodA() {
            return base.MethodA() + "-MC5";
        }

        public override string this[int key] {
            get {
                return base[key] + "-" + key.ToString() + "IC5";
            }
            set {
                base[key] = value + "+" + key.ToString() + "IC5";
            }
        }
    }

    public class PublicBaseClass
    {
        public bool baseField;

        public PublicBaseClass()
        {
            this.baseField = true;
        }

        public bool BaseMethod()
        {
            return true;
        }

        public bool BaseProperty
        {
            get { return true; }
        }
    }

    internal class InternalDerivedClass : PublicBaseClass
    {

    }

    public class PublicAccessorClass
    {
        public PublicBaseClass Create()
        {
            return new InternalDerivedClass();
        }
    }

    public enum E1
    {
        Zero = 0,
        One = 1,
        Two = 2
    }

    [ScriptConstants(UseNames = true)]
    public enum E2
    {
        Zero = 0,
        One = 1,
        Two = 2
    }

    public class C6
    {
        public C6(Nullable<int> i, Type t, Func<string> f, Action<string,int> a, E1 e1, E2 e2)
        {

        }
    }

    public class TestCase {

        public static string RunTest(C1 x) {
            string output = "";
            string delim = ",";

            // Test getter, method, and index (should accumulate outward through bases)
            output = x.PropertyA
                    + delim + x.MethodA()
                    + delim + x[99];

            // Test property setter (should accumulate inward and outward through bases)

            x.PropertyA = "X";
            output += delim + x.PropertyA;

            // Test index setter (should accumulate inward and outward through bases)

            x[88] = "Y";
            output += delim + x[99];

            return output;
        }

    }

}
