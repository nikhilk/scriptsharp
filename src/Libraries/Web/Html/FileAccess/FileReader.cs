// FileReader.cs
// Script#/Libraries/Web/
// This source code is subject to terms and conditions of the Apache License, Version 2.0.

using System.Runtime.CompilerServices;

namespace System.Html.FileAccess {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class FileReader {

        [ScriptName(PreserveCase = true)] 
        [CLSCompliant(false)] 
        public const ushort EMPTY = 0;

        [ScriptName(PreserveCase = true)] 
        [CLSCompliant(false)] 
        public const ushort LOADING = 1;

        [ScriptName(PreserveCase = true)] 
        [CLSCompliant(false)] 
        public const ushort DONE = 2;

        [ScriptField]
        public DOMError Error {
            get {
                return null;
            }
        }

        /// <summary>
        /// Indicates the state of the FileReader. This will be one of the State constants. Read only.
        /// </summary>
        [CLSCompliant(false)]
        [ScriptField]
        public ushort ReadyState {
            get {
                return EMPTY;
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
        public Action<ProgressEvent> OnAbort;

        [ScriptName("onerror")]
        public Action<ProgressEvent> OnError;

        [ScriptName("onload")]
        public Action<ProgressEvent> OnLoad;

        [ScriptName("onloadend")]
        public Action<ProgressEvent> OnLoadEnd;

        [ScriptName("onloadstart")]
        public Action<ProgressEvent> OnLoadStart;

        [ScriptName("onprogress")]
        public Action<ProgressEvent> OnProgress;

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

        public void ReadAsText(Blob blob, String encoding) {
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


    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class DOMError {

        [ScriptField]
        public string Name {
            get {
                return String.Empty;
            }
        }
    }


    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class ProgressEvent {

        public bool Bubbles;
        public bool CancelBubble;
        public bool Cancelable;
        public bool DefaultPrevented;
        public bool LengthComputable;
        public bool ReturnValue;

        public int EventPhase;
        public int Loaded;
        public int TimeStamp;
        public int Total;

        public object ClipboardData;
        public object CurrentTarget;
        public object SrcElement;
        public object Target;

        public string Type;
    }
}