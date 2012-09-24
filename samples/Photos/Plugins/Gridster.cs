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
        [ScriptProperty]
        public int Column {
            get;
            set;
        }

        [ScriptProperty]
        public int Row {
            get;
            set;
        }

        [ScriptName("size_x")]
        [ScriptProperty]
        public int SizeX {
            get;
            set;
        }

        [ScriptName("size_y")]
        [ScriptProperty]
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
        [ScriptProperty]
        public bool AutoGenerateStyleSheet {
            get;
            set;
        }

        [ScriptName("avoid_overlapped_widgets")]
        [ScriptProperty]
        public bool AvoidOverlapping {
            get;
            set;
        }

        [ScriptName("widget_base_dimensions")]
        [ScriptProperty]
        public int[] BaseDimensions {
            get;
            set;
        }

        [ScriptProperty]
        public GridsterCollision Collision {
            get;
            set;
        }

        [ScriptProperty]
        public GridsterDraggable Draggable {
            get;
            set;
        }

        [ScriptName("extra_cols")]
        [ScriptProperty]
        public int ExtraColumns {
            get;
            set;
        }

        [ScriptName("extra_rows")]
        [ScriptProperty]
        public int ExtraRows {
            get;
            set;
        }

        [ScriptName("widget_margins")]
        [ScriptProperty]
        public int[] Margins {
            get;
            set;
        }

        [ScriptName("max_size_x")]
        [ScriptProperty]
        public int MaximumColumnSpan {
            get;
            set;
        }

        [ScriptName("max_size_y")]
        [ScriptProperty]
        public int MaximumRowSpan {
            get;
            set;
        }

        [ScriptName("min_cols")]
        [ScriptProperty]
        public int MinimumColumns {
            get;
            set;
        }

        [ScriptName("min_rows")]
        [ScriptProperty]
        public int MinimumRows {
            get;
            set;
        }

        [ScriptName("widget_selector")]
        [ScriptProperty]
        public string Selector {
            get;
            set;
        }

        [ScriptName("serialize_params")]
        [ScriptProperty]
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
