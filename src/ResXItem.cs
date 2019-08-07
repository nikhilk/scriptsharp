// ResXItem.cs
// Script#/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;

namespace DSharp
{
    internal sealed class ResXItem
    {
        private readonly string comment;
        private readonly string value;

        public ResXItem(string name, string value, string comment)
        {
            Debug.Assert(string.IsNullOrEmpty(name) == false);

            Name = name;
            this.value = value;
            this.comment = comment;
        }

        public string Comment
        {
            get
            {
                if (comment == null)
                {
                    return string.Empty;
                }

                return comment;
            }
        }

        public string Name { get; }

        public string Value
        {
            get
            {
                if (value == null)
                {
                    return string.Empty;
                }

                return value;
            }
        }
    }
}