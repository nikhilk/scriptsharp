// RoleEnvironment.cs
// Script#/Libraries/Node/Azure
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NodeApi.WindowsAzure.Runtime {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class RoleEnvironment {

        private RoleEnvironment() {
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<RoleEvent[]> Changed {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action<RoleEvent[]> Changing {
            add {
            }
            remove {
            }
        }

        public void ClearStatus(AsyncCallback callback) {
        }

        public void GetConfigurationSettings(AsyncResultCallback<Dictionary<string, string>> callback) {
        }

        public void GetCurrentRoleInstance(AsyncResultCallback<RoleInstance> callback) {
        }

        [ScriptName("getDeploymentId")]
        public void GetDeploymentID(AsyncResultCallback<string> callback) {
        }

        public void GetRoles(AsyncResultCallback<Role[]> callback) {
        }

        public void IsAvailable(AsyncResultCallback<bool> callback) {
        }

        public void IsEmulated(AsyncResultCallback<bool> callback) {
        }

        public void RequestRecycle(AsyncCallback callback) { 
        }

        public void SetStatus(RoleStatus status, Date expirationDate, AsyncCallback callback) {
        }
    }
}
