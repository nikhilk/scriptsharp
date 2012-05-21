// jQueryValidationRules.cs
// Script#/Libraries/jQuery/Validation
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.Validation {

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class jQueryValidationRules {

        private jQueryValidationRules() {
        }

        /// <summary>
        /// Makes the element require a certain file extension
        /// </summary>
        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
        public bool Number {
            get {
                return false;
            }
            set {
            }
        }

        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
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
        [IntrinsicProperty]
        public bool Url {
            get {
                return false;
            }
            set {
            }
        }
    }
}
