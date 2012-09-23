// Task.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Threading {

    [Imported]
    public class Task {

        internal Task() {
        }

        public bool Completed {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public Exception Error {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public TaskStatus Status {
            get {
                return TaskStatus.Pending;
            }
        }

        public static Task<bool> All(params Task[] tasks) {
            return null;
        }

        public static Task<bool> All(int timeout, params Task[] tasks) {
            return null;
        }

        public static Task<Task> Any(params Task[] tasks) {
            return null;
        }

        public static Task<Task> Any(int timeout, params Task[] tasks) {
            return null;
        }

        public Task ContinueWith(Action<Task> continuation) {
            return null;
        }

        public static Task Delay(int timeout) {
            return null;
        }

        public Task Done(Action callback) {
            return null;
        }

        public Task Fail(Action<Exception> callback) {
            return null;
        }

        public Task Then(Action doneCallback, Action<Exception> failCallback) {
            return null;
        }
    }

    [Imported]
    [ScriptName("Task")]
    public sealed class Task<T> : Task {

        internal Task() {
        }

        [ScriptProperty]
        public T Result {
            get {
                return default(T);
            }
        }

        public Task<T> ContinueWith(Action<Task<T>> continuation) {
            return null;
        }

        public Task<T> Done(Action<T> callback) {
            return null;
        }
    }
}
