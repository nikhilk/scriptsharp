// jQueryValidationRules.cs
// Script#/Libraries/jQuery/Validation
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.Validation {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class jQueryValidationRules {

        private jQueryValidationRules() {
        }

        /// <summary>
        /// Makes the element require a certain file extension
        /// </summary>
        [ScriptField]
        public string Accept {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the element require a creditcard number
        /// </summary>
        [ScriptField]
        [ScriptName("creditcard")]
        public bool CreditCard {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the element require a date
        /// </summary>
        [ScriptField]
        public bool Date {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the element require a ISO date
        /// </summary>
        [ScriptField]
        [ScriptName("dateISO")]
        public bool DateISO {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the element require digits only
        /// </summary>
        [ScriptField]
        public bool Digits {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the element require a valid email address
        /// </summary>
        [ScriptField]
        public bool Email {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Requires the element to be the same as another one
        /// </summary>
        [ScriptField]
        public string EqualTo {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the element require a given maximum
        /// </summary>
        [ScriptField]
        public int Max {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the element require a given maximum length
        /// </summary>
        [ScriptField]
        public int MaxLength {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the element require given minimum
        /// </summary>
        [ScriptField]
        public int Min {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the element require a given minimum length
        /// </summary>
        [ScriptField]
        public int MinLength {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the element require a decimal number
        /// </summary>
        [ScriptField]
        public bool Number {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        [ScriptName("phoneUS")]
        public bool PhoneUS {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the value require a given value range
        /// </summary>
        [ScriptField]
        public int[] Range {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the element require a given value range
        /// </summary>
        [ScriptField]
        public int[] RangeLength {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Requests a resource to check the element for validity
        /// </summary>
        [ScriptField]
        public object Remote {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the element required, depending on the result of the given callback
        /// </summary>
        [ScriptField]
        [ScriptName("required")]
        public Func<bool> RequiredCallback {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the element required, depending on the result of the given expression
        /// </summary>
        [ScriptField]
        [ScriptName("required")]
        public string RequiredExpression {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the element always required
        /// </summary>
        [ScriptField]
        public bool Required {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Makes the element require a valid url
        /// </summary>
        [ScriptField]
        public bool Url {
            get {
                return false;
            }
            set {
            }
        }
    }
}
