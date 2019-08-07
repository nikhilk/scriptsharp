using System;
using System.Html;

namespace ComponentLibrary
{
    public abstract class Component : IComponent
    {
        private readonly IComponent parent;
        private readonly Element target;

        public Element Target
        {
            get { return target; }
        }

        public IComponent Parent
        {
            get { return parent; }
        }

        protected virtual string ElementType
        {
            get { return "div"; }
        }

        public Component(IComponent parent, Element target)
        {
            this.parent = parent;
            this.target = target ?? CreateElement(parent);
        }

        private Element CreateElement(IComponent parent)
        {
            if (parent == null || parent.Target == null)
            {
                throw new Exception("Missing valid parent element");
            }

            Element element = Document.CreateElement(ElementType);
            parent.Target.AppendChild(element);

            return element;
        }

        public virtual void Dispose()
        {
            if (Parent == null || Parent.Target == null || target == null)
            {
                return;
            }

            Parent.Target.RemoveChild(target);
        }
    }
}
