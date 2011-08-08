// GadgetScriptlet.cs
//

using System;
using System.Collections;
using System.Html;
using System.Gadgets;

namespace $safeprojectname$ {

    public class GadgetScriptlet {

        private GadgetScriptlet() {
            Gadget.OnDock = OnDock;
            Gadget.OnUndock = OnUndock;

            Gadget.Flyout.File = "Flyout.htm";
            Gadget.Flyout.OnShow = OnFlyoutShow;
            Gadget.Flyout.OnHide = OnFlyoutHide;

            UpdateDockedState();

            // TODO: Add initialization code here
        }

        public static void Main(Dictionary arguments) {
            GadgetScriptlet scriptlet = new GadgetScriptlet();
        }

        private void OnDock() {
            UpdateDockedState();
        }

        private void OnFlyoutHide() {
            // TODO: Use Gadget.Flyout.Document to get to the HTML document within
            //       the Flyout page
        }

        private void OnFlyoutShow() {
            // TODO: Use Gadget.Flyout.Document to get to the HTML document within
            //       the Flyout page
        }

        private void OnUndock() {
            UpdateDockedState();
        }

        private void UpdateDockedState() {
            Document.Body.ClassName = Gadget.Docked ? "docked" : "undocked";
        }
    }
}
