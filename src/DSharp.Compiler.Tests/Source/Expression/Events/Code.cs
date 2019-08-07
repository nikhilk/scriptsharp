using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class FooEventArgs : EventArgs {
    }

    public class Button {

        private EventHandler _aaa;
        private EventHandler<FooEventArgs> _bbb;

        public event EventHandler click;

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

        public event EventHandler<FooEventArgs> bbb {
            add {
                if (_bbb == null) {
                    _bbb = value;
                }
                else {
                    _bbb = (EventHandler<FooEventArgs>)Delegate.Combine(_bbb, value);
                }
            }
            remove {
                _bbb = (EventHandler<FooEventArgs>)Delegate.Remove(_bbb, value);
            }
        }
    }

    public class App {

        private Button _btn;

        public App() {
            _btn.click += OnClickButton;
            _btn.click += new EventHandler(OnClickButton);
            _btn.click += new EventHandler(this.OnClickButton);

            _btn.click -= OnClickButton;
            _btn.click -= new EventHandler(OnClickButton);
            _btn.click -= new EventHandler(this.OnClickButton);

            Button.test += OnTestButton;
            Button.test += new EventHandler(OnTestButton);
            Button.test += new EventHandler(App.OnTestButton);

            Button.test -= OnTestButton;
            Button.test -= new EventHandler(OnTestButton);
            Button.test -= new EventHandler(App.OnTestButton);

            _btn.aaa += OnAAAButton;
            _btn.aaa += new EventHandler(OnAAAButton);
            _btn.aaa += new EventHandler(this.OnAAAButton);

            _btn.aaa -= OnAAAButton;
            _btn.aaa -= new EventHandler(OnAAAButton);
            _btn.aaa -= new EventHandler(this.OnAAAButton);

        }

        private void OnAAAButton(object sender, EventArgs e) {
        }

        private void OnClickButton(object sender, EventArgs e) {
        }

        private static void OnTestButton(object sender, EventArgs e) {
        }
    }
}
