// LineMap.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;

namespace DSharp.Compiler.Parser
{
    /// <summary>
    ///     Container of #line directives for a single file.
    ///     Maps from a buffer TextBufferPosition to a FilePosition.
    /// </summary>
    internal sealed class LineMap
    {
        private readonly ArrayList entries;

        public LineMap(string filename)
        {
            entries = new ArrayList();
            AddEntry(0, 1, filename);
        }

        public string FileName => ((MapEntry) entries[0]).FileName;

        /// <summary>
        ///     Add a #line entry to the map.
        /// </summary>
        public void AddEntry(int from, int to)
        {
            AddEntry(from, to, ((MapEntry) entries[entries.Count - 1]).FileName);
        }

        /// <summary>
        ///     Add a #line entry with a filename to the map.
        /// </summary>
        public void AddEntry(int from, int to, string filename)
        {
            entries.Add(new MapEntry(from, to, filename));
        }

        /// <summary>
        ///     Map a buffer position to a position in a file.
        /// </summary>
        public FilePosition Map(BufferPosition from)
        {
            MapEntry entry = FindEntry(from.Line);

            return new FilePosition(
                new BufferPosition(
                    entry.To + (from.Line - entry.From),
                    from.Column + 1,
                    from.Offset),
                entry.FileName);
        }

        private MapEntry FindEntry(int from)
        {
            int lowIndex = 0;
            int highIndex = entries.Count;

            while (lowIndex < highIndex)
            {
                int midIndex = (lowIndex + highIndex) / 2;
                MapEntry midEntry = (MapEntry) entries[midIndex];

                if (midEntry.From < from)
                {
                    lowIndex = midIndex + 1;
                }
                else if (midEntry.From == from)
                {
                    return midEntry;
                }
                else
                {
                    highIndex = midIndex;
                }
            }

            return (MapEntry) entries[lowIndex - 1];
        }

        private sealed class MapEntry
        {
            public readonly string FileName;

            public readonly int From;
            public readonly int To;

            public MapEntry(int from, int to, string filename)
            {
                From = from;
                To = to;
                FileName = filename;
            }
        }
    }
}