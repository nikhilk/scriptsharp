using System;

namespace ComponentLibrary
{
    public interface IButtonComponent : IInputComponent
    {
        event Action ButtonPressed;

        string Text { get; set; }
    }
}
