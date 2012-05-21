// GadgetSettingsDialogAction.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Gadgets {

    [IgnoreNamespace]
    [Imported]
    public sealed class GadgetSettingsDialogAction {

        private GadgetSettingsDialogAction() {
        }

        [IntrinsicProperty]
        public GadgetSettingsCloseAction Cancel {
            get {
                return GadgetSettingsCloseAction.Cancel;
            }
        }

        [IntrinsicProperty]
        public GadgetSettingsCloseAction Commit {
            get {
                return GadgetSettingsCloseAction.Commit;
            }
        }
    }
}
