// SliderOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Options used to initialize or customize Slider.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class SliderOptions {

        public SliderOptions() {
        }

        public SliderOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// This event is triggered on slide stop, or if the value is changed programmatically (by the <code>value</code> method).  Takes arguments event and ui.  Use event.originalEvent to detect whether the value changed by mouse, keyboard, or programmatically. Use ui.value (single-handled sliders) to obtain the value of the current handle, $(this).slider('values', index) to get another handle's value.
        /// </summary>
        [ScriptField]
        public jQueryUIEventHandler<SlideChangeEvent> Change {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when the slider is created.
        /// </summary>
        [ScriptField]
        public jQueryEventHandler Create {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered on every mouse move during slide. Use ui.value (single-handled sliders) to obtain the value of the current handle, $(..).slider('value', index) to get another handles' value.Return false in order to prevent a slide, based on ui.value.
        /// </summary>
        [ScriptField]
        public jQueryUIEventHandler<SlideEvent> Slide {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when the user starts sliding.
        /// </summary>
        [ScriptField]
        public jQueryUIEventHandler<SlideStartEvent> Start {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when the user stops sliding.
        /// </summary>
        [ScriptField]
        public jQueryUIEventHandler<SlideStopEvent> Stop {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// Whether to slide handle smoothly when user click outside handle on the bar. Will also accept a string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// </summary>
        [ScriptField]
        public object Animate {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Disables the slider if set to true.
        /// </summary>
        [ScriptField]
        public bool Disabled {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// The maximum value of the slider.
        /// </summary>
        [ScriptField]
        public int Max {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// The minimum value of the slider.
        /// </summary>
        [ScriptField]
        public int Min {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// This option determines whether the slider has the min at the left, the max at the right or the min at the bottom, the max at the top. Possible values: 'horizontal', 'vertical'.
        /// </summary>
        [ScriptField]
        public string Orientation {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// If set to true, the slider will detect if you have two handles and create a stylable range element between these two. Two other possible values are 'min' and 'max'. A min range goes from the slider min to one handle. A max range goes from one handle to the slider max.
        /// </summary>
        [ScriptField]
        public object Range {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Determines the size or amount of each interval or step the slider takes between min and max. The full specified value range of the slider (max - min) needs to be evenly divisible by the step.
        /// </summary>
        [ScriptField]
        public int Step {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Determines the value of the slider, if there's only one handle. If there is more than one handle, determines the value of the first handle.
        /// </summary>
        [ScriptField]
        public int Value {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// This option can be used to specify multiple handles. If range is set to true, the length of 'values' should be 2.
        /// </summary>
        [ScriptField]
        public Array Values {
            get {
                return null;
            }
            set {
            }
        }
    }
}
