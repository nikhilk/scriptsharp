// Buffer.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.IO {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class Buffer {

        public Buffer(int size) {
        }

        public Buffer(int[] data) {
        }

        public Buffer(string data) {
        }

        public Buffer(string data, Encoding encoding) {
        }

        [ScriptField]
        public int Length {
            get {
                return 0;
            }
        }

        public int this[int index] {
            get {
                return 0;
            }
            set {
            }
        }

        public static Buffer Concat(Buffer[] buffers) {
            return null;
        }

        public static Buffer Concat(Buffer[] buffers, int count) {
            return null;
        }

        public void Copy(Buffer targetBuffer) {
        }

        public void Copy(Buffer targetBuffer, int targetStart) {
        }

        public void Copy(Buffer targetBuffer, int targetStart, int sourceStart) {
        }

        public void Copy(Buffer targetBuffer, int targetStart, int sourceStart, int sourceLength) {
        }

        public void Fill(int i) {
        }

        public void Fill(int i, int offset) {
        }

        public void Fill(int i, int offset, int end) {
        }

        [ScriptName("byteLength")]
        public static int GetByteLength(string s) {
            return 0;
        }

        [ScriptName("byteLength")]
        public static int GetByteLength(string s, Encoding encoding) {
            return 0;
        }

        public static bool IsBuffer(object o) {
            return false;
        }

        [ScriptName("readInt8")]
        public byte ReadByte(int offset) {
            return 0;
        }

        public double ReadDoubleBE(int offset) {
            return 0;
        }

        public double ReadDoubleLE(int offset) {
            return 0;
        }

        [ScriptName("readFloatBE")]
        public float ReadSingleBE(int offset) {
            return 0;
        }

        [ScriptName("readFloatLE")]
        public float ReadSingleLE(int offset) {
            return 0;
        }

        [ScriptName("readUInt8")]
        public byte ReadUByte(int offset) {
            return 0;
        }

        public short ReadInt16BE(int offset) {
            return 0;
        }

        public short ReadInt16LE(int offset) {
            return 0;
        }

        public int ReadInt32BE(int offset) {
            return 0;
        }

        public int ReadInt32LE(int offset) {
            return 0;
        }

        public short ReadUInt16BE(int offset) {
            return 0;
        }

        public short ReadUInt16LE(int offset) {
            return 0;
        }

        public int ReadUInt32BE(int offset) {
            return 0;
        }

        public int ReadUInt32LE(int offset) {
            return 0;
        }

        public Buffer Slice() {
            return null;
        }

        public Buffer Slice(int start) {
            return null;
        }

        public Buffer Slice(int start, int end) {
            return null;
        }

        public string ToString(Encoding encoding) {
            return null;
        }

        public string ToString(Encoding encoding, int start) {
            return null;
        }

        public string ToString(Encoding encoding, int start, int end) {
            return null;
        }

        public int Write(string s) {
            return 0;
        }

        public int Write(string s, int offset) {
            return 0;
        }

        public int Write(string s, int offset, int length) {
            return 0;
        }

        public int Write(string s, int offset, int length, Encoding encoding) {
            return 0;
        }

        [ScriptName("writeInt8")]
        public void WriteByte(byte b, int offset) {
        }

        public void WriteDoubleBE(double value, int offset) {
        }

        public void WriteDoubleLE(double value, int offset) {
        }

        public void WriteInt16BE(short value, int offset) {
        }

        public void WriteInt16LE(short value, int offset) {
        }

        public void WriteInt32BE(int value, int offset) {
        }

        public void WriteInt32LE(int value, int offset) {
        }

        [ScriptName("writeFloatBE")]
        public void WriteSingleBE(float value, int offset) {
        }

        [ScriptName("writeFloatLE")]
        public void WriteSingleLE(float value, int offset) {
        }

        [ScriptName("writeUInt8")]
        public void WriteUByte(byte b, int offset) {
        }

        public void WriteUInt16BE(short value, int offset) {
        }

        public void WriteUInt16LE(short value, int offset) {
        }

        public void WriteUInt32BE(int value, int offset) {
        }

        public void WriteUInt32LE(int value, int offset) {
        }
    }
}
