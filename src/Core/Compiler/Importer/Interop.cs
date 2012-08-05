// Interop.cs
// Script#/Core/ScriptSharp
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace ScriptSharp.Importer {

    internal static class Interop {

        internal enum CorTokenType {
            mdtModule = 0x00000000,
            mdtTypeRef = 0x01000000,
            mdtTypeDef = 0x02000000,
            mdtFieldDef = 0x04000000,
            mdtMethodDef = 0x06000000,
            mdtParamDef = 0x08000000,
            mdtInterfaceImpl = 0x09000000,
            mdtMemberRef = 0x0a000000,
            mdtCustomAttribute = 0x0c000000,
            mdtPermission = 0x0e000000,
            mdtSignature = 0x11000000,
            mdtEvent = 0x14000000,
            mdtProperty = 0x17000000,
            mdtModuleRef = 0x1a000000,
            mdtTypeSpec = 0x1b000000,
            mdtAssembly = 0x20000000,
            mdtAssemblyRef = 0x23000000,
            mdtFile = 0x26000000,
            mdtExportedType = 0x27000000,
            mdtManifestResource = 0x28000000,
            mdtGenericParam = 0x2a000000,
            mdtMethodSpec = 0x2b000000,
            mdtGenericParamConstraint = 0x2c000000,
            mdtString = 0x70000000,
            mdtName = 0x71000000,
            mdtBaseType = 0x72000000,
        }

        internal enum CorTypeAttr {
            // Use this mask to retrieve the type visibility information.
            tdVisibilityMask = 0x00000007,
            tdNotPublic = 0x00000000,           // Class is not public scope.
            tdPublic = 0x00000001,              // Class is public scope.
            tdNestedPublic = 0x00000002,        // Class is nested with public visibility.
            tdNestedPrivate = 0x00000003,       // Class is nested with private visibility.
            tdNestedFamily = 0x00000004,        // Class is nested with family visibility.
            tdNestedAssembly = 0x00000005,      // Class is nested with assembly visibility.
            tdNestedFamANDAssem = 0x00000006,   // Class is nested with family and assembly visibility.
            tdNestedFamORAssem = 0x00000007,    // Class is nested with family or assembly visibility.

            // Use this mask to retrieve class layout information
            tdLayoutMask = 0x00000018,
            tdAutoLayout = 0x00000000,          // Class fields are auto-laid out
            tdSequentialLayout = 0x00000008,    // Class fields are laid out sequentially
            tdExplicitLayout = 0x00000010,      // Layout is supplied explicitly

            // Use this mask to retrieve class semantics information.
            tdClassSemanticsMask = 0x00000060,
            tdClass = 0x00000000,               // Type is a class.
            tdInterface = 0x00000020,           // Type is an interface.

            // Special semantics in addition to class semantics.
            tdAbstract = 0x00000080,            // Class is abstract
            tdSealed = 0x00000100,              // Class is concrete and may not be extended
            tdSpecialName = 0x00000400,         // Class name is special.  Name describes how.

            // Implementation attributes.
            tdImport = 0x00001000,              // Class / interface is imported
            tdSerializable = 0x00002000,        // The class is Serializable.

            // Use tdStringFormatMask to retrieve string information for native interop
            tdStringFormatMask = 0x00030000,
            tdAnsiClass = 0x00000000,           // LPTSTR is interpreted as ANSI in this class
            tdUnicodeClass = 0x00010000,        // LPTSTR is interpreted as UNICODE
            tdAutoClass = 0x00020000,           // LPTSTR is interpreted automatically
            tdCustomFormatClass = 0x00030000,   // A non-standard encoding specified by CustomFormatMask
            tdCustomFormatMask = 0x00C00000,    // Use this mask to retrieve non-standard encoding information for native interop. The meaning of the values of these 2 bits is unspecified.

            // Flags reserved for runtime use.
            tdBeforeFieldInit = 0x00100000,     // Initialize the class any time before first static field access.
            tdForwarder = 0x00200000,           // This ExportedType is a type forwarder.
            tdReservedMask = 0x00040800,
            tdRTSpecialName = 0x00000800,       // Runtime should check name encoding.
            tdHasSecurity = 0x00040000,         // Class has security associate with it.
        }

        internal enum CorFieldAttr {
            // member access mask - Use this mask to retrieve accessibility information.
            fdFieldAccessMask = 0x0007,
            fdPrivateScope = 0x0000,            // Member not referenceable.
            fdPrivate = 0x0001,                 // Accessible only by the parent type.
            fdFamANDAssem = 0x0002,             // Accessible by sub-types only in this Assembly.
            fdAssembly = 0x0003,                // Accessibly by anyone in the Assembly.
            fdFamily = 0x0004,                  // Accessible only by type and sub-types.
            fdFamORAssem = 0x0005,              // Accessibly by sub-types anywhere, plus anyone in assembly.
            fdPublic = 0x0006,                  // Accessibly by anyone who has visibility to this scope.

            // field contract attributes.
            fdStatic = 0x0010,                  // Defined on type, else per instance.
            fdInitOnly = 0x0020,                // Field may only be initialized, not written to after init.
            fdLiteral = 0x0040,                 // Value is compile time constant.
            fdNotSerialized = 0x0080,           // Field does not have to be serialized when type is remoted.

            fdSpecialName = 0x0200,             // field is special.  Name describes how.

            // interop attributes
            fdPinvokeImpl = 0x2000,             // Implementation is forwarded through pinvoke.

            // Reserved flags for runtime use only.
            fdReservedMask = 0x9500,
            fdRTSpecialName = 0x0400,           // Runtime(metadata internal APIs) should check name encoding.
            fdHasFieldMarshal = 0x1000,         // Field has marshalling information.
            fdHasDefault = 0x8000,              // Field has default.
            fdHasFieldRVA = 0x0100,             // Field has RVA.
        }

        public enum CorMethodAttr {
            // member access mask - Use this mask to retrieve accessibility information.
            mdMemberAccessMask = 0x0007,
            mdPrivateScope = 0x0000,            // Member not referenceable.
            mdPrivate = 0x0001,                 // Accessible only by the parent type.
            mdFamANDAssem = 0x0002,             // Accessible by sub-types only in this Assembly.
            mdAssembly = 0x0003,                   // Accessibly by anyone in the Assembly.
            mdFamily = 0x0004,                  // Accessible only by type and sub-types.
            mdFamORAssem = 0x0005,              // Accessibly by sub-types anywhere, plus anyone in assembly.
            mdPublic = 0x0006,                  // Accessibly by anyone who has visibility to this scope.

            // method contract attributes.
            mdStatic = 0x0010,                  // Defined on type, else per instance.
            mdFinal = 0x0020,                   // Method may not be overridden.
            mdVirtual = 0x0040,                 // Method virtual.
            mdHideBySig = 0x0080,               // Method hides by name+sig, else just by name.

            // vtable layout mask - Use this mask to retrieve vtable attributes.
            mdVtableLayoutMask = 0x0100,
            mdReuseSlot = 0x0000,               // The default.
            mdNewSlot = 0x0100,                 // Method always gets a new slot in the vtable.

            // method implementation attributes.
            mdCheckAccessOnOverride = 0x0200,   // Overridability is the same as the visibility.
            mdAbstract = 0x0400,                // Method does not provide an implementation.
            mdSpecialName = 0x0800,             // Method is special.  Name describes how.

            // interop attributes
            mdPinvokeImpl = 0x2000,             // Implementation is forwarded through pinvoke.
            mdUnmanagedExport = 0x0008,         // Managed method exported via thunk to unmanaged code.

            // Reserved flags for runtime use only.
            mdReservedMask = 0xd000,
            mdRTSpecialName = 0x1000,           // Runtime should check name encoding.
            mdHasSecurity = 0x4000,             // Method has security associate with it.
            mdRequireSecObject = 0x8000,        // Method calls another method containing security code.
        }

        public enum CorPropertyAttr {
            prSpecialName = 0x0200,             // property is special.  Name describes how.

            // Reserved flags for Runtime use only.
            prReservedMask = 0xf400,
            prRTSpecialName = 0x0400,           // Runtime(metadata internal APIs) should check name encoding.
            prHasDefault = 0x1000,              // Property has default

            prUnused = 0xe9ff,
        }

        public enum CorEventAttr {
            evSpecialName = 0x0200,             // event is special.  Name describes how.

            // Reserved flags for Runtime use only.
            evReservedMask = 0x0400,
            evRTSpecialName = 0x0400,           // Runtime(metadata internal APIs) should check name encoding.
        }

        public const byte ELEMENT_TYPE_END = 0x00;           // Marks end of a list
        public const byte ELEMENT_TYPE_VOID = 0x01;
        public const byte ELEMENT_TYPE_BOOLEAN = 0x02;
        public const byte ELEMENT_TYPE_CHAR = 0x03;
        public const byte ELEMENT_TYPE_I1 = 0x04;
        public const byte ELEMENT_TYPE_U1 = 0x05;
        public const byte ELEMENT_TYPE_I2 = 0x06;
        public const byte ELEMENT_TYPE_U2 = 0x07;
        public const byte ELEMENT_TYPE_I4 = 0x08;
        public const byte ELEMENT_TYPE_U4 = 0x09;
        public const byte ELEMENT_TYPE_I8 = 0x0a;
        public const byte ELEMENT_TYPE_U8 = 0x0b;
        public const byte ELEMENT_TYPE_R4 = 0x0c;
        public const byte ELEMENT_TYPE_R8 = 0x0d;
        public const byte ELEMENT_TYPE_STRING = 0x0e;
        public const byte ELEMENT_TYPE_PTR = 0x0f;            // Followed by type
        public const byte ELEMENT_TYPE_BYREF = 0x10;          // Followed by type
        public const byte ELEMENT_TYPE_VALUETYPE = 0x11;      // Followed by TypeDef or TypeRef token
        public const byte ELEMENT_TYPE_CLASS = 0x12;          // Followed by TypeDef or TypeRef token
        public const byte ELEMENT_TYPE_VAR = 0x13;            // Generic parameter in a generic type definition; represented as number
        public const byte ELEMENT_TYPE_ARRAY = 0x14;          // type rank boundsCount bound1 ... loCount lo1 ...
        public const byte ELEMENT_TYPE_GENERICINST = 0x15;    // Generic type instantiation. Followed by type type-arg-count type-1 ... type-n
        public const byte ELEMENT_TYPE_TYPEDBYREF = 0x16;
        public const byte ELEMENT_TYPE_I = 0x18;              // System.IntPtr
        public const byte ELEMENT_TYPE_U = 0x19;              // System.UIntPtr
        public const byte ELEMENT_TYPE_FNPTR = 0x1b;          // Followed by full method signature
        public const byte ELEMENT_TYPE_OBJECT = 0x1c;         // System.Object
        public const byte ELEMENT_TYPE_SZARRAY = 0x1d;        // Single-dim array with 0 lower bound

        public const byte ELEMENT_TYPE_MVAR = 0x1e;           // Generic parameter in a generic method definition;represented as number
        public const byte ELEMENT_TYPE_CMOD_REQD = 0x1f;      // Required modifier : followed by a TypeDef or TypeRef token
        public const byte ELEMENT_TYPE_CMOD_OPT = 0x20;       // Optional modifier : followed by a TypeDef or TypeRef token
        public const byte ELEMENT_TYPE_INTERNAL = 0x21;       // Implemented within the CLI
        public const byte ELEMENT_TYPE_MODIFIER = 0x40;       // Or’d with following element types
        public const byte ELEMENT_TYPE_SENTINEL = 0x41;       // Sentinel for vararg method signature
        public const byte ELEMENT_TYPE_PINNED = 0x45;         // Denotes a local variable that points at a pinned object

        public const byte SIG_METHOD_DEFAULT = 0x0;             // default calling convention
        public const byte SIG_METHOD_C = 0x1;                   // C calling convention
        public const byte SIG_METHOD_STDCALL = 0x2;             // Stdcall calling convention
        public const byte SIG_METHOD_THISCALL = 0x3;            // thiscall  calling convention
        public const byte SIG_METHOD_FASTCALL = 0x4;            // fastcall calling convention
        public const byte SIG_METHOD_VARARG = 0x5;              // vararg calling convention
        public const byte SIG_FIELD = 0x6;                      // encodes a field
        public const byte SIG_LOCAL_SIG = 0x7;                  // used for the .locals directive
        public const byte SIG_PROPERTY = 0x8;                   // used to encode a property

        public const byte SIG_GENERIC = 0x10;                   // used to indicate that the method has one or more generic parameters.
        public const byte SIG_HASTHIS = 0x20;                   // used to encode the keyword instance in the calling convention
        public const byte SIG_EXPLICITTHIS = 0x40;              // used to encode the keyword explicit in the calling convention

        public const byte SIG_INDEX_TYPE_TYPEDEF = 0;           // ParseTypeDefOrRefEncoded returns this as the out index type for typedefs
        public const byte SIG_INDEX_TYPE_TYPEREF = 1;           // ParseTypeDefOrRefEncoded returns this as the out index type for typerefs
        public const byte SIG_INDEX_TYPE_TYPESPEC = 2;          // ParseTypeDefOrRefEncoded returns this as the out index type for typespecs

        [
        ComImport,
        Guid("E5CB7A31-7512-11d2-89CE-0080C792E5D8"),
        ClassInterface(ClassInterfaceType.None)
        ]
        internal class CorMetadataDispenser {
        }

        [
        Guid("809c652e-7396-11d2-9771-00a0c9b4d50c"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)
        ]
        internal interface IMetadataDispenser {

            [return: MarshalAs(UnmanagedType.Interface)]
            object DefineScope(
                ref Guid rclsid,
                int dwCreateFlags,
                ref Guid riid);

            [return: MarshalAs(UnmanagedType.Interface)]
            object OpenScope(
                [MarshalAs(UnmanagedType.LPWStr)]  string szScope,
                int dwOpenFlags,
                ref Guid riid);

            [return: MarshalAs(UnmanagedType.Interface)]
            object OpenScopeOnMemory(
                IntPtr pData,
                int cbData,
                int dwOpenFlags,
                ref Guid riid);
        }

        [
        Guid("7DAC8207-D3AE-4c75-9B67-92801A497D44"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)
        ]
        internal interface IMetadataImport {

            // STDMETHOD_(void, CloseEnum)(HCORENUM hEnum) PURE;
            [PreserveSig]
            void CloseEnum(IntPtr hEnum);

            // STDMETHOD(CountEnum)(HCORENUM hEnum, ULONG *pulCount) PURE;
            void CountEnum_();

            // STDMETHOD(ResetEnum)(HCORENUM hEnum, ULONG ulPos) PURE;
            void ResetEnum_();

            // STDMETHOD(EnumTypeDefs)(HCORENUM *phEnum, mdTypeDef rTypeDefs[],ULONG cMax, ULONG *pcTypeDefs) PURE;
            void EnumTypeDefs(
                ref IntPtr phEnum,
                [Out] out int rTypeDefs,
                int cMax /* must be 1 */,
                out int pcTypeDefs);

            // STDMETHOD(EnumInterfaceImpls)(HCORENUM *phEnum, mdTypeDef td, mdInterfaceImpl rImpls[], ULONG cMax, ULONG* pcImpls) PURE;
            void EnumInterfaceImpls_();

            // STDMETHOD(EnumTypeRefs)(HCORENUM *phEnum, mdTypeRef rTypeRefs[], ULONG cMax, ULONG* pcTypeRefs) PURE;
            void EnumTypeRefs_();

            // STDMETHOD(FindTypeDefByName)(           // S_OK or error.
            //     LPCWSTR     szTypeDef,              // [IN] Name of the Type.
            //     mdToken     tkEnclosingClass,       // [IN] TypeDef/TypeRef for Enclosing class.
            //     mdTypeDef   *ptd) PURE;             // [OUT] Put the TypeDef token here.
            void FindTypeDefByName(
                [MarshalAs(UnmanagedType.LPWStr)] string szTypeDef,
                int tkEnclosingClass,
                [Out] out int ptkClass);

            // STDMETHOD(GetScopeProps)(               // S_OK or error.
            //     LPWSTR      szName,                 // [OUT] Put the name here.
            //     ULONG       cchName,                // [IN] Size of name buffer in wide chars.
            //     ULONG       *pchName,               // [OUT] Put size of name (wide chars) here.
            //     GUID        *pmvid) PURE;           // [OUT, OPTIONAL] Put MVID here.
            void GetScopeProps_();

            // STDMETHOD(GetModuleFromScope)(mdModule* pmd) // [OUT] Put mdModule token here.
            void GetModuleFromScope([Out] out int pmd);

            // STDMETHOD(GetTypeDefProps)(             // S_OK or error.
            //     mdTypeDef   td,                     // [IN] TypeDef token for inquiry.
            //     LPWSTR      szTypeDef,              // [OUT] Put name here.
            //     ULONG       cchTypeDef,             // [IN] size of name buffer in wide chars.
            //     ULONG       *pchTypeDef,            // [OUT] put size of name (wide chars) here.
            //     DWORD       *pdwTypeDefFlags,       // [OUT] Put flags here.
            //     mdToken     *ptkExtends) PURE;      // [OUT] Put base class TypeDef/TypeRef here.
            void GetTypeDefProps(
                int tkTypeDef,
                [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szTypeDef,
                int cchTypeDef,
                out int pchTypeDef,
                out int pdwTypeDefFlags,
                out int ptkExtends);

            // STDMETHOD(GetInterfaceImplProps)(       // S_OK or error.
            //     mdInterfaceImpl iiImpl,             // [IN] InterfaceImpl token.
            //     mdTypeDef   *pClass,                // [OUT] Put implementing class token here.
            //     mdToken     *ptkIface) PURE;        // [OUT] Put implemented interface token here.
            void GetInterfaceImplProps_();

            // STDMETHOD(GetTypeRefProps)(             // S_OK or error.
            //     mdTypeRef   tr,                     // [IN] TypeRef token.
            //     mdToken     *ptkResolutionScope,    // [OUT] Resolution scope, ModuleRef or AssemblyRef.
            //     LPWSTR      szName,                 // [OUT] Name of the TypeRef.
            //     ULONG       cchName,                // [IN] Size of buffer.
            //     ULONG       *pchName) PURE;         // [OUT] Size of Name.
            void GetTypeRefProps(
                int tkTypeRef,
                [Out] out int ptkResolutionScope,
                [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
                int cchName,
                out int pchName);

            // STDMETHOD(ResolveTypeRef)(mdTypeRef tr, REFIID riid, IUnknown **ppIScope, mdTypeDef *ptd) PURE;
            void ResolveTypeRef_();

            // STDMETHOD(EnumMembers)(                 // S_OK, S_FALSE, or error. 
            //     HCORENUM    *phEnum,                // [IN|OUT] Pointer to the enum.    
            //     mdTypeDef   cl,                     // [IN] TypeDef to scope the enumeration.   
            //     mdToken     rMembers[],             // [OUT] Put MemberDefs here.   
            //     ULONG       cMax,                   // [IN] Max MemberDefs to put.  
            //     ULONG       *pcTokens) PURE;        // [OUT] Put # put here.    
            void EnumMembers_();

            // STDMETHOD(EnumMembersWithName)(         // S_OK, S_FALSE, or error.             
            //     HCORENUM    *phEnum,                // [IN|OUT] Pointer to the enum.                
            //     mdTypeDef   cl,                     // [IN] TypeDef to scope the enumeration.   
            //     LPCWSTR     szName,                 // [IN] Limit results to those with this name.              
            //     mdToken     rMembers[],             // [OUT] Put MemberDefs here.                   
            //     ULONG       cMax,                   // [IN] Max MemberDefs to put.              
            //     ULONG       *pcTokens) PURE;        // [OUT] Put # put here.    
            void EnumMembersWithName_();

            // STDMETHOD(EnumMethods)(                 // S_OK, S_FALSE, or error. 
            //     HCORENUM    *phEnum,                // [IN|OUT] Pointer to the enum.    
            //     mdTypeDef   cl,                     // [IN] TypeDef to scope the enumeration.   
            //     mdMethodDef rMethods[],             // [OUT] Put MethodDefs here.   
            //     ULONG       cMax,                   // [IN] Max MethodDefs to put.  
            //     ULONG       *pcTokens) PURE;        // [OUT] Put # put here.    
            void EnumMethods(
                ref IntPtr phEnum,
                int tkType,
                out int mdMethodDef,
                int cMax /* must be 1 */,
                out int pcTokens);

            // STDMETHOD(EnumMethodsWithName)(         // S_OK, S_FALSE, or error.             
            //     HCORENUM    *phEnum,                // [IN|OUT] Pointer to the enum.                
            //     mdTypeDef   cl,                     // [IN] TypeDef to scope the enumeration.   
            //     LPCWSTR     szName,                 // [IN] Limit results to those with this name.              
            //     mdMethodDef rMethods[],             // [OU] Put MethodDefs here.    
            //     ULONG       cMax,                   // [IN] Max MethodDefs to put.              
            //     ULONG       *pcTokens) PURE;        // [OUT] Put # put here.    
            void EnumMethodsWithName_();

            // STDMETHOD(EnumFields)(                 // S_OK, S_FALSE, or error.  
            //     HCORENUM    *phEnum,                // [IN|OUT] Pointer to the enum.    
            //     mdTypeDef   cl,                     // [IN] TypeDef to scope the enumeration.   
            //     mdFieldDef  rFields[],              // [OUT] Put FieldDefs here.    
            //     ULONG       cMax,                   // [IN] Max FieldDefs to put.   
            //     ULONG       *pcTokens) PURE;        // [OUT] Put # put here.    
            void EnumFields(
                ref IntPtr phEnum,
                int tkType,
                out int mdFieldDef,
                int cMax /* must be 1 */,
                out int pcTokens);

            // STDMETHOD(EnumFieldsWithName)(         // S_OK, S_FALSE, or error.              
            //     HCORENUM    *phEnum,                // [IN|OUT] Pointer to the enum.                
            //     mdTypeDef   cl,                     // [IN] TypeDef to scope the enumeration.   
            //     LPCWSTR     szName,                 // [IN] Limit results to those with this name.              
            //     mdFieldDef  rFields[],              // [OUT] Put MemberDefs here.                   
            //     ULONG       cMax,                   // [IN] Max MemberDefs to put.              
            //     ULONG       *pcTokens) PURE;        // [OUT] Put # put here.    
            void EnumFieldsWithName_();

            // STDMETHOD(EnumParams)(                  // S_OK, S_FALSE, or error. 
            //     HCORENUM    *phEnum,                // [IN|OUT] Pointer to the enum.    
            //     mdMethodDef mb,                     // [IN] MethodDef to scope the enumeration. 
            //     mdParamDef  rParams[],              // [OUT] Put ParamDefs here.    
            //     ULONG       cMax,                   // [IN] Max ParamDefs to put.   
            //     ULONG       *pcTokens) PURE;        // [OUT] Put # put here.
            void EnumParams_();

            // STDMETHOD(EnumMemberRefs)(              // S_OK, S_FALSE, or error. 
            //     HCORENUM    *phEnum,                // [IN|OUT] Pointer to the enum.    
            //     mdToken     tkParent,               // [IN] Parent token to scope the enumeration.  
            //     mdMemberRef rMemberRefs[],          // [OUT] Put MemberRefs here.   
            //     ULONG       cMax,                   // [IN] Max MemberRefs to put.  
            //     ULONG       *pcTokens) PURE;        // [OUT] Put # put here.    
            void EnumMemberRefs_();

            // STDMETHOD(EnumMethodImpls)(             // S_OK, S_FALSE, or error  
            //     HCORENUM    *phEnum,                // [IN|OUT] Pointer to the enum.    
            //     mdTypeDef   td,                     // [IN] TypeDef to scope the enumeration.   
            //     mdToken     rMethodBody[],          // [OUT] Put Method Body tokens here.   
            //     mdToken     rMethodDecl[],          // [OUT] Put Method Declaration tokens here.
            //     ULONG       cMax,                   // [IN] Max tokens to put.  
            //     ULONG       *pcTokens) PURE;        // [OUT] Put # put here.    
            void EnumMethodImpls_();

            // STDMETHOD(EnumPermissionSets)(          // S_OK, S_FALSE, or error. 
            //     HCORENUM    *phEnum,                // [IN|OUT] Pointer to the enum.    
            //     mdToken     tk,                     // [IN] if !NIL, token to scope the enumeration.    
            //     DWORD       dwActions,              // [IN] if !0, return only these actions.   
            //     mdPermission rPermission[],         // [OUT] Put Permissions here.  
            //     ULONG       cMax,                   // [IN] Max Permissions to put. 
            //     ULONG       *pcTokens) PURE;        // [OUT] Put # put here.    
            void EnumPermissionSets_();

            // STDMETHOD(FindMember)(  
            //     mdTypeDef   td,                     // [IN] given typedef   
            //     LPCWSTR     szName,                 // [IN] member name 
            //     PCCOR_SIGNATURE pvSigBlob,          // [IN] point to a blob value of CLR signature 
            //     ULONG       cbSigBlob,              // [IN] count of bytes in the signature blob    
            //     mdToken     *pmb) PURE;             // [OUT] matching memberdef 
            void FindMember_();

            // STDMETHOD(FindMethod)(  
            //     mdTypeDef   td,                     // [IN] given typedef   
            //     LPCWSTR     szName,                 // [IN] member name 
            //     PCCOR_SIGNATURE pvSigBlob,          // [IN] point to a blob value of CLR signature 
            //     ULONG       cbSigBlob,              // [IN] count of bytes in the signature blob    
            //     mdMethodDef *pmb) PURE;             // [OUT] matching memberdef 
            void FindMethod(
                int td,
                [MarshalAs(UnmanagedType.LPWStr)] string szName,
                IntPtr pvSigBlob,
                int cbSigBlock,
                [Out] out int pmd);

            // STDMETHOD(FindField)(   
            //     mdTypeDef   td,                     // [IN] given typedef   
            //     LPCWSTR     szName,                 // [IN] member name 
            //     PCCOR_SIGNATURE pvSigBlob,          // [IN] point to a blob value of CLR signature 
            //     ULONG       cbSigBlob,              // [IN] count of bytes in the signature blob    
            //     mdFieldDef  *pmb) PURE;             // [OUT] matching memberdef 
            void FindField_();

            // STDMETHOD(FindMemberRef)(   
            //     mdTypeRef   td,                     // [IN] given typeRef   
            //     LPCWSTR     szName,                 // [IN] member name 
            //     PCCOR_SIGNATURE pvSigBlob,          // [IN] point to a blob value of CLR signature 
            //     ULONG       cbSigBlob,              // [IN] count of bytes in the signature blob    
            //     mdMemberRef *pmr) PURE;             // [OUT] matching memberref 
            void FindMemberRef_();

            // STDMETHOD (GetMethodProps)( 
            //     mdMethodDef mb,                     // The method for which to get props.   
            //     mdTypeDef   *pClass,                // Put method's class here. 
            //     LPWSTR      szMethod,               // Put method's name here.  
            //     ULONG       cchMethod,              // Size of szMethod buffer in wide chars.   
            //     ULONG       *pchMethod,             // Put actual size here 
            //     DWORD       *pdwAttr,               // Put flags here.  
            //     PCCOR_SIGNATURE *ppvSigBlob,        // [OUT] point to the blob value of meta data   
            //     ULONG       *pcbSigBlob,            // [OUT] actual size of signature blob  
            //     ULONG       *pulCodeRVA,            // [OUT] codeRVA    
            //     DWORD       *pdwImplFlags) PURE;    // [OUT] Impl. Flags    
            void GetMethodProps(
                int md,
                [Out] out int pClass,
                [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szMethod,
                int cchMethod,
                [Out] out int pchMethod,
                [Out] out int pdwAttr,
                [Out] out IntPtr ppvSigBlob,
                [Out] out int pcbSigBlob,
                [Out] out int pulCodeRVA,
                [Out] out int pdwImplFlags);

            // STDMETHOD(GetMemberRefProps)(           // S_OK or error.   
            //     mdMemberRef mr,                     // [IN] given memberref 
            //     mdToken     *ptk,                   // [OUT] Put classref or classdef here. 
            //     LPWSTR      szMember,               // [OUT] buffer to fill for member's name   
            //     ULONG       cchMember,              // [IN] the count of char of szMember   
            //     ULONG       *pchMember,             // [OUT] actual count of char in member name    
            //     PCCOR_SIGNATURE *ppvSigBlob,        // [OUT] point to meta data blob value  
            //     ULONG       *pbSig) PURE;           // [OUT] actual size of signature blob  
            void GetMemberRefProps(
                int mdMemberRef,
                [Out] out int mdToken,
                [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szMember,
                int cchMember,
                [Out] out int pchMember,
                [Out] out IntPtr ppvSigBlob,
                [Out] out int pcbSigBlob);

            // STDMETHOD(EnumProperties)(              // S_OK, S_FALSE, or error. 
            //     HCORENUM    *phEnum,                // [IN|OUT] Pointer to the enum.    
            //     mdTypeDef   td,                     // [IN] TypeDef to scope the enumeration.   
            //     mdProperty  rProperties[],          // [OUT] Put Properties here.   
            //     ULONG       cMax,                   // [IN] Max properties to put.  
            //     ULONG       *pcProperties) PURE;    // [OUT] Put # put here.    
            void EnumProperties(
                ref IntPtr phEnum,
                int tkType,
                out int mdPropertyDef,
                int cMax /* must be 1 */,
                out int pcTokens);

            // STDMETHOD(EnumEvents)(                  // S_OK, S_FALSE, or error. 
            //     HCORENUM    *phEnum,                // [IN|OUT] Pointer to the enum.    
            //     mdTypeDef   td,                     // [IN] TypeDef to scope the enumeration.   
            //     mdEvent     rEvents[],              // [OUT] Put events here.   
            //     ULONG       cMax,                   // [IN] Max events to put.  
            //     ULONG       *pcEvents) PURE;        // [OUT] Put # put here.    
            void EnumEvents(
                ref IntPtr phEnum,
                int tkType,
                out int mdEventDef,
                int cMax /* must be 1 */,
                out int pcTokens);

            // STDMETHOD(GetEventProps)(               // S_OK, S_FALSE, or error. 
            //     mdEvent     ev,                     // [IN] event token 
            //     mdTypeDef   *pClass,                // [OUT] typedef containing the event declarion.    
            //     LPCWSTR     szEvent,                // [OUT] Event name 
            //     ULONG       cchEvent,               // [IN] the count of wchar of szEvent   
            //     ULONG       *pchEvent,              // [OUT] actual count of wchar for event's name 
            //     DWORD       *pdwEventFlags,         // [OUT] Event flags.   
            //     mdToken     *ptkEventType,          // [OUT] EventType class    
            //     mdMethodDef *pmdAddOn,              // [OUT] AddOn method of the event  
            //     mdMethodDef *pmdRemoveOn,           // [OUT] RemoveOn method of the event   
            //     mdMethodDef *pmdFire,               // [OUT] Fire method of the event   
            //     mdMethodDef rmdOtherMethod[],       // [OUT] other method of the event  
            //     ULONG       cMax,                   // [IN] size of rmdOtherMethod  
            //     ULONG       *pcOtherMethod) PURE;   // [OUT] total number of other method of this event 
            void GetEventProps(
                int ed,
                [Out] out int pClass,
                [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szEvent,
                int cchEvent,
                [Out] out int pchEvent,
                [Out] out int pdwAttr,
                [Out] out int ptkEventType,
                [Out] out int pmdAddOn,
                [Out] out int pmdRemoveOn,
                [Out] out int pmdFire,
                [Out] out int pmdOtherMethod,
                int cOtherMethod,
                [Out] out int pcOtherMethod);

            // STDMETHOD(EnumMethodSemantics)(         // S_OK, S_FALSE, or error. 
            //     HCORENUM    *phEnum,                // [IN|OUT] Pointer to the enum.    
            //     mdMethodDef mb,                     // [IN] MethodDef to scope the enumeration. 
            //     mdToken     rEventProp[],           // [OUT] Put Event/Property here.   
            //     ULONG       cMax,                   // [IN] Max properties to put.  
            //     ULONG       *pcEventProp) PURE;     // [OUT] Put # put here.    
            void EnumMethodSemantics_();

            // STDMETHOD(GetMethodSemantics)(          // S_OK, S_FALSE, or error. 
            //     mdMethodDef mb,                     // [IN] method token    
            //     mdToken     tkEventProp,            // [IN] event/property token.   
            //     DWORD       *pdwSemanticsFlags) PURE; // [OUT] the role flags for the method/propevent pair 
            void GetMethodSemantics_();

            // STDMETHOD(GetClassLayout) ( 
            //     mdTypeDef   td,                     // [IN] give typedef    
            //     DWORD       *pdwPackSize,           // [OUT] 1, 2, 4, 8, or 16  
            //     COR_FIELD_OFFSET rFieldOffset[],    // [OUT] field offset array 
            //     ULONG       cMax,                   // [IN] size of the array   
            //     ULONG       *pcFieldOffset,         // [OUT] needed array size  
            //     ULONG       *pulClassSize) PURE;        // [OUT] the size of the class  
            void GetClassLayout_();

            // STDMETHOD(GetFieldMarshal) (    
            //     mdToken     tk,                     // [IN] given a field's memberdef   
            //     PCCOR_SIGNATURE *ppvNativeType,     // [OUT] native type of this field  
            //     ULONG       *pcbNativeType) PURE;   // [OUT] the count of bytes of *ppvNativeType   
            void GetFieldMarshal_();

            // STDMETHOD(GetRVA)(                      // S_OK or error.   
            //     mdToken     tk,                     // Member for which to set offset   
            //     ULONG       *pulCodeRVA,            // The offset   
            //     DWORD       *pdwImplFlags) PURE;    // the implementation flags 
            void GetRVA_();

            // STDMETHOD(GetPermissionSetProps) (  
            //     mdPermission pm,                    // [IN] the permission token.   
            //     DWORD       *pdwAction,             // [OUT] CorDeclSecurity.   
            //     void const  **ppvPermission,        // [OUT] permission blob.   
            //     ULONG       *pcbPermission) PURE;   // [OUT] count of bytes of pvPermission.    
            void GetPermissionSetProps_();

            // STDMETHOD(GetSigFromToken)(             // S_OK or error.   
            //     mdSignature mdSig,                  // [IN] Signature token.    
            //     PCCOR_SIGNATURE *ppvSig,            // [OUT] return pointer to token.   
            //     ULONG       *pcbSig) PURE;          // [OUT] return size of signature.  
            void GetSigFromToken_();

            // STDMETHOD(GetModuleRefProps)(           // S_OK or error.   
            //     mdModuleRef mur,                    // [IN] moduleref token.    
            //     LPWSTR      szName,                 // [OUT] buffer to fill with the moduleref name.    
            //     ULONG       cchName,                // [IN] size of szName in wide characters.  
            //     ULONG       *pchName) PURE;         // [OUT] actual count of characters in the name.    
            void GetModuleRefProps_();

            // STDMETHOD(EnumModuleRefs)(              // S_OK or error.   
            //     HCORENUM    *phEnum,                // [IN|OUT] pointer to the enum.    
            //     mdModuleRef rModuleRefs[],          // [OUT] put modulerefs here.   
            //     ULONG       cmax,                   // [IN] max memberrefs to put.  
            //     ULONG       *pcModuleRefs) PURE;    // [OUT] put # put here.    
            void EnumModuleRefs_();

            // STDMETHOD(GetTypeSpecFromToken)(        // S_OK or error.   
            //     mdTypeSpec typespec,                // [IN] TypeSpec token.    
            //     PCCOR_SIGNATURE *ppvSig,            // [OUT] return pointer to TypeSpec signature  
            //     ULONG       *pcbSig) PURE;          // [OUT] return size of signature.  
            void GetTypeSpecFromToken_();

            // STDMETHOD(GetNameFromToken)(            // Not Recommended! May be removed!
            //     mdToken     tk,                     // [IN] Token to get name from.  Must have a name.
            //     MDUTF8CSTR  *pszUtf8NamePtr) PURE;  // [OUT] Return pointer to UTF8 name in heap.
            void GetNameFromToken_();

            // STDMETHOD(EnumUnresolvedMethods)(       // S_OK, S_FALSE, or error. 
            //     HCORENUM    *phEnum,                // [IN|OUT] Pointer to the enum.    
            //     mdToken     rMethods[],             // [OUT] Put MemberDefs here.   
            //     ULONG       cMax,                   // [IN] Max MemberDefs to put.  
            //     ULONG       *pcTokens) PURE;        // [OUT] Put # put here.
            void EnumUnresolvedMethods_();

            // STDMETHOD(GetUserString)(               // S_OK or error.
            //     mdString    stk,                    // [IN] String token.
            //     LPWSTR      szString,               // [OUT] Copy of string.
            //     ULONG       cchString,              // [IN] Max chars of room in szString.
            //     ULONG       *pchString) PURE;       // [OUT] How many chars in actual string.
            void GetUserString_();

            // STDMETHOD(GetPinvokeMap)(               // S_OK or error.
            //     mdToken     tk,                     // [IN] FieldDef or MethodDef.
            //     DWORD       *pdwMappingFlags,       // [OUT] Flags used for mapping.
            //     LPWSTR      szImportName,           // [OUT] Import name.
            //     ULONG       cchImportName,          // [IN] Size of the name buffer.
            //     ULONG       *pchImportName,         // [OUT] Actual number of characters stored.
            //     mdModuleRef *pmrImportDLL) PURE;    // [OUT] ModuleRef token for the target DLL.
            void GetPinvokeMap_();

            // STDMETHOD(EnumSignatures)(              // S_OK or error.
            //     HCORENUM    *phEnum,                // [IN|OUT] pointer to the enum.    
            //     mdSignature rSignatures[],          // [OUT] put signatures here.   
            //     ULONG       cmax,                   // [IN] max signatures to put.  
            //     ULONG       *pcSignatures) PURE;    // [OUT] put # put here.
            void EnumSignatures_();

            // STDMETHOD(EnumTypeSpecs)(               // S_OK or error.
            //     HCORENUM    *phEnum,                // [IN|OUT] pointer to the enum.    
            //     mdTypeSpec  rTypeSpecs[],           // [OUT] put TypeSpecs here.   
            //     ULONG       cmax,                   // [IN] max TypeSpecs to put.  
            //     ULONG       *pcTypeSpecs) PURE;     // [OUT] put # put here.
            void EnumTypeSpecs_();

            // STDMETHOD(EnumUserStrings)(             // S_OK or error.
            //     HCORENUM    *phEnum,                // [IN/OUT] pointer to the enum.
            //     mdString    rStrings[],             // [OUT] put Strings here.
            //     ULONG       cmax,                   // [IN] max Strings to put.
            //     ULONG       *pcStrings) PURE;       // [OUT] put # put here.
            void EnumUserStrings_();

            // STDMETHOD(GetParamForMethodIndex)(      // S_OK or error.
            //     mdMethodDef md,                     // [IN] Method token.
            //     ULONG       ulParamSeq,             // [IN] Parameter sequence.
            //     mdParamDef  *ppd) PURE;             // [IN] Put Param token here.
            void GetParamForMethodIndex_();

            // STDMETHOD(EnumCustomAttributes)(        // S_OK or error.
            //     HCORENUM    *phEnum,                // [IN, OUT] COR enumerator.
            //     mdToken     tk,                     // [IN] Token to scope the enumeration, 0 for all.
            //     mdToken     tkType,                 // [IN] Type of interest, 0 for all.
            //     mdCustomAttribute rCustomAttributes[], // [OUT] Put custom attribute tokens here.
            //     ULONG       cMax,                   // [IN] Size of rCustomAttributes.
            //     ULONG       *pcCustomAttributes) PURE;  // [OUT, OPTIONAL] Put count of token values here.
            void EnumCustomAttributes(
                ref IntPtr phEnum,
                int tkItem,
                int tkType,
                out int mdAttributeDef,
                int cMax /* must be 1 */,
                out int pcTokens);

            // STDMETHOD(GetCustomAttributeProps)(     // S_OK or error.
            //     mdCustomAttribute cv,               // [IN] CustomAttribute token.
            //     mdToken     *ptkObj,                // [OUT, OPTIONAL] Put object token here.
            //     mdToken     *ptkType,               // [OUT, OPTIONAL] Put AttrType token here.
            //     void const  **ppBlob,               // [OUT, OPTIONAL] Put pointer to data here.
            //     ULONG       *pcbSize) PURE;         // [OUT, OPTIONAL] Put size of date here.
            void GetCustomAttributeProps(
                int attributeToken,
                [Out] out int tkObj,
                [Out] out int tkType,
                [Out] out IntPtr ppData,
                [Out] out int pcbData);

            // STDMETHOD(FindTypeRef)(   
            //     mdToken     tkResolutionScope,      // [IN] ModuleRef, AssemblyRef or TypeRef.
            //     LPCWSTR     szName,                 // [IN] TypeRef Name.
            //     mdTypeRef   *ptr) PURE;             // [OUT] matching TypeRef.
            void FindTypeRef_();

            // STDMETHOD(GetMemberProps)(  
            //     mdToken     mb,                     // The member for which to get props.   
            //     mdTypeDef   *pClass,                // Put member's class here. 
            //     LPWSTR      szMember,               // Put member's name here.  
            //     ULONG       cchMember,              // Size of szMember buffer in wide chars.   
            //     ULONG       *pchMember,             // Put actual size here 
            //     DWORD       *pdwAttr,               // Put flags here.  
            //     PCCOR_SIGNATURE *ppvSigBlob,        // [OUT] point to the blob value of meta data   
            //     ULONG       *pcbSigBlob,            // [OUT] actual size of signature blob  
            //     ULONG       *pulCodeRVA,            // [OUT] codeRVA    
            //     DWORD       *pdwImplFlags,          // [OUT] Impl. Flags    
            //     DWORD       *pdwCPlusTypeFlag,      // [OUT] flag for value type. selected ELEMENT_TYPE_*   
            //     void const  **ppValue,              // [OUT] constant value 
            //     ULONG       *pcchValue) PURE;       // [OUT] size of constant string in chars, 0 for non-strings.
            void GetMemberProps_();

            // STDMETHOD(GetFieldProps)(  
            //     mdFieldDef  mb,                     // The field for which to get props.    
            //     mdTypeDef   *pClass,                // Put field's class here.  
            //     LPWSTR      szField,                // Put field's name here.   
            //     ULONG       cchField,               // Size of szField buffer in wide chars.    
            //     ULONG       *pchField,              // Put actual size here 
            //     DWORD       *pdwAttr,               // Put flags here.  
            //     PCCOR_SIGNATURE *ppvSigBlob,        // [OUT] point to the blob value of meta data   
            //     ULONG       *pcbSigBlob,            // [OUT] actual size of signature blob  
            //     DWORD       *pdwCPlusTypeFlag,      // [OUT] flag for value type. selected ELEMENT_TYPE_*   
            //     void const  **ppValue,              // [OUT] constant value 
            //     ULONG       *pcchValue) PURE;       // [OUT] size of constant string in chars, 0 for non-strings.
            void GetFieldProps(
                int fd,
                [Out] out int tkTypeDef,
                [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szField,
                int cchField,
                out int pchField,
                out int pdwAttr,
                out IntPtr ppvSigBlob,
                out int pcbSigBlob,
                out int pdwValueTypeFlag,
                out IntPtr ppValue,
                out int pcchValue);

            // STDMETHOD(GetPropertyProps)(            // S_OK, S_FALSE, or error. 
            //     mdProperty  prop,                   // [IN] property token  
            //     mdTypeDef   *pClass,                // [OUT] typedef containing the property declarion. 
            //     LPCWSTR     szProperty,             // [OUT] Property name  
            //     ULONG       cchProperty,            // [IN] the count of wchar of szProperty    
            //     ULONG       *pchProperty,           // [OUT] actual count of wchar for property name    
            //     DWORD       *pdwPropFlags,          // [OUT] property flags.    
            //     PCCOR_SIGNATURE *ppvSig,            // [OUT] property type. pointing to meta data internal blob 
            //     ULONG       *pbSig,                 // [OUT] count of bytes in *ppvSig  
            //     DWORD       *pdwCPlusTypeFlag,      // [OUT] flag for value type. selected ELEMENT_TYPE_*   
            //     void const  **ppDefaultValue,       // [OUT] constant value 
            //     ULONG       *pcchDefaultValue,      // [OUT] size of constant string in chars, 0 for non-strings.
            //     mdMethodDef *pmdSetter,             // [OUT] setter method of the property  
            //     mdMethodDef *pmdGetter,             // [OUT] getter method of the property  
            //     mdMethodDef rmdOtherMethod[],       // [OUT] other method of the property   
            //     ULONG       cMax,                   // [IN] size of rmdOtherMethod  
            //     ULONG       *pcOtherMethod) PURE;   // [OUT] total number of other method of this property
            void GetPropertyProps(
                int pd,
                [Out] out int pClass,
                [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szProperty,
                int cchProperty,
                [Out] out int pchProperty,
                [Out] out int pdwAttr,
                [Out] out IntPtr ppvSigBlob,
                [Out] out int pcbSigBlob,
                [Out] out int pTypeFlag,
                [Out] out IntPtr ppDefaultValue,
                [Out] out int pcchDefaultValue,
                [Out] out int pmdSetter,
                [Out] out int pmdGetter,
                [Out] out int pmdOtherMethod,
                int cOtherMethod,
                [Out] out int pcOtherMethod);

            // STDMETHOD(GetParamProps)(               // S_OK or error.
            //     mdParamDef  tk,                     // [IN]The Parameter.
            //     mdMethodDef *pmd,                   // [OUT] Parent Method token.
            //     ULONG       *pulSequence,           // [OUT] Parameter sequence.
            //     LPWSTR      szName,                 // [OUT] Put name here.
            //     ULONG       cchName,                // [OUT] Size of name buffer.
            //     ULONG       *pchName,               // [OUT] Put actual size of name here.
            //     DWORD       *pdwAttr,               // [OUT] Put flags here.
            //     DWORD       *pdwCPlusTypeFlag,      // [OUT] Flag for value type. selected ELEMENT_TYPE_*.
            //     void const  **ppValue,              // [OUT] Constant value.
            //     ULONG       *pcchValue) PURE;       // [OUT] size of constant string in chars, 0 for non-strings.
            void GetParamProps_();

            // STDMETHOD(GetCustomAttributeByName)(    // S_OK or error.
            //     mdToken     tkObj,                  // [IN] Object with Custom Attribute.
            //     LPCWSTR     szName,                 // [IN] Name of desired Custom Attribute.
            //     const void  **ppData,               // [OUT] Put pointer to data here.
            //     ULONG       *pcbData) PURE;         // [OUT] Put size of data here.
            void GetCustomAttributeByName(
                int tkItem,
                [MarshalAs(UnmanagedType.LPWStr)] string szName,
                [Out] out IntPtr ppData,
                [Out] out int pcbData);

            // STDMETHOD_(BOOL, IsValidToken)(         // True or False.
            //     mdToken     tk) PURE;               // [IN] Given token.
            [PreserveSig]
            bool IsValidToken([MarshalAs(UnmanagedType.U4)] int tk);

            // STDMETHOD(GetNestedClassProps)(         // S_OK or error.
            //     mdTypeDef   tdNestedClass,          // [IN] NestedClass token.
            //     mdTypeDef   *ptdEnclosingClass) PURE; // [OUT] EnclosingClass token.
            void GetNestedClassProps_();

            // STDMETHOD(GetNativeCallConvFromSig)(    // S_OK or error.
            //     void const  *pvSig,                 // [IN] Pointer to signature.
            //     ULONG       cbSig,                  // [IN] Count of signature bytes.
            //     ULONG       *pCallConv) PURE;       // [OUT] Put calling conv here (see CorPinvokemap).
            void GetNativeCallConvFromSig_();

            // STDMETHOD(IsGlobal)(                    // S_OK or error.
            //     mdToken     pd,                     // [IN] Type, Field, or Method token.
            //     int         *pbGlobal) PURE;        // [OUT] Put 1 if global, 0 otherwise.
            void IsGlobal_();
        }

        [
        ComImport,
        Guid("EE62470B-E94B-424e-9B7C-2F00C9249F93"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)
        ]
        public interface IMetadataAssemblyImport {

            [PreserveSig]
            int GetAssemblyProps(
                UInt32 mdAsm,
                out IntPtr pPublicKeyPtr,
                out UInt32 ucbPublicKeyPtr,
                out UInt32 uHashAlg,
                [MarshalAs(UnmanagedType.LPArray)] char[] strName,
                UInt32 cchNameIn,
                out UInt32 cchNameRequired,
                IntPtr amdInfo,
                out UInt32 dwFlags
                );

            [PreserveSig]
            int GetAssemblyRefProps(
                UInt32 mdAsmRef,
                out IntPtr ppbPublicKeyOrToken,
                out UInt32 pcbPublicKeyOrToken,
                [MarshalAs(UnmanagedType.LPArray)] char[] strName,
                UInt32 cchNameIn,
                out UInt32 pchNameOut,
                IntPtr amdInfo,
                out IntPtr ppbHashValue,
                out UInt32 pcbHashValue,
                out UInt32 pdwAssemblyRefFlags
                );

            [PreserveSig]
            int GetFileProps(
                [In] UInt32 mdFile,
                [MarshalAs(UnmanagedType.LPArray)] char[] strName,
                UInt32 cchName,
                out UInt32 cchNameRequired,
                out IntPtr bHashData,
                out UInt32 cchHashBytes,
                out UInt32 dwFileFlags
                );

            [PreserveSig]
            int GetExportedTypeProps();

            [PreserveSig]
            int GetManifestResourceProps();

            [PreserveSig]
            int EnumAssemblyRefs(
                [In, Out] ref IntPtr phEnum,
                [MarshalAs(UnmanagedType.LPArray), Out] UInt32[] asmRefs,
                System.UInt32 asmRefCount,
                out System.UInt32 iFetched
            );

            [PreserveSig]
            int EnumFiles(
                [In, Out] ref IntPtr phEnum,
                [MarshalAs(UnmanagedType.LPArray), Out] UInt32[] fileRefs,
                System.UInt32 fileRefCount,
                out System.UInt32 iFetched
                );

            [PreserveSig]
            void EnumExportedTypes();

            [PreserveSig]
            int EnumManifestResources();

            [PreserveSig]
            int GetAssemblyFromScope(out int mdAsm);

            [PreserveSig]
            int FindExportedTypeByName();

            [PreserveSig]
            int FindManifestResourceByName();

            // PreserveSig because this method is an exception that 
            // actually returns void, not HRESULT.
            [PreserveSig]
            void CloseEnum([In] IntPtr phEnum);

            [PreserveSig]
            int FindAssembliesByName();
        }
    }
}
