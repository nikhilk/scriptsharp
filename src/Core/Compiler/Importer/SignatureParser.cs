// SigatureParser.cs
// Script#/Core/ScriptSharp
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using ScriptSharp;
using ScriptSharp.ScriptModel;

namespace ScriptSharp.Importer {

    internal sealed class SignatureParser {

        private SymbolSet _symbols;
        private ICompilerErrorHandler _errorHandler;

        private Interop.IMetadataImport _mdImport;
        private IntPtr _signatureBytes;
        private int _signatureLength;

        private int _signatureIndex;

        public SignatureParser(SymbolSet symbols, ICompilerErrorHandler errorHandler) {
            _symbols = symbols;
            _errorHandler = errorHandler;
        }

        private bool CanRead {
            get {
                return (_signatureIndex < _signatureLength);
            }
        }

        public TypeSymbol Parse(Interop.IMetadataImport mdImport, IntPtr signatureBytes, int signatureLength) {
            bool dummy;
            return Parse(mdImport, signatureBytes, signatureLength, out dummy);
        }

        public TypeSymbol Parse(Interop.IMetadataImport mdImport, IntPtr signatureBytes, int signatureLength, out bool isIndexer) {
            _mdImport = mdImport;
            _signatureBytes = signatureBytes;
            _signatureLength = signatureLength;
            _signatureIndex = 0;

            isIndexer = false;

            byte signatureMarker = Read();
            byte typeMarker = (byte)(signatureMarker & 0xF);
            switch (typeMarker) {
                case Interop.SIG_FIELD:
                    return ParseField();
                case Interop.SIG_PROPERTY:
                    return ParseProperty(out isIndexer);
                case Interop.SIG_METHOD_DEFAULT:
                case Interop.SIG_METHOD_C:
                case Interop.SIG_METHOD_THISCALL:
                case Interop.SIG_METHOD_VARARG:
                case Interop.SIG_METHOD_STDCALL:
                case Interop.SIG_METHOD_FASTCALL:
                    bool isGeneric = ((signatureMarker & Interop.SIG_GENERIC) != 0);
                    return ParseMethod(isGeneric);
                default:
                    // TODO: Error
                    Debug.Fail("Unexpected signature type");
                    return null;
            }
        }

        private TypeSymbol ParseField() {
            return ReadType();
        }

        private TypeSymbol ParseMethod(bool isGeneric) {
            if (isGeneric) {
                int genericArguments = ReadNumber();
            }

            // Skip parameter count
            ReadNumber();

            byte typeMarker = Peek();
            if (typeMarker == Interop.ELEMENT_TYPE_VOID) {
                Read();

                TypeSymbol typeSymbol =
                    (TypeSymbol)((ISymbolTable)_symbols.SystemNamespace).FindSymbol("Void", null, SymbolFilter.Types);
                Debug.Assert(typeSymbol != null);

                return typeSymbol;
            }

            return ReadType();
        }

        private TypeSymbol ParseProperty(out bool isIndexer) {
            int parameterCount = ReadNumber();
            isIndexer = (parameterCount != 0);

            return ReadType();
        }

        private byte Peek() {
            return Marshal.ReadByte(_signatureBytes, _signatureIndex);
        }

        private byte Read() {
            Debug.Assert(CanRead);

            byte b = Marshal.ReadByte(_signatureBytes, _signatureIndex);
            _signatureIndex++;

            return b;
        }

        private TypeSymbol ReadArray() {
            TypeSymbol itemTypeSymbol = ReadType();
            if (itemTypeSymbol != null) {
                return TypeSymbol.CreateArrayType(itemTypeSymbol, _symbols);
            }

            return null;
        }

        private TypeSymbol ReadClass() {
            int encodedToken = ReadNumber();
            byte tokenType = (byte)(encodedToken & 0x3);
            int index = (encodedToken >> 2);

            StringBuilder nameBuilder = null;

            Debug.Assert((tokenType == Interop.SIG_INDEX_TYPE_TYPEDEF) ||
                         (tokenType == Interop.SIG_INDEX_TYPE_TYPEREF));
            if (tokenType == Interop.SIG_INDEX_TYPE_TYPEDEF) {
                int typeNameLength;
                int typeFlags;
                int typeExtendsToken;

                int token = index | (int)Interop.CorTokenType.mdtTypeDef;

                _mdImport.GetTypeDefProps(token, null, 0, out typeNameLength,
                                          out typeFlags, out typeExtendsToken);
                nameBuilder = new StringBuilder(typeNameLength);
                _mdImport.GetTypeDefProps(token,
                                          nameBuilder, typeNameLength, out typeNameLength,
                                          out typeFlags, out typeExtendsToken);
            }
            else if (tokenType == Interop.SIG_INDEX_TYPE_TYPEREF) {
                int typeNameLength;
                int scopeToken;

                int token = index | (int)Interop.CorTokenType.mdtTypeRef;

                _mdImport.GetTypeRefProps(token, out scopeToken, null, 0, out typeNameLength);
                nameBuilder = new StringBuilder(typeNameLength);
                _mdImport.GetTypeRefProps(token, out scopeToken,
                                          nameBuilder, typeNameLength, out typeNameLength);
            }

            Debug.Assert(nameBuilder != null);

            string typeName = nameBuilder.ToString();

            TypeSymbol typeSymbol = (TypeSymbol)((ISymbolTable)_symbols).FindSymbol(typeName, null, SymbolFilter.Types);
            Debug.Assert(typeSymbol != null);

            return typeSymbol;
        }

