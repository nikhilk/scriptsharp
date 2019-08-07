using System;
using System.Html;

namespace ComponentLibrary
{
    public interface IComponent : IDisposable
    {
        Element Target { get; }
    }
}
