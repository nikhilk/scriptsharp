namespace DSharp.Compiler
{
    public static class DSharpStringResources
    {
        public static readonly string DSHARP_MSCORLIB_ASSEMBLY_NAME = "DSharp.Mscorlib";
        public static readonly string DSHARP_SCRIPT_NAME = "ss";

        //atrribute names
        public static readonly string SCRIPT_ALIAS_ATTRIBUTE = "ScriptAlias";
        public static readonly string DSHARP_MEMBER_NAME_ATTRIBUTE = "DSharpScriptMemberName";
        public static readonly string SCRIPT_NAMESPACE_ATTRIBUTE = "ScriptNamespace";
        public static readonly string SCRIPT_IMPORT_ATTRIBUTE = "ScriptImport";
        public static readonly string SCRIPT_IGNORE_ATTRIBUTE = "ScriptIgnore";
        public static readonly string SCRIPT_IGNORE_ATTRIBUTE_FULLTYPENAME = "System.ScriptIgnore";
        public static readonly string SCRIPT_OBJECT_ATTRIBUTE = "ScriptObject";
        public static readonly string SCRIPT_EXTENSION_ATTRIBUTE = "ScriptExtension";
        public static readonly string SCRIPT_MODULE_ATTRIBUTE = "ScriptModule";
        public static readonly string SCRIPT_NAME_ATTRIBUTE = "ScriptName";
        public static readonly string SCRIPT_REFERENCE_ATTRIBUTE = "ScriptReference";

        //errors
        public static readonly string NODE_VALIDATION_ERROR_TRY_CATCH = "Try/Catch statements are limited to a single catch clause.";
        public static readonly string THROW_NODE_VALIDATION_ERROR = "Throw statements must specify an exception object.";
        public static readonly string ENUM_CONSTANT_VALUE_MISSING_ERROR = "Enumeration fields must have an explicit constant value specified.";
        public static readonly string ENUM_VALUE_TYPE_ERROR = "Enumeration fields cannot have long or ulong underlying type.";
        public static readonly string SCRIPT_LITERAL_CONSTANT_ERROR = "The argument to Script.Literal must be a constant string.";
        public static readonly string SCRIPT_LITERAL_FORMAT_ERROR = "The argument to Script.Literal must be a valid String.Format string.";
        public static readonly string RESERVED_KEYWORD_ERROR_FORMAT = "{0} is a reserved keyword.";
        public static readonly string SCRIPT_MODULE_NON_INTERNAL_CLASS_ERROR = "ScriptModule attribute can only be set on internal static classes.";
        public static readonly string SCRIPT_MODULE_NON_STATIC_CONSTRUCTOR = "Classes marked with ScriptModule attribute should only have a static constructor.";
        public static readonly string NESTED_TYPE_ERROR = "Only members are allowed inside types. Nested types are not supported.";
        public static readonly string EXTERN_IMPLEMENTATION_FOUND_ERROR = "Extern methods used to declare alternate signatures should have a corresponding non-extern implementation as well.";
        public static readonly string EXTERN_STATIC_MEMBER_MISMATCH_ERROR = "The implemenation method and associated alternate signature methods should have the same access type.";
        public static readonly string SCRIPT_OBJECT_ATTRIBUTE_ERROR = "ScriptObject attribute can only be set on sealed classes.";
        public static readonly string SCRIPT_OBJECT_CLASS_INHERITENCE_ERROR = "Classes marked with ScriptObject must not derive from another class or implement interfaces.";
        public static readonly string SCRIPT_OBJECT_MEMBER_VIOLATION_ERROR = "Classes marked with ScriptObject attribute should only have a constructor and field members.";
        public static readonly string EXTENSION_ATTRIBUTE_ERROR = "ScriptExtension attribute declaration must specify the object being extended.";
        public static readonly string SCRIPT_EXTENSION_MEMBER_VIOLATION_ERROR = "Classes marked with ScriptExtension attribute should only have methods.";
        public static readonly string CONFLICTING_TYPE_NAME_ERROR_FORMAT = "The type '{0}' conflicts with with '{1}' as they have the same name.";
        //TODO: None of these error messages are tested
        public static readonly string SCRIPT_NAMESPACE_VIOLATION = "A script namespace must be a valid script identifier.";
        public static readonly string SCRIPT_NAMESPACE_TYPE_VIOLATION = "Non-namespaced types are not supported.";
        public static readonly string INDEXER_NEW_KEYWORD_NOT_SUPPORTED_ERROR = "The new modifier is not supported.";
        public static readonly string INDEXER_SET_ONLY_NOT_SUPPORTED = "Set-only properties are not supported. Use a set method instead.";
        public static readonly string STATIC_NEW_KEYWORD_UNSUPPORTED = "The new modifier is not supported on instance members.";
        public static readonly string UNSUPPORTED_MULTIPLE_DIMENSIONAL_ARRAYS = "Only single dimensional arrays are supported.";
        public static readonly string UNSUPPORTED_NESTED_NAMESPACE = "Nested namespaces are not supported.";
        public static readonly string UNSUPPORTED_PARTIAL_TYPE = "Partial types can only be classes, not enumerations or interfaces.";
        public static readonly string SCRIPT_EXTENSION_NON_STATIC_CLASS_VIOLATION = "ScriptExtension attribute can only be set on static classes.";
        public static readonly string UNSUPPORTED_CONSTRUCTOR_OVERLOAD = "Constructor overloads are not supported.";
        public static readonly string UNSUPPORTED_METHOD_OVERLOAD = "Duplicate-named member. Method overloads are not supported.";
        public static readonly string RESERVED_KEYWORD_ON_MEMBER_ERROR = "Invalid member name. Member names should not use keywords.";
        public static readonly string ASSEMBLY_SCRIPT_ATTRIBUTE_MISSING = "You must declare a ScriptAssembly attribute.";
        public static readonly string INVALID_SCRIPT_NAME_FORMAT = " ScriptAssembly attribute referenced an invalid name '{0}'. Script names must only contain letters, numbers, dots or underscores.";
        public static readonly string DUPLICATE_FIELD_DECLARATION = "Field declarations are limited to a single field per declaration.";
        public static readonly string UNSUPPORTED_PARAMETER_TYPE = "Out and Ref style of parameters are not yet implemented.";
        public static readonly string INVALID_DICTIONARY_INTIALIZATION_PARAMETER_VALUE = "Missing value parameter for the last name parameter in Dictionary instantiation.";
        public static readonly string INVALID_DICTIONARY_PARAMETER_TYPE = "Name parameters in Dictionary instantiation must be string literals.";
        public static readonly string EXTENSION_TYPE_AND_METHOD_SHOULD_BE_STATIC = "Extension methods should only exist on a static type, and be a static method";
        public static readonly string UNRESOLVED_TYPE_REFERENCE_FORMAT = "Unable to resolve referenced type '{0}'. Make sure all needed assemblies have been explicitly referenced.";
        public static readonly string MISSING_ASSEMBLY_REFERENCE_FORMAT = "The referenced assembly '{0}' could not be located.";
        public static readonly string MISSING_SCRIPT_OUTPUT_STREAM_FORMAT = "Unable to write to file {0}";
        public static readonly string SCRIPT_LATE_BOUND_INVALID_METHOD_NAME = "The name of a global method must be a constant string known at compile time.";
        public static readonly string SCRIPT_LATE_BOUND_INVALID_METHOD_IDENTIFIER = "The name of a global method must be a valid identifer.";

        public static string ScriptExportMember(string methodName)
        {
            return $"{DSHARP_SCRIPT_NAME}.{methodName}";
        }
    }
}
