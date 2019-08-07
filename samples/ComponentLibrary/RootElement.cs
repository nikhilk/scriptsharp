using System.Html;

namespace ComponentLibrary
{
    public sealed class RootElement : IComponent
    {
        private static readonly RootElement root;

        public static RootElement Root
        {
            get { return root; }
        }
        
        public Element Target
        {
            get { return Document.Body; }
        }

        static RootElement()
        {
            root = new RootElement();
        }

        private RootElement()
        {
        }

        public void Dispose()
        {
        }
    }
}
