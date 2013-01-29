// FileReader.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Html.Data.Files {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class FileReader {

        [ScriptField]
        public FileError Error {
            get {
                return null;
            }
        }

        /// <summary>
        /// Indicates the state of the FileReader. This will be one of the State constants. Read only.
        /// </summary>
        [ScriptField]
        public int ReadyState {
            get {
                return (int)FileReadyState.Empty;
            }
        }

        // File or Blob data
        [ScriptField]
        public object Result {
            get {
                return null;
            }
        }

        [ScriptName("onabort")]
        public Action<FileProgressEvent> OnAbort {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptName("onerror")]
        public Action<FileProgressEvent> OnError {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptName("onload")]
        public Action<FileProgressEvent> OnLoad {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptName("onloadend")]
        public Action<FileProgressEvent> OnLoadEnd {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptName("onloadstart")]
        public Action<FileProgressEvent> OnLoadStart {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptName("onprogress")]
        public Action<FileProgressEvent> OnProgress {
            get {
                return null;
            }
            set {
            }
        }

        public void Abort() {
        }

        /// <summary>
        /// Adds a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        /// <param name="useCapture">Whether the listener wants to initiate capturing the event.</param>
        public void AddEventListener(string eventName, ElementEventListener listener, bool useCapture) {
        }

        /// <summary>
        ///     Adds a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="handler">The handler to be invoked in response to the event.</param>
        /// <param name="useCapture">Whether the handler wants to initiate capturing the event.</param>
        public void AddEventListener(string eventName, IElementEventHandler handler, bool useCapture) {
        }

        public bool DispatchEvent(MutableEvent eventObject) {
            return false;
        }
        
        public void ReadAsArrayBuffer(Blob blob) {
        }

        public void ReadAsBinaryString(Blob blob) {
        }

        public void ReadAsDataURL(Blob blob) {
        }

        public void ReadAsText(Blob blob) {
        }

        public void ReadAsText(Blob blob, string encoding) {
        }

        /// <summary>
        /// Removes a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        /// <param name="useCapture">Whether the listener wants to initiate capturing the event.</param>
        public void RemoveEventListener(string eventName, ElementEventListener listener, bool useCapture) {
        }

        /// <summary>
        /// Removes a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="handler">The handler to be invoked in response to the event.</param>
        /// <param name="useCapture">Whether the handler wants to initiate capturing the event.</param>
        public void RemoveEventListener(string eventName, IElementEventHandler handler, bool useCapture) {
        }
    }
}
