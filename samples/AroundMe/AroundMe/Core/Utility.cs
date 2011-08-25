// Utility.cs
//

using System;
using System.Html;

namespace AroundMe.Core {

    internal static class Utility {

        public static Element GetElement(string id) {
            return Document.GetElementById(id);
        }

        public static void SubscribeBlur(string id, ElementEventListener listener) {
            Element e = Document.GetElementById(id);
            e.AddEventListener("blur", listener, false);
        }

        public static void SubscribeClick(string id, ElementEventListener listener) {
            Element e = Document.GetElementById(id);
            e.AddEventListener("click", listener, false);
        }

        public static void SubscribeKey(string id, ElementEventListener listener) {
            Element e = Document.GetElementById(id);
            e.AddEventListener("keyup", listener, false);
        }
    }
}
