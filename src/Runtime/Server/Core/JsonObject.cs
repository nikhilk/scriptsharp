// JsonObject.cs
// Script#/Runtime/Server
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;

namespace ScriptSharp.Web.Core {

    internal sealed class JsonObject : DynamicObject, IDictionary<string, object>, IDictionary {

        private Dictionary<string, object> _members;

        public JsonObject() {
            _members = new Dictionary<string, object>();
        }

        public JsonObject(params object[] nameValuePairs)
            : this() {
            if (nameValuePairs != null) {
                if (nameValuePairs.Length % 2 != 0) {
                    throw new ArgumentException("Mismatch in name/value pairs.");
                }

                for (int i = 0; i < nameValuePairs.Length; i += 2) {
                    if (!(nameValuePairs[i] is string)) {
                        throw new ArgumentException("Name parameters must be strings.");
                    }

                    _members[(string)nameValuePairs[i]] = nameValuePairs[i + 1];
                }
            }
        }

        public object this[string key] {
            get {
                return ((IDictionary<string, object>)this)[key];
            }
            set {
                ((IDictionary<string, object>)this)[key] = value;
            }
        }

        public bool ContainsKey(string key) {
            return ((IDictionary<string, object>)this).ContainsKey(key);
        }

        public override bool TryConvert(ConvertBinder binder, out object result) {
            Type targetType = binder.Type;

            if ((targetType == typeof(IEnumerable)) ||
                (targetType == typeof(IEnumerable<KeyValuePair<string, object>>)) ||
                (targetType == typeof(IDictionary<string, object>)) ||
                (targetType == typeof(IDictionary))) {
                result = this;
                return true;
            }

            return base.TryConvert(binder, out result);
        }

        public override bool TryDeleteMember(DeleteMemberBinder binder) {
            return _members.Remove(binder.Name);
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
            if (indexes.Length == 1) {
                result = ((IDictionary<string, object>)this)[(string)indexes[0]];
                return true;
            }

            return base.TryGetIndex(binder, indexes, out result);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            object value;
            if (_members.TryGetValue(binder.Name, out value)) {
                result = value;
                return true;
            }
            return base.TryGetMember(binder, out result);
        }

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value) {
            if (indexes.Length == 1) {
                ((IDictionary<string, object>)this)[(string)indexes[0]] = value;
                return true;
            }

            return base.TrySetIndex(binder, indexes, value);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value) {
            _members[binder.Name] = value;
            return true;
        }

        #region Implementation of IEnumerable
        IEnumerator IEnumerable.GetEnumerator() {
            return new DictionaryEnumerator(_members.GetEnumerator());
        }
        #endregion

        #region Implementation of IEnumerable<KeyValuePair<string, object>>
        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator() {
            return _members.GetEnumerator();
        }
        #endregion

        #region Implementation of ICollection
        int ICollection.Count {
            get {
                return _members.Count;
            }
        }

        bool ICollection.IsSynchronized {
            get {
                return false;
            }
        }

        object ICollection.SyncRoot {
            get {
                return this;
            }
        }

        void ICollection.CopyTo(Array array, int index) {
            throw new NotImplementedException();
        }
        #endregion

        #region Implementation of ICollection<KeyValuePair<string, object>>
        int ICollection<KeyValuePair<string, object>>.Count {
            get {
                return _members.Count;
            }
        }

        bool ICollection<KeyValuePair<string, object>>.IsReadOnly {
            get {
                return false;
            }
        }

        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item) {
            ((IDictionary<string, object>)_members).Add(item);
        }

        void ICollection<KeyValuePair<string, object>>.Clear() {
            _members.Clear();
        }

        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item) {
            return ((IDictionary<string, object>)_members).Contains(item);
        }

        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) {
            ((IDictionary<string, object>)_members).CopyTo(array, arrayIndex);
        }

        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item) {
            return ((IDictionary<string, object>)_members).Remove(item);
        }
        #endregion

        #region Implementation of IDictionary
        bool IDictionary.IsFixedSize {
            get {
                return false;
            }
        }

        bool IDictionary.IsReadOnly {
            get {
                return false;
            }
        }

        ICollection IDictionary.Keys {
            get {
                return _members.Keys;
            }
        }

        object IDictionary.this[object key] {
            get {
                return ((IDictionary<string, object>)this)[(string)key];
            }
            set {
                ((IDictionary<string, object>)this)[(string)key] = value;
            }
        }

        ICollection IDictionary.Values {
            get {
                return _members.Values;
            }
        }

        void IDictionary.Add(object key, object value) {
            _members.Add((string)key, value);
        }

        void IDictionary.Clear() {
            _members.Clear();
        }

        bool IDictionary.Contains(object key) {
            return _members.ContainsKey((string)key);
        }

        IDictionaryEnumerator IDictionary.GetEnumerator() {
            return (IDictionaryEnumerator)((IEnumerable)this).GetEnumerator();
        }

        void IDictionary.Remove(object key) {
            _members.Remove((string)key);
        }
        #endregion

        #region Implementation of IDictionary<string, object>
        ICollection<string> IDictionary<string, object>.Keys {
            get {
                return _members.Keys;
            }
        }

        object IDictionary<string, object>.this[string key] {
            get {
                object value = null;
                if (_members.TryGetValue(key, out value)) {
                    return value;
                }
                return null;
            }
            set {
                _members[key] = value;
            }
        }

        ICollection<object> IDictionary<string, object>.Values {
            get {
                return _members.Values;
            }
        }

        void IDictionary<string, object>.Add(string key, object value) {
            _members.Add(key, value);
        }

        bool IDictionary<string, object>.ContainsKey(string key) {
            return _members.ContainsKey(key);
        }

        bool IDictionary<string, object>.Remove(string key) {
            return _members.Remove(key);
        }

        bool IDictionary<string, object>.TryGetValue(string key, out object value) {
            return _members.TryGetValue(key, out value);
        }
        #endregion


        private sealed class DictionaryEnumerator : IDictionaryEnumerator {

            private IEnumerator<KeyValuePair<string, object>> _enumerator;

            public DictionaryEnumerator(IEnumerator<KeyValuePair<string, object>> enumerator) {
                _enumerator = enumerator;
            }

            public object Current {
                get {
                    return Entry;
                }
            }

            public DictionaryEntry Entry {
                get {
                    return new DictionaryEntry(_enumerator.Current.Key, _enumerator.Current.Value);
                }
            }

            public object Key {
                get {
                    return _enumerator.Current.Key;
                }
            }

            public object Value {
                get {
                    return _enumerator.Current.Value;
                }
            }

            public bool MoveNext() {
                return _enumerator.MoveNext();
            }

            public void Reset() {
                _enumerator.Reset();
            }
        }
    }
}
