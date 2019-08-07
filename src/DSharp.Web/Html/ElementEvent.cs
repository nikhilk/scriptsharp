using System.Runtime.CompilerServices;

namespace System.Html
{

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class ElementEvent
    {
        internal ElementEvent()
        {
        }

        [ScriptField]
        public extern bool AltKey { get; }

        [ScriptField]
        public extern int Button { get; }

        [ScriptField]
        public extern bool CancelBubble { get; set; }

        [ScriptField]
        public extern int ClientX { get; }

        [ScriptField]
        public extern int ClientY { get; }

        [ScriptField]
        public extern bool CtrlKey { get; }

        [ScriptField]
        public extern Element CurrentTarget { get; }

        [ScriptField]
        public extern DataTransfer DataTransfer { get; }

        [ScriptField]
        public extern string Detail { get; }

        [ScriptField]
        public extern Element FromElement { get; }

        [ScriptField]
        public extern int KeyCode { get; }

        [ScriptField]
        public extern bool MetaKey { get; }

        [ScriptField]
        public extern int OffsetX { get; }

        [ScriptField]
        public extern int OffsetY { get; }

        [ScriptField]
        public extern int PageX { get; }

        [ScriptField]
        public extern int PageY { get; }

        [ScriptField]
        public extern bool ReturnValue { get; set; }

        [ScriptField]
        public extern int ScreenX { get; }

        [ScriptField]
        public extern int ScreenY { get; }

        [ScriptField]
        public extern bool ShiftKey { get; }

        [ScriptField]
        public extern Element SrcElement { get; }

        [ScriptField]
        public extern Element Target { get; }

        [ScriptField]
        public extern Date TimeStamp { get; }

        [ScriptField]
        public extern Element ToElement { get; }

        [ScriptField]
        public extern string Type { get; }

        [ScriptField]
        public extern bool Bubbles { get; }

        [ScriptField]
        public extern bool Cancelable { get; }


        public extern void PreventDefault();

        public extern void StopImmediatePropagation();

        public extern void StopPropagation();
    }
}
