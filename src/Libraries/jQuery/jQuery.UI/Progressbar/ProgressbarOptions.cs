// ProgressbarOptions.cs
// Script#/Libraries/jQuery/jQuery.UI/Progressbar
// Auto-generated code!
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI
{
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class ProgressbarOptions
    {
        public ProgressbarOptions() { }
        public ProgressbarOptions(params object[] nameValuePairs) { }

        #region Events

        /// <summary>
        /// This event is triggered when progressbar is created.
        /// </summary>
        [IntrinsicProperty]
        public jQueryEventHandler Create { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when the value of the progressbar changes.
        /// </summary>
        [IntrinsicProperty]
        public ProgressbarEventHandler Change { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when the value of the progressbar reaches the maximum value of 100.
        /// </summary>
        [IntrinsicProperty]
        public ProgressbarEventHandler Complete { get { return null; } set { } }

        #endregion

        #region Options

        /// <summary>
        /// Disables (true) or enables (false) the progressbar. Can be set when initialising (first creating) the progressbar.
        /// </summary>
        [IntrinsicProperty]
        public bool Disabled { get { return false; } set { } }

        /// <summary>
        /// The value of the progressbar.
        /// </summary>
        [IntrinsicProperty]
        public int Value { get { return 0; } set { } }

        #endregion
    }
}
