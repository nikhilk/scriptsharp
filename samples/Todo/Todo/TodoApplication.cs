// TodoApplication.cs
//

using System;
using System.Html;
using jQueryApi;
using jQueryApi.Templating;

namespace Todo {

    internal sealed class TodoApplication {

        private TodoList _todoList;

        private jQueryTemplateObject _itemTemplate;

        private jQueryObject _newItem;
        private jQueryObject _list;
        private jQueryObject _activeCount;
        private jQueryObject _clearButton;

        static TodoApplication() {
            jQuery.OnDocumentReady(delegate() {
                new TodoApplication();
            });
        }

        public TodoApplication() {
            _todoList = new TodoList();

            _itemTemplate = jQuery.Select("#itemTemplate").Plugin<jQueryTemplateObject>();

            _newItem = jQuery.Select("#new-todo");
            _list = jQuery.Select("#todo-list");
            _activeCount = jQuery.Select("#todo-count");
            _clearButton = jQuery.Select("#clear-completed");

            _newItem.On("keyup", OnNewItemKeyUp);
            _list.On("change", ".toggle", OnItemToggle);
            _list.On("click", ".destroy", OnItemDelete);
            _list.On("dblclick", "label", OnItemEditBegin);
            _list.On("keypress", "input", OnItemEdit);
            _list.On("blur", "input", OnItemEditComplete);
            _clearButton.On("click", OnClearCompletedClick);

            UpdateRendering();
        }

        private string GetItemID(Element e) {
            return jQuery.FromElement(e).Closest("li").GetDataValue("id").ToString();
        }

        private void OnClearCompletedClick(jQueryEvent e) {
            _todoList.DeleteItems();
            UpdateRendering();
        }

        private void OnItemDelete(jQueryEvent e) {
            string id = GetItemID(e.Target);
            _todoList.DeleteItem(id);

            UpdateRendering();
        }

        private void OnItemEdit(jQueryEvent e) {
            if (e.Which == 13) {
                e.Target.Blur();
            }
        }

        private void OnItemEditBegin(jQueryEvent e) {
            jQuery.FromElement(e.Target).Closest("li")
                .AddClass("editing")
                .Find(".edit")
                .Focus();
        }

        private void OnItemEditComplete(jQueryEvent e) {
            string id = GetItemID(e.Target);
            TodoItem item = _todoList.GetItem(id);

            string text = jQuery.FromElement(e.Target).GetValue().Trim();
            if (String.IsNullOrEmpty(text)) {
                _todoList.DeleteItem(item.ID);
            }
            else {
                _todoList.UpdateItem(item, text, /* completed */ false);
            }

            UpdateRendering();
        }

        private void OnItemToggle(jQueryEvent e) {
            string id = GetItemID(e.Target);
            TodoItem item = _todoList.GetItem(id);

            if (item != null) {
                _todoList.UpdateItem(item, item.Title, !item.Completed);
                UpdateRendering();
            }
        }

        private void OnNewItemKeyUp(jQueryEvent e) {
            string text = _newItem.GetValue().Trim();
            if ((text.Length != 0) && (e.Which == 13)) {
                _todoList.CreateItem(text);
                _newItem.Value(String.Empty);

                UpdateRendering();
            }
        }

        private void UpdateRendering() {
            _list.Empty();
            _itemTemplate.RenderTemplate(_todoList.Items).AppendTo(_list);

            _clearButton.SwitchClass("hidden", _todoList.CompletedCount == 0);
            _activeCount.Text(_todoList.ActiveCount + " item(s) left");
        }
    }
}
