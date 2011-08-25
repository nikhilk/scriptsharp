// Photo.cs
//

using System;
using System.Html;
using Microsoft.Maps;
using AroundMe.Graphs;

namespace AroundMe.DataModel {

    internal sealed class PhotoView : Record {

        public GraphNode pushpinNode;
        public GraphNode calloutNode;

        public MapPushpin pushpin;
        public MapInfobox callout;
        public MapPolyline connector;
    }
}
