// Code.cs
//

using System;
using System.Collections;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("basic")]
[assembly: AssemblyDescription("Simple code generation test.")]
[assembly: AssemblyCopyright("Copyright (c) Script# Project, 2012")]
[assembly: AssemblyFileVersion("1.0.0.0")]

#if AMD_TEMPLATE
[assembly: ScriptTemplate(@"
// {name}.js {version}
// {description}
// {copyright}
//

""use strict"";

define('{name}', [{requires}], function({dependencies}) {
  var $global = this;

  {script}
  return $exports;
});

// Generated with Script# {compiler}
")]
#endif

#if SIMPLE_TEMPLATE
[assembly: ScriptTemplate(@"
// {name}.js
// Sample script...
""use strict"";

(function($global) {
  {dependenciesLookup}

  {script}
  return $exports;
})(this);
")]
#endif


namespace Basic {

    public class EventArgs {

        [ScriptName(PreserveCase = true)]
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

        public static void Main(IDictionary args) {
            App theApp = new App();

            theApp._btn1.performClick();
            theApp._btn2.performClick();
        }
    }
}
