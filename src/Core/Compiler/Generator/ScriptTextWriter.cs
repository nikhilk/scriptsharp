// ScriptTextWriter.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace ScriptSharp.Generator {

    internal sealed class ScriptTextWriter : TextWriter {

        private TextWriter _writer;

        private int _indentLevel;
        private bool _tabsPending;
        private string _tabString;

        private TextWriter _globalWriter;
        private int _globalIndentLevel;
        private bool _globalTabsPending;

        public ScriptTextWriter(TextWriter writer)
            : base(CultureInfo.InvariantCulture) {
            _writer = writer;
            _globalWriter = writer;

            _tabString = "  ";
            _indentLevel = 0;
            _tabsPending = false;
        }

        public override Encoding Encoding {
            get {
                return _writer.Encoding;
            }
        }

        public override string NewLine {
            get {
                return _writer.NewLine;
            }
            set {
                _writer.NewLine = value;
            }
        }

        public int Indent {
            get {
                return _indentLevel;
            }
            set {
                Debug.Assert(value >= 0);
                if (value < 0) {
                    value = 0;
                }
                _indentLevel = value;
            }
        }

        public override void Close() {
            _writer.Close();
        }

        public override void Flush() {
            _writer.Flush();
        }

        private void OutputTabs() {
            if (_tabsPending) {
                for (int i = 0; i < _indentLevel; i++) {
                    _writer.Write(_tabString);
                }
                _tabsPending = false;
            }
        }

        public void StartLocalWriting(TextWriter writer) {
            Debug.Assert(writer != null);
            Debug.Assert(_writer == _globalWriter);
            _writer = writer;

            _globalIndentLevel = _indentLevel;
            _indentLevel = 0;

            _globalTabsPending = _tabsPending;
            _tabsPending = false;
        }

        public void StopLocalWriting() {
            _writer = _globalWriter;
            _indentLevel = _globalIndentLevel;
            _tabsPending = _globalTabsPending;
        }

        public override void Write(string s) {
            OutputTabs();
            _writer.Write(s);
        }

        public override void Write(bool value) {
            OutputTabs();
            _writer.Write(value);
        }

        public override void Write(char value) {
            OutputTabs();
            _writer.Write(value);
        }

        public override void Write(char[] buffer) {
            OutputTabs();
            _writer.Write(buffer);
        }

        public override void Write(char[] buffer, int index, int count) {
            OutputTabs();
            _writer.Write(buffer, index, count);
        }

        public override void Write(double value) {
            OutputTabs();
            _writer.Write(value);
        }

        public override void Write(float value) {
            OutputTabs();
            _writer.Write(value);
        }

        public override void Write(int value) {
            OutputTabs();
            _writer.Write(value);
        }

        public override void Write(long value) {
            OutputTabs();
            _writer.Write(value);
        }

        public override void Write(object value) {
            OutputTabs();
            _writer.Write(value);
        }

        public override void Write(string format, object arg0) {
            OutputTabs();
            _writer.Write(format, arg0);
        }

        public override void Write(string format, object arg0, object arg1) {
            OutputTabs();
            _writer.Write(format, arg0, arg1);
        }

        public override void Write(string format, params object[] arg) {
            OutputTabs();
            _writer.Write(format, arg);
        }

        public override void WriteLine() {
            _writer.WriteLine();
            _tabsPending = true;
        }

        public override void WriteLine(string s) {
            OutputTabs();
            _writer.WriteLine(s);
            _tabsPending = true;
        }

        public override void WriteLine(bool value) {
            OutputTabs();
            _writer.WriteLine(value);
            _tabsPending = true;
        }

        public override void WriteLine(char value) {
            OutputTabs();
            _writer.WriteLine(value);
            _tabsPending = true;
        }

        public override void WriteLine(char[] buffer) {
            OutputTabs();
            _writer.WriteLine(buffer);
            _tabsPending = true;
        }

        public override void WriteLine(char[] buffer, int index, int count) {
            OutputTabs();
            _writer.WriteLine(buffer, index, count);
            _tabsPending = true;
        }

        public override void WriteLine(double value) {
            OutputTabs();
            _writer.WriteLine(value);
            _tabsPending = true;
        }

        public override void WriteLine(float value) {
            OutputTabs();
            _writer.WriteLine(value);
            _tabsPending = true;
        }

        public override void WriteLine(int value) {
            OutputTabs();
            _writer.WriteLine(value);
            _tabsPending = true;
        }

        public override void WriteLine(long value) {
            OutputTabs();
            _writer.WriteLine(value);
            _tabsPending = true;
        }

        public override void WriteLine(object value) {
            OutputTabs();
            _writer.WriteLine(value);
            _tabsPending = true;
        }

        public override void WriteLine(string format, object arg0) {
            OutputTabs();
            _writer.WriteLine(format, arg0);
            _tabsPending = true;
        }

        public override void WriteLine(string format, object arg0, object arg1) {
            OutputTabs();
            _writer.WriteLine(format, arg0, arg1);
            _tabsPending = true;
        }

        public override void WriteLine(string format, params object[] arg) {
            OutputTabs();
            _writer.WriteLine(format, arg);
            _tabsPending = true;
        }

        public override void WriteLine(UInt32 value) {
            OutputTabs();
            _writer.WriteLine(value);
            _tabsPending = true;
        }
    }
}
