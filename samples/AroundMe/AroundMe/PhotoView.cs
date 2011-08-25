// Photo.cs
//

using System;
using System.Html;
using Microsoft.Maps;
using AroundMe.Graphs;

namespace AroundMe.DataModel {

    internal sealed class PhotoView : Record {

        public GraphNode locationNode;
        public GraphNode photoNode;

        public MapPushpin locationPushpin;
        public MapInfobox photoInfobox;
        public MapPolyline calloutLine;
    }
}
