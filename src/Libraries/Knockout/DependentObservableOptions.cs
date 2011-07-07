// DependentObservableOptions.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
        /// Gets or sets the function to compute the value.
        /// </summary>
        [ScriptName("read")]
        [IntrinsicProperty]
        public Func<T> GetValueFunction {
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
