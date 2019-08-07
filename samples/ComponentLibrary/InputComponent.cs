using System.Html;

namespace ComponentLibrary
{
    public abstract class InputComponent : Component, IInputComponent
    {
        public InputElement Target
        {
            get { return (InputElement)base.Target; }
        }

        protected override string ElementType
        {
            get { return "input"; }
        }

        protected abstract string InputElementType { get; }

        public InputComponent(IComponent parent, Element target)
            : base(parent, target)
        {
            Target.Type = InputElementType;
        }
    }
}
