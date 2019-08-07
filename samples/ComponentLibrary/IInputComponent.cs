using System.Html;

namespace ComponentLibrary
{
    public interface IInputComponent : IComponent
    {
        InputElement Target { get; }
    }
}
