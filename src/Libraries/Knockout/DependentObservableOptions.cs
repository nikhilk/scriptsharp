// DependentObservableOptions.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace KnockoutApi {

    /// <summary>
    /// Provides advanced options for defining a dependent observable.
    /// </summary>
    /// <typeparam name="T">The type of the observable value.</typeparam>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class DependentObservableOptions<T> {

        /// <summary>
        /// Gets or sets whether the evaluation should be deferred, i.e. not
        /// performed when the observable is first created.
        /// </summary>
        [IntrinsicProperty]
        public bool DeferEvaluation {
            get;
            set;
        }

        /// <summary>
        /// Pass in a function that evaluates when the Dependency can be disposed
        /// </summary>
        [IntrinsicProperty]
        public Func<bool> DisposeWhen {
            get;
            set;
        }

        /// <summary>
        /// "disposeWhenNodeIsRemoved" option both proactively disposes as soon as the node is removed using ko.removeNode(),    
        /// plus adds a "disposeWhen" callback that, on each evaluation, disposes if the node was removed by some other means.
        /// </summary>
        [IntrinsicProperty]
        public object DisposeWhenNodeIsRemoved {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the function to compute the value.
        /// </summary>
        [ScriptName("read")]
        [IntrinsicProperty]
        public Func<T> GetValueFunction {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the function to write the value.
        /// </summary>
        [ScriptName("write")]
        [IntrinsicProperty]
        public Action<T> SetValueFunction { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the function to write the value.
        /// </summary>
        [ScriptName("write")]
        [IntrinsicProperty]
        public Action<T[]> SetArrayValueFunction { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets the model instance which acts as 'this' in the get value function.
        /// </summary>
        [ScriptName("owner")]
        [IntrinsicProperty]
        public object Model {
            get;
            set;
        }
    }
}
