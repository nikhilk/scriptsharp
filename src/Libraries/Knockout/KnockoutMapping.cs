// KnockoutMapping.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace KnockoutApi {

    /// <summary>
    /// Provides functionality for mapping between knockout models and JSON or
    /// vanilla script objects.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class KnockoutMapping {

        private KnockoutMapping() {
        }

        /// <summary>
        /// Creates a model instance from the specified JSON string.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="jsonData">The JSON data.</param>
        /// <returns>A new instance of the model.</returns>
        [ScriptName("fromJSON")]
        public TModel ModelFromJson<TModel>(string jsonData) {
            return default(TModel);
        }

        /// <summary>
        /// Creates a model instance from the specified JSON string and a
        /// custom mapping.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="jsonData">The JSON data.</param>
        /// <param name="mapping">The mapping rules to apply.</param>
        /// <returns>A new instance of the model.</returns>
        [ScriptName("fromJSON")]
        public TModel ModelFromJson<TModel>(string jsonData, KnockoutMappingSpecification mapping) {
            return default(TModel);
        }

        /// <summary>
        /// Creates a model array from the specified JSON string and a
        /// custom mapping.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="jsonData">The JSON data.</param>
        /// <param name="mapping">The mapping rules to apply.</param>
        /// <returns>A new instance of the model.</returns>
        [ScriptName("fromJSON")]
        public ObservableArray<TModel> ModelFromJson<TModel>(string jsonData, KnockoutMappingArraySpecification mapping) {
            return null;
        }

        /// <summary>
        /// Creates a model instance from the specified script object.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="data">The vanilla script object.</param>
        /// <returns>A new instance of the model.</returns>
        [ScriptName("fromJS")]
        public TModel ModelFromObject<TModel>(object data) {
            return default(TModel);
        }

        /// <summary>
        /// Creates a model instance from the specified script object and a
        /// custom mapping.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="data">The vanilla script object.</param>
        /// <param name="mapping">The mapping rules to apply.</param>
        /// <returns>A new instance of the model.</returns>
        [ScriptName("fromJS")]
        public TModel ModelFromObject<TModel>(object data, KnockoutMappingSpecification mapping) {
            return default(TModel);
        }

        /// <summary>
        /// Creates a model array from the specified script object and a
        /// custom mapping.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="data">The vanilla script object.</param>
        /// <param name="mapping">The mapping rules to apply.</param>
        /// <returns>A new instance of the model.</returns>
        [ScriptName("fromJS")]
        public Observable<TModel> ModelFromObject<TModel>(object data, KnockoutMappingArraySpecification<TModel> mapping) {
            return null;
        }

        /// <summary>
        /// Updates a model instance from the specified script object and a
        /// custom mapping.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="data">The vanilla script object.</param>
        /// <param name="mapping">The mapping rules to apply.</param>
        /// <param name="target">The mapping rules to apply.</param>
        /// <returns>A new instance of the model.</returns>
        [ScriptName("fromJS")]
        public TModel ModelFromObject<TModel>(object data, KnockoutMappingSpecification mapping, TModel target) {
            return default(TModel);
        }

        /// <summary>
        /// Creates a model array from the specified script object and a
        /// custom mapping.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="data">The vanilla script object.</param>
        /// <param name="mapping">The mapping rules to apply.</param>
        /// <param name="target">The mapping rules to apply.</param>
        /// <returns>A new instance of the model.</returns>
        [ScriptName("fromJS")]
        public Observable<TModel> ModelFromObject<TModel>(object data, KnockoutMappingArraySpecification<TModel> mapping, ObservableArray<TModel> target) {
            return null;
        }

        /// <summary>
        /// Unwraps the given view model
        /// </summary>
        /// <param name="model">The model to unwrap</param>
        /// <returns>The unwrapped view model</returns>
        [ScriptName("toJS")]
        public object ModelToObject(object model) {
            return null;
        }

        /// <summary>
        /// Unwraps the given view model
        /// </summary>
        /// <param name="model">The model to unwrap</param>
        /// <returns>The unwrapped view model</returns>
        [ScriptName("toJS")]
        public T ModelToObject<T>(object model) {
            return default(T);
        }

        /// <summary>
        /// Updates the specified model with the specified JSON string.
        /// </summary>
        /// <typeparam name="TModel">The tyoe of the model.</typeparam>
        /// <param name="model">The model to update.</param>
        /// <param name="jsonData">The JSON string representing the new values.</param>
        [ScriptName("updateFromJSON")]
        public void UpdateFromJson<TModel>(TModel model, string jsonData) {
        }

        /// <summary>
        /// Updates the specified model with the specified script object.
        /// </summary>
        /// <typeparam name="TModel">The tyoe of the model.</typeparam>
        /// <param name="model">The model to update.</param>
        /// <param name="data">The script object representing the new values.</param>
        [ScriptName("updateFromJS")]
        public void UpdateFromObject<TModel>(TModel model, object data) {
        }
    }
}
