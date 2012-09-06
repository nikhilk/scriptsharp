using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("Sample")]

namespace Script.Sample {

    public abstract class Component {

        private string _id;

        static Component() {
        }

        protected Component(bool registerAsDisposable) {
            _id = null;
            Initialized(this, new EventArgs());
        }

        public string id {
            get {
                return _id;
            }
        }

        public virtual string this[string name] {
            get {
                return _id;
            }
        }

        public event EventHandler Initialized;
    }

    public class Control : Component {

        public Control() : base(true) {
        }

        public override string this[string name] {
            get {
                return base[name] + "1";
            }
        }
    }

    public interface ITypeDescriptorProvider {

        object getDescriptor();
    }

    public enum BindingDirection { In, Out, InOut }

    public class Binding {

        private BindingDirection _direction;

        public BindingDirection direction {
            get {
                return _direction;
            }
            set {
                _direction = value;
            }
        }
    }

    public class EventArgs {
    }

    public delegate void EventHandler(object sender, EventArgs e);

    public delegate int MyCallback();
}
