// Selection.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace System.Html.Editing {

    /// <summary>
    /// Represents the active selection, which is a highlighted block of text, and/or other elements in the document on which a user or a script
    /// can carry out some action.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public sealed class Selection {

        private Selection() {
        }

        [IntrinsicProperty]
        public string Type {
            get {
                return null;
            }
        }

        public void Clear() {
        }

        public Range CreateRange() {
            return null;
        }

        public void Empty() {
        }
    }
}
