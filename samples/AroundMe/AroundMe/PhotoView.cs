// Photo.cs
//

using System;
using System.Html;
using AroundMe.Graphs;

namespace AroundMe.DataModel {

    internal sealed class PhotoView : Record {

        public ImageElement image;
        public GraphNode pushpin;
        public GraphNode photo;
        public bool hidden;
    }
}
