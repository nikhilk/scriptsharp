// ScriptReference.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;

namespace DSharp.Compiler
{
    public sealed class ScriptReference
    {
        private string identifier;

        private string path;

        public ScriptReference(string name, string identifier)
        {
            Debug.Assert(string.IsNullOrEmpty(name) == false);
            Debug.Assert(identifier == null || identifier.Length != 0);

            Name = name;
            this.identifier = identifier;
        }

        public bool DelayLoaded { get; set; }

        public bool HasIdentifier => identifier != null;

        public string Identifier
        {
            get => identifier ?? Name;
            set => identifier = value;
        }

        public string Name { get; }

        public string Path
        {
            get => path ?? Name;
            set => path = value;
        }
    }
}