        private int ReadNumber() {
            byte b1 = Read();

            if (b1 == 0xFF) {
                // Special encoding of NULL
                return 0;
            }

            if ((b1 & 0x80) == 0) {
                // 1-byte encoding
                return (int)b1;
            }

            byte b2 = Read();

            if ((b1 & 0x40) == 0) {
                // 2-byte encoding
                return (((b1 & 0x3F) << 8) | b2);
            }

            // 4-byte encoding
            Debug.Assert((b1 & 0x20) == 0);

            byte b3 = Read();
            byte b4 = Read();

            return (((b1 & 0x1F) << 24) | (b2 << 16) | (b3 << 8) | b4);
        }

        private TypeSymbol ReadType() {
            byte typeMarker = Read();
            string typeName = null;

            switch (typeMarker) {
                case Interop.ELEMENT_TYPE_BOOLEAN:
                    typeName = "Boolean";
                    break;
                case Interop.ELEMENT_TYPE_CHAR:
                    typeName = "Char";
                    break;
                case Interop.ELEMENT_TYPE_I1:
                    typeName = "SByte";
                    break;
                case Interop.ELEMENT_TYPE_U1:
                    typeName = "Byte";
                    break;
                case Interop.ELEMENT_TYPE_I2:
                    typeName = "Int16";
                    break;
                case Interop.ELEMENT_TYPE_U2:
                    typeName = "UInt16";
                    break;
                case Interop.ELEMENT_TYPE_I4:
                    typeName = "Int32";
                    break;
                case Interop.ELEMENT_TYPE_U4:
                    typeName = "UInt32";
                    break;
                case Interop.ELEMENT_TYPE_I8:
                    typeName = "Int64";
                    break;
                case Interop.ELEMENT_TYPE_U8:
                    typeName = "UInt64";
                    break;
                case Interop.ELEMENT_TYPE_I:
                    typeName = "IntPtr";
                    break;
                case Interop.ELEMENT_TYPE_U:
                    typeName = "UIntPtr";
                    break;
                case Interop.ELEMENT_TYPE_R4:
                    typeName = "Single";
                    break;
                case Interop.ELEMENT_TYPE_R8:
                    typeName = "Double";
                    break;
                case Interop.ELEMENT_TYPE_STRING:
                    typeName = "String";
                    break;
                case Interop.ELEMENT_TYPE_OBJECT:
                    typeName = "Object";
                    break;
                case Interop.ELEMENT_TYPE_CLASS:
                case Interop.ELEMENT_TYPE_VALUETYPE:
                    return ReadClass();
                case Interop.ELEMENT_TYPE_SZARRAY:
                    return ReadArray();
                case Interop.ELEMENT_TYPE_PTR:
                case Interop.ELEMENT_TYPE_FNPTR:
                case Interop.ELEMENT_TYPE_GENERICINST:
                case Interop.ELEMENT_TYPE_VAR:
                case Interop.ELEMENT_TYPE_ARRAY:
                    // TODO: Error handler
                    Debug.Fail("Unsupported types");
                    break;
                case Interop.ELEMENT_TYPE_MVAR:
                    typeName = "Object";
                    break;
                default:
                    Debug.Fail("Unexpected type");
                    break;
            }

            if (typeName != null) {
                TypeSymbol typeSymbol =
                    (TypeSymbol)((ISymbolTable)_symbols.SystemNamespace).FindSymbol(typeName, null, SymbolFilter.Types);
                Debug.Assert(typeSymbol != null);

                if (typeMarker == Interop.ELEMENT_TYPE_MVAR) {
                    int genericArgIndex = ReadNumber();
                    typeSymbol = new GenericTypeSymbol(genericArgIndex, (NamespaceSymbol)typeSymbol.Parent);
                }

                return typeSymbol;
            }

            // TODO: Error handler
            return null;
        }
    }
}
