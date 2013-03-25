using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Test;

[assembly:ScriptAssembly("oop")]

namespace Test {

    public interface IMammal {
    }
    
    public interface IPet {
    
        string Name {
            get;
        }
        
        string Owner {
            get;
        }
    }
    
    public class Animal {
    
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

        public virtual string Grow()
        {
            return this.Species + " has grown up";
        }

        public virtual string LiveThenDie(int i) {
            return this.Live(0) + " " + this.Die();
        }
    }

    public class Cat : Animal, IMammal {

        public Cat() : base("Cat") {
        }

        public virtual string Speak() {
            return "meow";
        }

        public override string Die() {
            return base.Die();
        }

        public override string Grow() {
            return base.Grow() + " " + base.Live(1);
        }

        public virtual string LiveThenSpeak() {
            return base.Live(1) + " " + this.Speak();
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

        public override string LiveThenSpeak()
        {
            return base.Live(2) + " " + base.Speak();
        }

        public string LiveThenSpeakThis() {
            return this.Live(2) + " " + this.Speak();
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
