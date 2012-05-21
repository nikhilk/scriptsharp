// MapEntityCollection.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    [Imported]
    [ScriptName("EntityCollection")]
    public sealed class MapEntityCollection {

        public MapEntityCollection() {
        }

        public MapEntityCollection(MapEntityCollectionOptions options) {
        }

        public void Clear() {
        }

        public MapEntity Get(int index) {
            return null;
        }

        public int GetLength() {
            return 0;
        }

        public bool GetVisible() {
            return true;
        }

        public int GetZIndex() {
            return 0;
        }

        public int IndexOf(MapEntity entity) {
            return 0;
        }

        public void Insert(MapEntity entity, int index) {
        }

        public void Insert(MapEntityCollection entities, int index) {
        }

        public MapEntity Pop() {
            return null;
        }

        public void Push(MapEntity entity) {
        }

        public void Push(MapEntityCollection entities) {
        }

        public MapEntity Remove(MapEntity entity) {
            return null;
        }

        public MapEntity Remove(MapEntityCollection entities) {
            return null;
        }

        public MapEntity RemoveAt(int index) {
            return null;
        }

        public void SetOptions(MapEntityCollectionOptions options) {
        }
    }
}
