// SortableEvent.cs
// Script#/Libraries/jQuery/jQuery.UI/Sortable
// Auto-generated code!
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace jQueryApi.UI
{
    [Imported]
    [IgnoreNamespace]
    public static class SortableEvent
    {
        /// <summary>
        /// This event is triggered when sortable is created.
        /// </summary>
        public const string Create = "sortcreate";
        /// <summary>
        /// This event is triggered when sorting starts.
        /// </summary>
        public const string Start = "sortstart";
        /// <summary>
        /// This event is triggered during sorting.
        /// </summary>
        public const string Sort = "sort";
        /// <summary>
        /// This event is triggered during sorting, but only when the DOM position has changed.
        /// </summary>
        public const string Change = "sortchange";
        /// <summary>
        /// This event is triggered when sorting stops, but when the placeholder/helper is still available.
        /// </summary>
        public const string BeforeStop = "sortbeforestop";
        /// <summary>
        /// This event is triggered when sorting has stopped.
        /// </summary>
        public const string Stop = "sortstop";
        /// <summary>
        /// This event is triggered when the user stopped sorting and the DOM position has changed.
        /// </summary>
        public const string Update = "sortupdate";
        /// <summary>
        /// This event is triggered when a connected sortable list has received an item from another list.
        /// </summary>
        public const string Receive = "sortreceive";
        /// <summary>
        /// This event is triggered when a sortable item has been dragged out from the list and into another.
        /// </summary>
        public const string Remove = "sortremove";
        /// <summary>
        /// This event is triggered when a sortable item is moved into a connected list.
        /// </summary>
        public const string Over = "sortover";
        /// <summary>
        /// This event is triggered when a sortable item is moved away from a connected list.
        /// </summary>
        public const string Out = "sortout";
        /// <summary>
        /// This event is triggered when using connected lists, every connected list on drag start receives it.
        /// </summary>
        public const string Activate = "sortactivate";
        /// <summary>
        /// This event is triggered when sorting was stopped, is propagated to all possible connected lists.
        /// </summary>
        public const string Deactivate = "sortdeactivate";
    }
}
