// Isotope.cs
//

using System;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace jQueryApi.Gridster {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class GridsterCollision {
    }

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class GridsterDraggable {
    }

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class GridsterCoordinates {

        [ScriptName("col")]
        [ScriptField]
        public int Column {
            get;
            set;
        }

        [ScriptField]
        public int Row {
            get;
            set;
        }

        [ScriptName("size_x")]
        [ScriptField]
        public int SizeX {
            get;
            set;
        }

        [ScriptName("size_y")]
        [ScriptField]
        public int SizeY {
            get;
            set;
        }
    }

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public delegate object GridsterSerializationCallback(jQueryObject widget, GridsterCoordinates coords);

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class GridsterOptions {

        public GridsterOptions() {
        }

        public GridsterOptions(params object[] nameValuePairs) {
        }

        [ScriptName("autogenerate_stylesheet")]
        [ScriptField]
        public bool AutoGenerateStyleSheet {
            get;
            set;
        }

        [ScriptName("avoid_overlapped_widgets")]
        [ScriptField]
        public bool AvoidOverlapping {
            get;
            set;
        }

        [ScriptName("widget_base_dimensions")]
        [ScriptField]
        public int[] BaseDimensions {
            get;
            set;
        }

        [ScriptField]
        public GridsterCollision Collision {
            get;
            set;
        }

        [ScriptField]
        public GridsterDraggable Draggable {
            get;
            set;
        }

        [ScriptName("extra_cols")]
        [ScriptField]
        public int ExtraColumns {
            get;
            set;
        }

        [ScriptName("extra_rows")]
        [ScriptField]
        public int ExtraRows {
            get;
            set;
        }

        [ScriptName("widget_margins")]
        [ScriptField]
        public int[] Margins {
            get;
            set;
        }

        [ScriptName("max_size_x")]
        [ScriptField]
        public int MaximumColumnSpan {
            get;
            set;
        }

        [ScriptName("max_size_y")]
        [ScriptField]
        public int MaximumRowSpan {
            get;
            set;
        }

        [ScriptName("min_cols")]
        [ScriptField]
        public int MinimumColumns {
            get;
            set;
        }

        [ScriptName("min_rows")]
        [ScriptField]
        public int MinimumRows {
            get;
            set;
        }

        [ScriptName("widget_selector")]
        [ScriptField]
        public string Selector {
            get;
            set;
        }

        [ScriptName("serialize_params")]
        [ScriptField]
        public GridsterSerializationCallback SerializationCallback {
            get;
            set;
        }
    }

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class GridsterObject {

        private GridsterObject() {
        }

        // TODO: Define methods...

        [ScriptName("disable")]
        public GridsterObject DisableDragging() {
            return null;
        }

        [ScriptName("enable")]
        public GridsterObject EnableDragging() {
            return null;
        }
    }

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptDependency("jqueryGridster")]
    public sealed class jQueryGridsterObject : jQueryObject {

        private jQueryGridsterObject() {
        }

        public jQueryObject Gridster() {
            return null;
        }

        public jQueryObject Gridster(GridsterOptions options) {
            return null;
        }
    }
}
