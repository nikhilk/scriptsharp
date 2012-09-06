using System;
using System.Html;
using System.Runtime.CompilerServices;

[assembly:ScriptAssembly("lib")]

namespace ScriptFX {

    public abstract class Behavior {
    
        protected Behavior(Element e, string name) {
        }
        
        public virtual void Dispose() {
        }
    }
    
    public abstract class Control : Behavior {
    
        protected Control(Element e) : base(e, "control") {
        }
    }

    public class TextBox : Control {
    
        protected TextBox(Element e) : base(e) {
        }
    }
}
