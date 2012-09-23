// jQueryValidatorOptions.cs
// Script#/Libraries/jQuery/Validation
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace jQueryApi.Validation {

    [ScriptImport]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class jQueryValidatorOptions {

        [ScriptProperty]
        public bool Debug {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptProperty]
        public string ErrorClass {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public string ErrorContainer {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public string ErrorElement {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public string ErrorLabelContainer {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public bool FocusCleanup {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptProperty]
        public bool FocusInvalid {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptProperty]
        public Dictionary Groups {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        [ScriptName("ignore")]
        public string IgnoreSelector {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public Action<jQueryEvent, jQueryValidator> InvalidHandler {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public Dictionary Messages {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public string Meta {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public Dictionary Rules {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public Action<jQueryObject> SubmitHandler {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        [ScriptName("onclick")]
        public bool ValidateOnClick {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptProperty]
        [ScriptName("onfocusout")]
        public bool ValidateOnFocusOut {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptProperty]
        [ScriptName("onkeyup")]
        public bool ValidateOnKeyUp {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptProperty]
        [ScriptName("onsubmit")]
        public bool ValidateOnSubmit {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptProperty]
        public string ValidClass {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public string Wrapper {
            get {
                return null;
            }
            set {
            }
        }
    }
}
