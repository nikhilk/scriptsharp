// jQueryValidatorOptions.cs
// Script#/Libraries/jQuery/Validation
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace jQueryApi.Validation {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class jQueryValidatorOptions {

        [ScriptField]
        public bool Debug {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public string ErrorClass {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string ErrorContainer {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string ErrorElement {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string ErrorLabelContainer {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public bool FocusCleanup {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public bool FocusInvalid {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public Dictionary Groups {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public jQueryValidationHighlight Highlight {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        [ScriptName("ignore")]
        public string IgnoreSelector {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string IgnoreTitle {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public Action<jQueryEvent, jQueryValidator> InvalidHandler {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public Dictionary Messages {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string Meta {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public Dictionary Rules {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public Action<jQueryObject> SubmitHandler {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public jQueryValidationHighlight Unhighlight {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        [ScriptName("onclick")]
        public bool ValidateOnClick {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        [ScriptName("onfocusout")]
        public bool ValidateOnFocusOut {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        [ScriptName("onkeyup")]
        public bool ValidateOnKeyUp {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        [ScriptName("onsubmit")]
        public bool ValidateOnSubmit {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public string ValidClass {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string Wrapper {
            get {
                return null;
            }
            set {
            }
        }
    }
}
