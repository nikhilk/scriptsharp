// SuppressMessageAttribute.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Diagnostics.CodeAnalysis {

    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    [NonScriptable]
    [Imported]
    public sealed class SuppressMessageAttribute : Attribute {

        private string _category;
        private string _checkId;
        private string _scope;
        private string _target;
        private string _messageId;
        private string _justification;

        public SuppressMessageAttribute(string category, string checkId) {
            _category = category;
            _checkId = checkId;
        }

        public string Category {
            get {
                return _category;
            }
        }

        public string CheckId {
            get {
                return _checkId;
            }
        }

        public string Justification {
            get {
                return _justification;
            }
            set {
                _justification = value;
            }
        }

        public string Scope {
            get {
                return _scope;
            }
            set {
                _scope = value;
            }
        }

        public string Target {
            get {
                return _target;
            }
            set {
                _target = value;
            }
        }

        public string MessageId {
            get {
                return _messageId;
            }
            set {
                _messageId = value;
            }
        }
    }
}
