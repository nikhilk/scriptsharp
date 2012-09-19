// Isotope.cs
//

using System;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace jQueryApi.Gridster {

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class GridsterCollision {
    }

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class GridsterDraggable {
    }

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class GridsterCoordinates {

        [ScriptName("col")]
        [IntrinsicProperty]
        public int Column {
            get;
            set;
        }

        [IntrinsicProperty]
        public int Row {
            get;
            set;
        }

        [ScriptName("size_x")]
        [IntrinsicProperty]
        public int SizeX {
            get;
            set;
        }

        [ScriptName("size_y")]
        [IntrinsicProperty]
        public int SizeY {
            get;
            set;
        }
    }

    [Imported]
    [IgnoreNamespace]
    public delegate object GridsterSerializationCallback(jQueryObject widget, GridsterCoordinates coords);

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class GridsterOptions {

        public GridsterOptions() {
        }

        public GridsterOptions(params object[] nameValuePairs) {
        }

        [ScriptName("autogenerate_stylesheet")]
        [IntrinsicProperty]
        public bool AutoGenerateStyleSheet {
            get;
            set;
        }

        [ScriptName("avoid_overlapped_widgets")]
        [IntrinsicProperty]
        public bool AvoidOverlapping {
            get;
            set;
        }

        [ScriptName("widget_base_dimensions")]
        [IntrinsicProperty]
        public int[] BaseDimensions {
            get;
            set;
        }

        [IntrinsicProperty]
        public GridsterCollision Collision {
            get;
            set;
        }

        [IntrinsicProperty]
        public GridsterDraggable Draggable {
            get;
            set;
        }

        [ScriptName("extra_cols")]
        [IntrinsicProperty]
        public int ExtraColumns {
            get;
            set;
        }

        [ScriptName("extra_rows")]
        [IntrinsicProperty]
        public int ExtraRows {
            get;
            set;
        }

        [ScriptName("widget_margins")]
        [IntrinsicProperty]
        public int[] Margins {
            get;
            set;
        }

        [ScriptName("max_size_x")]
        [IntrinsicProperty]
        public int MaximumColumnSpan {
            get;
            set;
        }

        [ScriptName("max_size_y")]
        [IntrinsicProperty]
        public int MaximumRowSpan {
            get;
            set;
        }

        [ScriptName("min_cols")]
        [IntrinsicProperty]
        public int MinimumColumns {
            get;
            set;
        }

        [ScriptName("min_rows")]
        [IntrinsicProperty]
        public int MinimumRows {
            get;
            set;
        }

        [ScriptName("widget_selector")]
        [IntrinsicProperty]
        public string Selector {
            get;
            set;
        }

        [ScriptName("serialize_params")]
        [IntrinsicProperty]
        public GridsterSerializationCallback SerializationCallback {
            get;
            set;
        }
    }

    [Imported]
    [IgnoreNamespace]
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

    [Imported]
    [IgnoreNamespace]
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
