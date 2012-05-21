// StateMergeMode.cs
// Script#/Libraries/jQuery/History
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.History {

    /// <summary>
    /// Specifies how new state is merged into the current state.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    [NumericValues]
    public enum StateMergeMode {

        /// <summary>
        /// Merge new values from the specified state, and override any current
        /// state values.
        /// </summary>
        Merge = 0,

        /// <summary>
        /// Merge new values from the specified state, but keep current state values
        /// </summary>
        MergeKeepCurrent = 1,

        /// <summary>
        /// Replace the current state with the specified state.
        /// </summary>
        ReplaceCurrentState = 2
    }
}
