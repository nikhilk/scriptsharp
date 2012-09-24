// Photo.cs
//

using System;
using System.Html;
using System.Runtime.CompilerServices;
using Microsoft.Maps;
using AroundMe.Graphs;

namespace AroundMe.DataModel {

    [ScriptObject]
    internal sealed class PhotoView {

        public GraphNode pushpinNode;
        public GraphNode calloutNode;

        public MapPushpin pushpin;
        public MapInfobox callout;
        public MapPolyline connector;
    }
}
