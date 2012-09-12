// TodoList.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using System.Serialization;

namespace Todo {

    internal sealed class TodoList {

        private const string StorageKey = "todoItems";

        private List<TodoItem> _items;

        public TodoList() {
            LoadItems();
        }

        public int ActiveCount {
            get {
                return _items.Reduce<int>(delegate(int previousValue, TodoItem item) {
                    return previousValue + (item.Completed ? 0 : 1);
                }, 0);
            }
        }

        public int CompletedCount {
            get {
                return _items.Reduce<int>(delegate(int previousValue, TodoItem item) {
                    return previousValue + (item.Completed ? 1 : 0);
                }, 0);
            }
        }

        public IEnumerable<TodoItem> Items {
            get {
                return _items;
            }
        }

        public TodoItem CreateItem(string text) {
            string id = Date.Now.GetTime().ToString();

            TodoItem item = new TodoItem();
            item.ID = id;
            item.Title = text;
            item.Completed = false;

            _items.Add(item);
            SaveItems();

            return item;
        }

        public void DeleteItem(string id) {
            foreach (TodoItem item in _items) {
                if (item.ID == id) {
                    _items.Remove(item);
                    SaveItems();

                    return;
                }
            }
        }

        public void DeleteItems() {
            for (int i = _items.Count - 1; i >= 0; i--) {
                if (_items[i].Completed) {
                    _items.RemoveAt(i);
                }
            }

            SaveItems();
        }

        public TodoItem GetItem(string id) {
            foreach (TodoItem item in _items) {
                if (item.ID == id) {
                    return item;
                }
            }
            return null;
        }

        private void LoadItems() {
            string json = (string)Window.LocalStorage.GetItem(StorageKey);

            if (String.IsNullOrEmpty(json) == false) {
                _items = Json.ParseData<List<TodoItem>>(json);
            }
            else {
                _items = new List<TodoItem>();
            }
        }

        private void SaveItems() {
            string json = Json.Stringify(_items);
            Window.LocalStorage.SetItem(StorageKey, json);
        }

        public void UpdateItem(TodoItem item, string text, bool completed) {
            item.Title = text;
            item.Completed = completed;
            SaveItems();
        }
    }
}
