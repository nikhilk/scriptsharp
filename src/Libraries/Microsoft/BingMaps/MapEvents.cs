// MapEvents.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Html;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    public delegate void MapEventHandler(MapEventArgs e);

    [Imported]
    [ScriptName("Events")]
    public static class MapEvents {

        public static object AddHandler(Map map, string eventName, MapEventHandler handler) {
            return null;
        }

        public static object AddHandler(MapEntity entity, string eventName, MapEventHandler handler) {
            return null;
        }

        public static object AddHandler(MapEntityCollection entities, string eventName, MapEventHandler handler) {
            return null;
        }

        public static object AddThrottledHandler(Map map, string eventName, MapEventHandler handler, int interval) {
            return null;
        }

        public static object AddThrottledHandler(MapEntity entity, string eventName, MapEventHandler handler, int interval) {
            return null;
        }

        public static object AddThrottledHandler(MapEntityCollection entities, string eventName, MapEventHandler handler, int interval) {
            return null;
        }

        public static void RemoveHandler(object handlerID) {
        }
    }
}
