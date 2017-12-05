// Process.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using NodeApi.IO;

namespace NodeApi.Compute {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptDependency("child_process")]
    [ScriptName("child_process")]
    public sealed class ChildProcess : IEventEmitter {

        private ChildProcess() {
        }

        [ScriptName("pid")]
        [ScriptField]
        public int ProcessID {
            get {
                return 0;
            }
        }

        [ScriptName("stderr")]
        [ScriptField]
        public ReadableStream StandardError {
            get {
                return null;
            }
        }

        [ScriptName("stdin")]
        [ScriptField]
        public WritableStream StandardInput {
            get {
                return null;
            }
        }

        [ScriptName("stdout")]
        [ScriptField]
        public ReadableStream StandardOutput {
            get {
                return null;
            }
        }

        public void Disconnect() {
        }

        public static ChildProcess Exec(string command, AsyncResultCallback<ReadableStream, ReadableStream> callback) {
            return null;
        }

        public static ChildProcess Exec(string command, object options, AsyncResultCallback<ReadableStream, ReadableStream> callback) {
            return null;
        }

        public static ChildProcess ExecFile(string command, string[] args, object options, AsyncResultCallback<ReadableStream, ReadableStream> callback) {
            return null;
        }

        public void Kill() {
        }

        public void Kill(string signal) {
        }

        public static ChildProcess Fork(string command, string[] args, object options) {
            return null;
        }

        public void Send(object message) {
        }

        public static ChildProcess Spawn(string command) {
            return null;
        }

        public static ChildProcess Spawn(string command, string[] args) {
            return null;
        }

        public static ChildProcess Spawn(string command, string[] args, object options) {
            return null;
        }
    }
}
