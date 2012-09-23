// jQueryValidationRules.cs
// Script#/Libraries/jQuery/Validation
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.Validation {

    [ScriptImport]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class jQueryValidationRules {

        private jQueryValidationRules() {
        }

        /// <summary>
        /// Makes the element require a certain file extension
        /// </summary>
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
        public bool Number {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
        public bool Url {
            get {
                return false;
            }
            set {
            }
        }
    }
}
