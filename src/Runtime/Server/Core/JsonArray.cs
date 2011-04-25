// JsonArray.cs
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

    internal sealed class JsonArray : DynamicObject, ICollection<object>, ICollection {

        private List<object> _members;

        public JsonArray() {
            _members = new List<object>();
        }

        public JsonArray(object o)
            : this() {
            _members.Add(o);
        }

        public JsonArray(object o1, object o2)
            : this() {
            _members.Add(o1);
            _members.Add(o2);
        }

        public JsonArray(params object[] objects)
            : this() {
            _members.AddRange(objects);
        }

        public int Count {
            get {
                return _members.Count;
            }
        }

        public object this[int index] {
            get {
                return _members[index];
            }
        }

        public override bool TryConvert(ConvertBinder binder, out object result) {
            Type targetType = binder.Type;

            if ((targetType == typeof(IEnumerable)) ||
                (targetType == typeof(IEnumerable<object>)) ||
                (targetType == typeof(ICollection<object>)) ||
                (targetType == typeof(ICollection))) {
                result = this;
                return true;
            }

            return base.TryConvert(binder, out result);
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) {
            if (String.Compare(binder.Name, "Add", StringComparison.Ordinal) == 0) {
                if (args.Length == 1) {
                    _members.Add(args[0]);
                    result = null;
                    return true;
                }
                result = null;
                return false;
            }
            else if (String.Compare(binder.Name, "Insert", StringComparison.Ordinal) == 0) {
                if (args.Length == 2) {
                    _members.Insert(Convert.ToInt32(args[0]), args[1]);
                    result = null;
                    return true;
                }
                result = null;
                return false;
            }
            else if (String.Compare(binder.Name, "IndexOf", StringComparison.Ordinal) == 0) {
                if (args.Length == 1) {
                    result = _members.IndexOf(args[0]);
                    return true;
                }
                result = null;
                return false;
            }
            else if (String.Compare(binder.Name, "Clear", StringComparison.Ordinal) == 0) {
                if (args.Length == 0) {
                    _members.Clear();
                    result = null;
                    return true;
                }
                result = null;
                return false;
            }
            else if (String.Compare(binder.Name, "Remove", StringComparison.Ordinal) == 0) {
                if (args.Length == 1) {
                    result = _members.Remove(args[0]);
                    return true;
                }
                result = null;
                return false;
            }
            else if (String.Compare(binder.Name, "RemoveAt", StringComparison.Ordinal) == 0) {
                if (args.Length == 1) {
                    _members.RemoveAt(Convert.ToInt32(args[0]));
                    result = null;
                    return true;
                }
                result = null;
                return false;
            }

            return base.TryInvokeMember(binder, args, out result);
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
            if (indexes.Length == 1) {
                result = _members[Convert.ToInt32(indexes[0])];
                return true;
            }

            return base.TryGetIndex(binder, indexes, out result);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            if (String.Compare("Length", binder.Name, StringComparison.Ordinal) == 0) {
                result = _members.Count;
                return true;
            }

            return base.TryGetMember(binder, out result);
        }

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value) {
            if (indexes.Length == 1) {
                _members[Convert.ToInt32(indexes[0])] = value;
                return true;
            }

            return base.TrySetIndex(binder, indexes, value);
        }

        #region Implementation of IEnumerable
        IEnumerator IEnumerable.GetEnumerator() {
            return _members.GetEnumerator();
        }
        #endregion

        #region Implementation of IEnumerable<object>
        IEnumerator<object> IEnumerable<object>.GetEnumerator() {
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

        #region Implementation of ICollection<object>
        int ICollection<object>.Count {
            get {
                return _members.Count;
            }
        }

        bool ICollection<object>.IsReadOnly {
            get {
                return false;
            }
        }

        void ICollection<object>.Add(object item) {
            ((ICollection<object>)_members).Add(item);
        }

        void ICollection<object>.Clear() {
            ((ICollection<object>)_members).Clear();
        }

        bool ICollection<object>.Contains(object item) {
            return ((ICollection<object>)_members).Contains(item);
        }

        void ICollection<object>.CopyTo(object[] array, int arrayIndex) {
            ((ICollection<object>)_members).CopyTo(array, arrayIndex);
        }

        bool ICollection<object>.Remove(object item) {
            return ((ICollection<object>)_members).Remove(item);
        }
        #endregion
    }
}
