using System.Runtime.CompilerServices;

namespace System.Html
{
    [ScriptImport]
    [ScriptName("Proxy")]
    [ScriptIgnoreNamespace]
    [ScriptIgnoreGenericArguments]
    public class Proxy<T> : Proxy
    {
        public static extern implicit operator T(Proxy<T> proxy);

        /// <summary>
        /// The Proxy object is used to define custom behavior for fundamental operations (e.g. property lookup, assignment, enumeration, function invocation, etc).
        /// </summary>
        /// <param name="target">Object which the proxy virtualizes. It is often used as storage backend for the proxy. Invariants (semantics that remain unchanged) regarding object non-extensibility or non-configurable properties are verified against the target.</param>
        /// <param name="handler">Placeholder object which contains traps.</param>
        public extern Proxy(T target, Handler<T> handler);
    }

    [ScriptName("Proxy")]
    [ScriptIgnoreNamespace]
    public class Proxy
    {
        /// <summary>
        /// The Proxy object is used to define custom behavior for fundamental operations (e.g. property lookup, assignment, enumeration, function invocation, etc).
        /// </summary>
        /// <param name="target">Object which the proxy virtualizes. It is often used as storage backend for the proxy. Invariants (semantics that remain unchanged) regarding object non-extensibility or non-configurable properties are verified against the target.</param>
        /// <param name="handler">Placeholder object which contains traps.</param>
        public extern Proxy(object target, Handler handler);

        /// <summary>
        /// The Proxy object is used to define custom behavior for fundamental operations (e.g. property lookup, assignment, enumeration, function invocation, etc).
        /// </summary>
        /// <param name="target">Object which the proxy virtualizes. It is often used as storage backend for the proxy. Invariants (semantics that remain unchanged) regarding object non-extensibility or non-configurable properties are verified against the target.</param>
        /// <param name="handler">Placeholder object which contains traps. (pattern matched to Handler interface)</param>
        public extern Proxy(object target, object handler);

        [ScriptImport]
        [ScriptIgnoreNamespace]
        [ScriptName("Object")]
        public class Handler
        {
            public delegate object ApplyTrap(object target, object thisArg, params object[] args);
            public delegate object GetTrap(object target, string property, Proxy receiver);
            public delegate bool SetTrap(object target, string property, object value, Proxy receiver);
            public delegate bool HasTrap(object target, string property);
            public delegate object DeleteTrap(object target, string property);
            public delegate string[] OwnKeysTrap(object target);

            [ScriptName("get")]
            public GetTrap Get { get; set; }

            [ScriptName("set")]
            public SetTrap Set { get; set; }

            [ScriptName("apply")]
            public ApplyTrap Apply { get; set; }

            [ScriptName("has")]
            public HasTrap Has { get; set; }

            [ScriptName("deleteProperty")]
            public DeleteTrap DeleteProperty { get; set; }

            [ScriptName("ownKeys")]
            public OwnKeysTrap OwnKeys { get; set; }
        }

        [ScriptImport]
        [ScriptName("Object")]
        [ScriptIgnoreNamespace]
        [ScriptIgnoreGenericArguments]
        public class Handler<T> : Handler
        {
            new public delegate object ApplyTrap(T target, object thisArg, params object[] args);
            new public delegate object GetTrap(T target, string property, Proxy<T> receiver);
            new public delegate bool SetTrap(T target, string property, object value, Proxy<T> receiver);
            new public delegate bool HasTrap(T target, string property);
            new public delegate object DeleteTrap(T target, string property);
            new public delegate string[] OwnKeysTrap(T target);

            [ScriptName("get")]
            new public GetTrap Get { get; set; }

            [ScriptName("set")]
            new public SetTrap Set { get; set; }

            [ScriptName("apply")]
            new public ApplyTrap Apply { get; set; }

            [ScriptName("has")]
            new public HasTrap Has { get; set; }

            [ScriptName("deleteProperty")]
            new public DeleteTrap DeleteProperty { get; set; }

            [ScriptName("ownKeys")]
            new public OwnKeysTrap OwnKeys { get; set; }
        }
    }
}
