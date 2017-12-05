// ElementType.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {
    public class Html5Timings
    {
        [ScriptField]
        public extern ulong NavigationStart { get; }
        
        [ScriptField]
        public extern ulong UnloadEventStart { get; }
        
        [ScriptField]
        public extern ulong UnloadEventEnd { get; }
        
        [ScriptField]
        public extern ulong RedirectStart { get; }
        
        [ScriptField]
        public extern ulong RedirectEnd { get; }
        
        [ScriptField]
        public extern ulong FetchStart { get; }
        
        [ScriptField]
        public extern ulong DomainLookupStart { get; }
        
        [ScriptField]
        public extern ulong DomainLookupEnd { get; }
        
        [ScriptField]
        public extern ulong ConnectStart { get; }
        
        [ScriptField]
        public extern ulong ConnectEnd { get; }
        
        [ScriptField]
        public extern ulong SecureConnectionStart { get; }
        
        [ScriptField]
        public extern ulong RequestStart { get; }
        
        [ScriptField]
        public extern ulong ResponseStart { get; }
        
        [ScriptField]
        public extern ulong ResponseEnd { get; }
        
        [ScriptField]
        public extern ulong DomLoading { get; }
        
        [ScriptField]
        public extern ulong DomInteractive { get; }
        
        [ScriptField]
        public extern ulong DomContentLoadedEventStart { get; }
        
        [ScriptField]
        public extern ulong DomContentLoadedEventEnd { get; }
        
        [ScriptField]
        public extern ulong DomComplete { get; }
        
        [ScriptField]
        public extern ulong LoadEventStart { get; }
     
        [ScriptField]
        public extern ulong LoadEventEnd { get; }
    }
}
