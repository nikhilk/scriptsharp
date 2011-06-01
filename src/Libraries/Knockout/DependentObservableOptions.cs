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
    public class DependentObservableOptions<T> {
        /// <summary>
        /// A function to compute the value.
        /// </summary>
        [ScriptName("read")]
        [IntrinsicProperty]
        public Func<T> GetValueFunction { get; set; }

        /// <summary>
        /// The model instance which acts as 'this' in the get value function.
        /// </summary>
        [ScriptName("owner")]
        [IntrinsicProperty]
        public object Model { get; set; }

        /// <summary>
        /// If true, evaluation is not performed when the observable is first created, which can be useful if it relies on state which may not be ready.
        /// </summary>
        [IntrinsicProperty]
        public bool DeferEvaluation { get; set; }
    }
}
