// PreprocessorTextReader.cs
// Script#/Tools/Preprocessor
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ScriptSharp.Preprocessor {

    internal sealed class PreprocessorTextReader : TextReader {

        private TextWriter _skipPreprocessingWriter;

        private IStreamSource _source;
        private IStreamResolver _includeResolver;

        private Dictionary<string, string> _definedVariables;
        private Stack<Instruction> _activeInstructions;

        private string _currentLine;
        private int _currentLinePosition;

        private int _lineCounter;

        private Stream _sourceStream;
        private TextReader _sourceTextReader;

        private IStreamSource _include;
        private Stream _includeStream;
        private TextReader _includeTextReader;
        private int _includeLineCounter;

        public PreprocessorTextReader(IStreamSource source, ICollection<string> predefinedVariables, IStreamResolver includeResolver) {
            Debug.Assert(source != null);

            _source = source;
            _includeResolver = includeResolver;

            _definedVariables = new Dictionary<string, string>();
            _activeInstructions = new Stack<Instruction>();

            if ((predefinedVariables != null) && (predefinedVariables.Count != 0)) {
                foreach (string s in predefinedVariables) {
                    _definedVariables[s] = String.Empty;
                }
            }

            _currentLinePosition = -1;
        }

        internal string CurrentFile {
            get {
                if (_includeTextReader != null) {
                    return _include.FullName;
                }
                return _source.FullName;
            }
        }

        internal string CurrentLine {
            get {
                return _currentLine;
            }
        }

        internal int CurrentLineNumber {
            get {
                if (_includeTextReader != null) {
                    return _includeLineCounter;
                }
                return _lineCounter;
            }
        }

        private void ClearLine() {
            _currentLinePosition = -1;
            _currentLine = null;
        }

        public override void Close() {
            if (_includeStream != null) {
                _include.CloseStream(_includeStream);
                _includeStream = null;
            }
            if (_sourceStream != null) {
                _source.CloseStream(_sourceStream);
                _sourceStream = null;
            }

            base.Close();
        }

        private bool EnsureLine() {
            if (_currentLine == null) {
                Debug.Assert(_currentLinePosition == -1);

                _currentLine = GetNextLine();
                if (_currentLine != null) {
                    _currentLinePosition = 0;
                    return true;
                }
                else {
                    if (_activeInstructions.Count != 0) {
                        RaiseError("Unterminated '#if' instruction was detected.");
                    }

                    return false;
                }
            }

            return true;
        }

        private string GetNextLine() {
            string line = null;

            while (line == null) {
                if (_includeTextReader != null) {
                    line = _includeTextReader.ReadLine();
                    _includeLineCounter++;

                    if (line == null) {
                        _includeTextReader = null;
                        _includeLineCounter = 0;

                        _include.CloseStream(_includeStream);
                        _includeStream = null;
                        _include = null;
                    }
                }
                if (line == null) {
                    line = _sourceTextReader.ReadLine();
                    _lineCounter++;
                }

                if (line == null) {
                    break;
                }

                string trimmedLine = line.TrimStart(' ', '\t');

                bool isActive = true;
                if (_activeInstructions.Count != 0) {
                    Instruction currentInstruction = _activeInstructions.Peek();
                    isActive = currentInstruction.IsActive;
                }

                if (trimmedLine.StartsWith("#include ")) {
                    if (isActive == false) {
                        line = null;
                    }

                    if (line != null) {
                        _currentLine = line;
                        if (_includeResolver != null) {
                            if (_includeStream == null) {
                                ProcessIncludeInstruction(trimmedLine);
                                line = null;
                            }
                            else {
                                RaiseError("Nested includes are not supported.");
                            }
                        }
                        else {
                            RaiseError("Includes are not supported in this file.");
                        }
                    }
                }
                else if (trimmedLine.StartsWith("#")) {
                    if ((isActive == false) &&
                        (trimmedLine.StartsWith("#elseif ") == false) &&
                        (trimmedLine.StartsWith("#elif ") == false) &&
                        (trimmedLine.StartsWith("#else") == false) &&
                        (trimmedLine.StartsWith("#endif") == false)) {
                        line = null;
                    }

                    if (line != null) {
                        ProcessInstruction(trimmedLine);
                        line = null;
                    }
                }
                else {
                    if (isActive == false) {
                        line = null;
                    }
                }
            }

            return line;
        }

        public bool Initialize(TextWriter skipPreprocessingWriter) {
            _skipPreprocessingWriter = skipPreprocessingWriter;

            _sourceStream = _source.GetStream();
            if (_sourceStream == null) {
                return false;
            }

            _sourceTextReader = new StreamReader(_sourceStream);
            return true;
        }

        private string ParseInstructionVariable(string instructionLine, int startIndex, out int endIndex) {
            endIndex = -1;

            int i = startIndex;
            while (i < instructionLine.Length) {
                char ch = instructionLine[i];
                if ((ch != ' ') && (ch != '\t')) {
                    break;
                }
                i++;
            }

            if (i < instructionLine.Length) {
                int j = i;
                while (j < instructionLine.Length) {
                    char ch = instructionLine[j];
                    if ((ch == ' ') || (ch == '\t')) {
                        break;
                    }
                    j++;
                }

                endIndex = j;
                return instructionLine.Substring(i, j - i);
            }

            return null;
        }

        public override int Peek() {
            if (EnsureLine() == false) {
                return -1;
            }

            int ch;
            if (_currentLinePosition == _currentLine.Length) {
                ch = '\n';
            }
            else {
                ch = _currentLine[_currentLinePosition];
            }

            return ch;
        }

        private void ProcessIncludeInstruction(string instructionLine) {
            Debug.Assert(_includeStream == null);
            Debug.Assert(_includeTextReader == null);

            bool included = false;
            int beginQuoteIndex = instructionLine.IndexOf('"');
            int endQuoteIndex = 0;

            if (beginQuoteIndex > 0) {
                endQuoteIndex = instructionLine.IndexOf('"', beginQuoteIndex + 1);
            }

            if (endQuoteIndex > 0) {
                Exception resolveException = null;
                string includePath = instructionLine.Substring(beginQuoteIndex + 1, endQuoteIndex - beginQuoteIndex - 1);
                try {
                    _include = _includeResolver.ResolveInclude(_source, includePath);

                    if (_include != null) {
                        _includeStream = _include.GetStream();
                        if (_includeStream != null) {
                            _includeTextReader = new StreamReader(_includeStream);
                            _includeLineCounter = 0;
                        }
                    }
                }
                catch (Exception e) {
                    resolveException = e;
                }

                if ((included == false) && (_includeTextReader == null)) {
                    RaiseError("Unable to resolve or open included file '" + includePath + "'", resolveException);
                }
            }
            else {
                RaiseError("Invalid #include instruction.");
            }
        }

        private void ProcessInstruction(string instructionLine) {
            int dummy;
            if (instructionLine.StartsWith("#define ")) {
                string variableName = ParseInstructionVariable(instructionLine, 8, out dummy);
                if (variableName == null) {
                    RaiseError("Missing variable following the '#define' instruction.");
                }
                if (_definedVariables.ContainsKey(variableName)) {
                    RaiseError("Duplicate definition of variable '" + variableName + "'.");
                }

                _definedVariables[variableName] = String.Empty;
            }
            else if (instructionLine.StartsWith("#undefine ")) {
                string variableName = ParseInstructionVariable(instructionLine, 10, out dummy);

                if (variableName == null) {
                    RaiseError("Missing variable following the '#undefine' instruction.");
                }
                if (_definedVariables.ContainsKey(variableName) == false) {
                    RaiseError("The variable '" + variableName + "' has not been defined yet.");
                }

                _definedVariables.Remove(variableName);
            }
            else if (instructionLine.StartsWith("#if ")) {
                string variableName = ParseInstructionVariable(instructionLine, 4, out dummy);

                if (variableName == null) {
                    RaiseError("Missing variable following the '#if' instruction.");
                }

                Instruction instruction = new Instruction();
                _activeInstructions.Push(instruction);

                instruction.AddVariable(variableName, _definedVariables);
            }
            else if (instructionLine.StartsWith("#elseif ") ||
                     instructionLine.StartsWith("#elif ")) {
                string variableName = ParseInstructionVariable(instructionLine, 8, out dummy);
                if (variableName == null) {
                    RaiseError("Missing variable following the '#elif' instruction.");
                }

                if (_activeInstructions.Count == 0) {
                    RaiseError("Unexpected '#elif' instruction.");
                }

                Instruction currentInstruction = _activeInstructions.Peek();
                bool added = currentInstruction.AddVariable(variableName, _definedVariables);

                if (added == false) {
                    RaiseError("The specified '" + variableName + "' has already been used, or an '#else' instruction has already been specified.");
                }
            }
            else if (instructionLine.StartsWith("#else")) {
                if (_activeInstructions.Count == 0) {
                    RaiseError("Unexpected '#else' instruction.");
                }

                Instruction currentInstruction = _activeInstructions.Peek();
                bool added = currentInstruction.AddVariable(null, _definedVariables);

                if (added == false) {
                    RaiseError("Only a single '#else' instruction is allowed for a given '#if' instruction.");
                }
            }
            else if (instructionLine.StartsWith("#endif")) {
                if (_activeInstructions.Count == 0) {
                    RaiseError("Unexpected '#endif' instruction.");
                }

                _activeInstructions.Pop();
            }
        }

        private void RaiseError(string errorMessage) {
            RaiseError(errorMessage, null);
        }

        private void RaiseError(string errorMessage, Exception innerException) {
            string path = CurrentFile;
            int lineNumber = CurrentLineNumber;

            if (_includeStream != null) {
                _includeStream.Close();
                _includeStream = null;

                _includeTextReader = null;
            }

            if (innerException == null) {
                throw new PreprocessorException(errorMessage, _currentLine, path, lineNumber);
            }
            else {
                throw new PreprocessorException(errorMessage, _currentLine, path, lineNumber);
            }
        }

        public override int Read() {
            if (EnsureLine() == false) {
                return -1;
            }

            int ch;
            if (_currentLinePosition == _currentLine.Length) {
                ch = '\n';
                ClearLine();
            }
            else {
                ch = _currentLine[_currentLinePosition];
                _currentLinePosition++;
            }

            return ch;
        }


        private sealed class Instruction {

            private ArrayList _variables;
            private bool _active;
            private bool _activated;
            private bool _canAddVariables;

            public Instruction() {
                _variables = new ArrayList();
                _canAddVariables = true;
            }

            public bool IsActive {
                get {
                    return _active;
                }
            }

            public bool AddVariable(string variable, Dictionary<string, string> definedVariables) {
                if (variable == null) {
                    if (_canAddVariables == false) {
                        // already seen #else
                        return false;
                    }

                    _canAddVariables = false;
                    if (_activated == false) {
                        // #else should be active if no other block was activated
                        _active = true;
                        _activated = true;
                    }
                    else {
                        _active = false;
                    }
                    return true;
                }
                else {
                    if (_canAddVariables == false) {
                        // already seen #else
                        return false;
                    }

                    if (_variables.Contains(variable)) {
                        // duplicate use of same variable
                        return false;
                    }

                    _variables.Add(variable);
                    if (_active) {
                        // no longer active
                        _active = false;
                    }
                    else if (_activated == false) {
                        if (definedVariables.ContainsKey(variable)) {
                            // variable is defined, so the block becomes activated
                            _active = true;
                            _activated = true;
                        }
                    }

                    return true;
                }
            }
        }
    }
}
