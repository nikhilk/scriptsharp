namespace DSharp.Compiler.CodeModel
{
    internal static class ParseNodeExtensions
    {
        public static T As<T>(this ParseNode self)
            where T : ParseNode
        {
            return self as T;
        }

        public static T FindParent<T>(this ParseNode self)
            where T : ParseNode
        {
            var current = self.Parent;

            while (current != null)
            {
                if(current is T)
                {
                    return current.As<T>();
                }

                current = current.Parent;
            }

            return default;
        }
    }
}
