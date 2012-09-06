// LineMap.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;

namespace ScriptSharp.Parser {

    /// <summary>
    /// Container of #line directives for a single file.
    /// Maps from a buffer TextBufferPosition to a FilePosition.
    /// </summary>
    internal sealed class LineMap {

        private ArrayList _entries;

        public LineMap(string filename) {
            _entries = new ArrayList();
            AddEntry(0, 1, filename);
        }

        public string FileName {
            get {
                return ((MapEntry)_entries[0]).fileName;
            }
        }

        /// <summary>
        /// Add a #line entry to the map.
        /// </summary>
        public void AddEntry(int from, int to) {
            AddEntry(from, to, ((MapEntry)_entries[_entries.Count - 1]).fileName);
        }

        /// <summary>
        /// Add a #line entry with a filename to the map.
        /// </summary>
        public void AddEntry(int from, int to, string filename) {
            _entries.Add(new MapEntry(from, to, filename));
        }

        /// <summary>
        /// Map a buffer position to a position in a file.
        /// </summary>
        public FilePosition Map(BufferPosition from) {
            MapEntry entry = FindEntry(from.Line);
            return new FilePosition(
                new BufferPosition(
                    entry.to + (from.Line - entry.from),
                    from.Column + 1,
                    from.Offset),
                entry.fileName);
        }

        private MapEntry FindEntry(int from) {
            int lowIndex = 0;
            int highIndex = _entries.Count;

            while (lowIndex < highIndex) {
                int midIndex = (lowIndex + highIndex) / 2;
                MapEntry midEntry = (MapEntry)_entries[midIndex];
                if (midEntry.from < from) {
                    lowIndex = midIndex + 1;
                }
                else if (midEntry.from == from) {
                    return midEntry;
                }
                else {
                    highIndex = midIndex;
                }
            }

            return (MapEntry)_entries[lowIndex - 1];
        }

        private sealed class MapEntry {

            public int from;
            public int to;
            public string fileName;

            public MapEntry(int from, int to, string filename) {
                this.from = from;
                this.to = to;
                this.fileName = filename;
            }
        }
    }
}
