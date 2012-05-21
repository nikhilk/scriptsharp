// Range.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Editing {

    [IgnoreNamespace]
    [Imported]
    public abstract class Range {

        internal Range() {
        }

        public bool ExecCommand(string command, bool displayUserInterface, object value) {
            return false;
        }

        public bool QueryCommandEnabled(string command) {
            return false;
        }

        public bool QueryCommandIndeterm(string command) {
            return false;
        }

        public bool QueryCommandState(string command) {
            return false;
        }

        public bool QueryCommandSupported(string command) {
            return false;
        }

        public object QueryCommandValue(string command) {
            return null;
        }

        public void ScrollIntoView(bool alignToTop) {
        }

        public void Select() {
        }
    }
}
