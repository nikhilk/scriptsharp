// AttributeTargets.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.CodeModel.Attributes
{
    /// <summary>
    ///     Locations which an attribute section can target.
    /// </summary>
    internal enum AttributeTargets
    {
        Assembly,
        Field,
        Event,
        Method,
        Module,
        Param,
        Property,
        Return,
        Type
    }
}