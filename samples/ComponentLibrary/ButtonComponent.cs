using System;
using System.Collections.Generic;
using System.Html;
using System.Text;

namespace ComponentLibrary
{
    public class ButtonComponent : InputComponent, IButtonComponent
    {
        public string Text
        {
            get { return Target.Value; }
            set { Target.Value = value; }
        }

        protected override string InputElementType
        {
            get { return "button"; }
        }

        public event Action ButtonPressed;

        public ButtonComponent(IComponent parent, Element target)
            : base(parent, target)
        {
            Target.AddEventListener("click", HandleButtonClicked, false);
        }

        private void HandleButtonClicked(ElementEvent e)
        {
            if (ButtonPressed == null)
            {
                return;
            }

            Script.SetTimeout(ButtonPressed, 0);
        }

        public override void Dispose()
        {
            Target.RemoveEventListener("click", HandleButtonClicked, false);
            base.Dispose();
        }
    }
}
