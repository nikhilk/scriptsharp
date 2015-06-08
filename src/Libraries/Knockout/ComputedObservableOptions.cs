// ComputedObservableOptions.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace KnockoutApi {

    /// <summary>
    /// Provides advanced options for defining a dependent observable.
    /// </summary>
    /// <typeparam name="T">The type of the observable value.</typeparam>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class ComputedObservableOptions<T> {

        public ComputedObservableOptions() {
        }

        public ComputedObservableOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// Gets or sets whether the evaluation should be deferred, i.e. not
        /// performed when the observable is first created.
        /// </summary>
        [ScriptField]
        public bool DeferEvaluation {
            get;
            set;
        }

        /// <summary>
        /// Pass in a function that evaluates when the Dependency can be disposed
        /// </summary>
        [ScriptField]
        public Func<bool> DisposeWhen {
            get;
            set;
        }

        /// <summary>
        /// "disposeWhenNodeIsRemoved" option both proactively disposes as soon as the node is removed using ko.removeNode(),    
        /// plus adds a "disposeWhen" callback that, on each evaluation, disposes if the node was removed by some other means.
        /// </summary>
        [ScriptField]
        public object DisposeWhenNodeIsRemoved {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the function to compute the value.
        /// </summary>
        [ScriptName("read")]
        [ScriptField]
        public Func<T> GetValueFunction {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the function to write the value.
        /// </summary>
        [ScriptName("write")]
        [ScriptField]
        public Action<T> SetValueFunction {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the function to write the value.
        /// </summary>
        [ScriptName("write")]
        [ScriptField]
        public Action<T[]> SetArrayValueFunction {
            get;
            set;
        }

        /// <summary>
        /// Gets the model instance which acts as 'this' in the get value function.
        /// </summary>
        [ScriptName("owner")]
        [ScriptField]
        public object Model {
            get;
            set;
        }
    }
}
