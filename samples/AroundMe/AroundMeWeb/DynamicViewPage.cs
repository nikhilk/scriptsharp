// DynamicViewPage.cs
//

using System;
using System.Dynamic;
using System.Reflection;

namespace System.Web.Mvc {

    public class DynamicViewPage : ViewPage {

        public new dynamic Model {
            get;
            private set;
        }

        protected override void SetViewData(ViewDataDictionary viewData) {
            base.SetViewData(viewData);
            Model = new ReflectionDynamicObject(ViewData.Model);
        }


        private sealed class ReflectionDynamicObject : DynamicObject {

            private object _wrappedObject;

            public ReflectionDynamicObject(object o) {
                _wrappedObject = o;
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result) {
                BindingFlags bindingFlags =
                    BindingFlags.GetProperty | BindingFlags.Instance |
                    BindingFlags.Public | BindingFlags.NonPublic;

                result = _wrappedObject.GetType().InvokeMember(binder.Name, bindingFlags, null, _wrappedObject, null);

                return true;
            }
        }
    }
}
