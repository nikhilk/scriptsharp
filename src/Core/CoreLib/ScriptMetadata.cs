// ScriptMetadata.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// Marks an assembly as a script assembly that can be used with Script#.
    /// Additionally, each script must have a unique name that can be used as
    /// a dependency name.
    /// This name is also used to generate unique names for internal types defined
    /// within the assembly. The ScriptQualifier attribute can be used to provide a
    /// shorter name if needed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    [ScriptImport]
    public sealed class ScriptAssemblyAttribute : Attribute {

        private string _name;
        private string _identifier;

        public ScriptAssemblyAttribute(string name) {
            _name = name;
        }

        public string Name {
            get {
                return _name;
            }
        }

        public string Identifier {
            get {
                return _identifier;
            }
            set {
                _identifier = value;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = true)]
    [ScriptIgnore]
    [ScriptImport]
    public sealed class ScriptReferenceAttribute : Attribute {

        private string _name;

        private string _identifier;
        private string _path;
        private bool _delayLoad;

        public ScriptReferenceAttribute(string name) {
            _name = name;
        }

        public bool DelayLoad {
            get {
                return _delayLoad;
            }
            set {
                _delayLoad = value;
            }
        }

        public string Identifier {
            get {
                return _identifier;
            }
            set {
                _identifier = value;
            }
        }

        public string Name {
            get {
                return _name;
            }
        }

        public string Path {
            get {
                return _path;
            }
            set {
                _path = value;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptTemplateAttribute : Attribute {

        private string _template;

        public ScriptTemplateAttribute(string template) {
            _template = template;
        }

        public string Template {
            get {
                return _template;
            }
        }
    }

    /// <summary>
    /// This attribute can be placed on a static class that only contains static string
    /// fields representing a set of resource strings.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [ScriptIgnore]
    public sealed class ScriptResourcesAttribute : Attribute {
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptExtensionAttribute : Attribute {

        private string _expression;

        public ScriptExtensionAttribute(string extendeeExpression) {
            _expression = extendeeExpression;
        }

        public string Expression {
            get {
                return _expression;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptModuleAttribute : Attribute {
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptObjectAttribute : Attribute {
    }

    /// <summary>
    /// This attribute is used to mark an enum as a set of constant values, i.e. if
    /// specified, the enum does not exist/is not generated, but rather its values
    /// are inlined as constants. If the UseName property is set to true, then instead
    /// of actual values, the names of the fields are used as string constants.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptConstantsAttribute : Attribute {

        private bool _useNames;

        public bool UseNames {
            get {
                return _useNames;
            }
            set {
                _useNames = value;
            }
        }
    }


    /// <summary>
    /// Allows specifying the name to use for a type or member in the generated script.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Event, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptNameAttribute : Attribute {

        private string _name;
        private bool _preserveCase;
        private bool _preserveName;

        public ScriptNameAttribute() {
        }

        public ScriptNameAttribute(string name) {
            _name = name;
        }

        public string Name {
            get {
                return _name;
            }
        }

        public bool PreserveCase {
            get {
                return _preserveCase;
            }
            set {
                _preserveCase = true;
            }
        }

        public bool PreserveName {
            get {
                return _preserveName;
            }
            set {
                _preserveName = value;
            }
        }
    }
}

namespace System.Runtime.CompilerServices {

    /// <summary>
    /// This attribute can be placed on types in system script assemblies that should not
    /// be imported. It is only meant to be used within mscorlib.dll.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    [ScriptImport]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class ScriptIgnoreAttribute : Attribute {
    }

    /// <summary>
    /// This attribute can be placed on types that should not be emitted into generated
    /// script, as they represent existing script or native types.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Delegate | AttributeTargets.Struct)]
    [ScriptIgnore]
    [ScriptImport]
    public sealed class ScriptImportAttribute : Attribute {
    }

    /// <summary>
    /// Marks a type with a script dependency that is required at runtime.
    /// The specified name is used as the name of the dependency, and the runtime identifier.
    /// </summary>
    [AttributeUsage(AttributeTargets.Type, Inherited = false, AllowMultiple = false)]
    [ScriptIgnore]
    [ScriptImport]
    public sealed class ScriptDependencyAttribute : Attribute {

        private string _name;
        private string _identifier;

        public ScriptDependencyAttribute(string name) {
            _name = name;
        }

        public string Name {
            get {
                return _name;
            }
        }

        public string Identifier {
            get {
                return _identifier;
            }
            set {
                _identifier = value;
            }
        }
    }

    /// <summary>
    /// This attribute indicates that the namespace of type within a system assembly
    /// should be ignored at script generation time. It is useful for creating namespaces
    /// for the purpose of c# code that don't exist at runtime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Delegate | AttributeTargets.Interface | AttributeTargets.Struct, Inherited = true, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptIgnoreNamespaceAttribute : Attribute {
    }

    /// <summary>
    /// This attribute allows specifying a script name for an imported method.
    /// The method is interpreted as a global method. As a result it this attribute
    /// only applies to static methods.
    /// </summary>
    // REVIEW: Eventually do we want to support this on properties/field and instance methods as well?
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptAliasAttribute : Attribute {

        private string _alias;

        public ScriptAliasAttribute(string alias) {
            _alias = alias;
        }

        public string Alias {
            get {
                return _alias;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptSkipAttribute : Attribute {
    }

    /// <summary>
    /// This attribute denotes a C# property that manifests like a field in the generated
    /// JavaScript (i.e. is not accessed via get/set methods). This is really meant only
    /// for use when defining OM corresponding to native objects exposed to script.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptFieldAttribute : Attribute {
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptMethodAttribute : Attribute {

        private string _selector;

        public ScriptMethodAttribute(string selector) {
            _selector = selector;
        }

        public string Selector {
            get {
                return _selector;
            }
        }
    }


    [AttributeUsage(AttributeTargets.Event, Inherited = true, AllowMultiple = false)]
    [ScriptIgnore]
    public sealed class ScriptEventAttribute : Attribute {

        private string _addAccessor;
        private string _removeAccessor;

        public ScriptEventAttribute(string addAccessor, string removeAccessor) {
            _addAccessor = addAccessor;
            _removeAccessor = removeAccessor;
        }

        public string AddAccessor {
            get {
                return _addAccessor;
            }
        }

        public string RemoveAccessor {
            get {
                return _removeAccessor;
            }
        }
    }
}
