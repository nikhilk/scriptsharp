// IndentedTextWriter.cs
// Script#/Runtime/Server
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace ScriptSharp.Web.Core {

    internal sealed class IndentedTextWriter : TextWriter {

        private TextWriter _writer;
        private bool _minimize;

        private int _indentLevel;
        private bool _tabsPending;
        private string _tabString;

        public IndentedTextWriter(TextWriter writer, bool minimize)
            : base(CultureInfo.InvariantCulture) {
            _writer = writer;
            _minimize = minimize;

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
                if (_minimize) {
                    return String.Empty;
                }
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
                if (_minimize == false) {
                    for (int i = 0; i < _indentLevel; i++) {
                        _writer.Write(_tabString);
                    }
                }
                _tabsPending = false;
            }
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

        public void WriteLineNoTabs(string s) {
            _writer.WriteLine(s);
        }

        public override void WriteLine(string s) {
            OutputTabs();
            _writer.Write(s);
            WriteNewLine();
            _tabsPending = true;
        }

        public override void WriteLine() {
            OutputTabs();
            WriteNewLine();
            _tabsPending = true;
        }

        public override void WriteLine(bool value) {
            OutputTabs();
            _writer.Write(value);
            WriteNewLine();
            _tabsPending = true;
        }

        public override void WriteLine(char value) {
            OutputTabs();
            _writer.Write(value);
            WriteNewLine();
            _tabsPending = true;
        }

        public override void WriteLine(char[] buffer) {
            OutputTabs();
            _writer.Write(buffer);
            WriteNewLine();
            _tabsPending = true;
        }

        public override void WriteLine(char[] buffer, int index, int count) {
            OutputTabs();
            _writer.Write(buffer, index, count);
            WriteNewLine();
            _tabsPending = true;
        }

        public override void WriteLine(double value) {
            OutputTabs();
            _writer.Write(value);
            WriteNewLine();
            _tabsPending = true;
        }

        public override void WriteLine(float value) {
            OutputTabs();
            _writer.Write(value);
            WriteNewLine();
            _tabsPending = true;
        }

        public override void WriteLine(int value) {
            OutputTabs();
            _writer.Write(value);
            WriteNewLine();
            _tabsPending = true;
        }

        public override void WriteLine(long value) {
            OutputTabs();
            _writer.Write(value);
            WriteNewLine();
            _tabsPending = true;
        }

        public override void WriteLine(object value) {
            OutputTabs();
            _writer.Write(value);
            WriteNewLine();
            _tabsPending = true;
        }

        public override void WriteLine(string format, object arg0) {
            OutputTabs();
            _writer.Write(format, arg0);
            WriteNewLine();
            _tabsPending = true;
        }

        public override void WriteLine(string format, object arg0, object arg1) {
            OutputTabs();
            _writer.Write(format, arg0, arg1);
            WriteNewLine();
            _tabsPending = true;
        }

        public override void WriteLine(string format, params object[] arg) {
            OutputTabs();
            _writer.Write(format, arg);
            WriteNewLine();
            _tabsPending = true;
        }

        public override void WriteLine(UInt32 value) {
            OutputTabs();
            _writer.Write(value);
            WriteNewLine();
            _tabsPending = true;
        }

        public void WriteSignificantNewLine() {
            WriteLine();
        }

        public void WriteNewLine() {
            if (_minimize == false) {
                WriteLine();
            }
        }

        public void WriteTrimmed(string text) {
            if (_minimize == false) {
                Write(text);
            }
            else {
                Write(text.Trim());
            }
        }
    }
}
