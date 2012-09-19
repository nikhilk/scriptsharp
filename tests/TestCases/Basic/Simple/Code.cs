// Code.cs
//

using System;
using System.Collections;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("basic")]

[assembly: ScriptTemplate(@"
// {name}.js
// Sample script...
""use strict"";

define('{name}', [{requires}], function({dependencies}) {
  var $global = this;

  {script}
});

// Generated with Script#
")]

namespace Basic {

    public class EventArgs {

        [PreserveCase]
        public static readonly EventArgs Empty = new EventArgs();
    }

    public delegate void EventHandler(object sender, EventArgs e);

    public class Button {

        private string _text;

        public event EventHandler click;

        public Button(string text) {
            _text = text;
        }

        public string text {
            get {
                return _text;
            }
        }

        public void performClick() {
            if (click != null) {
                click(this, EventArgs.Empty);
            }
        }
    }

    public class App {

        private Button _btn1;
        private Button _btn2;

        public App() {
            _btn1 = new Button("OK");
            _btn1.click += new EventHandler(this.onClickButton);
            _btn1.click += new EventHandler(this.onClickButtonDup);

            _btn2 = new Button("Cancel");
            _btn2.click += new EventHandler(this.onClickButton);
        }

        private void Echo(string s) {
        }

        private void onClickButton(object sender, EventArgs e) {
            Echo(((Button)sender).text + " was clicked!");
        }

        private void onClickButtonDup(object sender, EventArgs e) {
            Echo(((Button)sender).text + " was clicked as well!");
        }

        public static void Main(Dictionary args) {
            App theApp = new App();

            theApp._btn1.performClick();
            theApp._btn2.performClick();
        }
    }
}
