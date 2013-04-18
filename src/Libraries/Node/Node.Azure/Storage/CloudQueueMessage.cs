// CloudQueueMessage.cs
// Script#/Libraries/Node/Azure
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.WindowsAzure.Storage {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class CloudQueueMessage {

        private CloudQueueMessage() {
        }

        [ScriptField]
        [ScriptName("messageid")]
        public string MessageID {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("messagetext")]
        public string MessageText {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("popreceipt")]
        public string PopReceipt {
            get {
                return null;
            }
        }
    }
}
