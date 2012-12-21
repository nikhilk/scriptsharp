// BinderManager.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Html;

namespace Sharpen {

    internal sealed class BinderManager : Behavior {

        internal const string BehaviorName = "binderManager";

        private object _model;
        private List<Binder> _binders;

        public BinderManager() {
            _binders = new List<Binder>();
        }

        public object Model {
            get {
                return _model;
            }
            set {
                _model = value;
            }
        }

        public void AddBinder(Binder binder) {
            Debug.Assert(_binders != null);
            Debug.Assert(binder != null);

            _binders.Add(binder);
        }

        public override void Dispose() {
            foreach (Binder binder in _binders) {
                binder.Dispose();
            }
            _binders = null;

            base.Dispose();
        }
    }
}
