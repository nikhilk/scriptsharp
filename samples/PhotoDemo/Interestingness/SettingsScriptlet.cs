// SettingsScriptlet.cs
//

using System;
using System.Collections;
using System.Html;
using System.Gadgets;

namespace Interestingness {

    public class SettingsScriptlet {

        private SettingsScriptlet() {
            Gadget.OnSettingsClosing = OnClosing;

            TextElement tagsTextBox = (TextElement)Document.GetElementById("tagsTextBox");
            tagsTextBox.Value = GadgetScriptlet.Current.Gallery.Tags;
        }

        public static void Main(Dictionary arguments) {
            SettingsScriptlet scriptlet = new SettingsScriptlet();
        }

        private void OnClosing(GadgetSettingsEvent e) {
            TextElement tagsTextBox = (TextElement)Document.GetElementById("tagsTextBox");

            if (e.CloseAction == e.Action.Commit) {
                Gallery gallery = GadgetScriptlet.Current.Gallery;
                gallery.Tags = tagsTextBox.Value;
            }

            Gadget.OnSettingsClosing = null;
            e.Cancel = false;
        }
    }
}
