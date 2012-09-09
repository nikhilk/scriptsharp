using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace MemberTests {

    public class EventArgs {
    }

    public delegate void EventHandler(object sender, EventArgs e);

    public class Button {

        private EventHandler _aaa;

        public event EventHandler Click;

        public static event EventHandler test;

        public event EventHandler aaa {
            add {
                if (_aaa == null) {
                    _aaa = value;
                }
                else {
                    _aaa = (EventHandler)Delegate.Combine(_aaa, value);
                }
            }
            remove {
                _aaa = (EventHandler)Delegate.Remove(_aaa, value);
            }
        }

        public void PerformClick() {
            if (Click != null) {
                Click(this, new EventArgs());
            }
        }
    }
}
