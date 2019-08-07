function Queue() {
    this.count = 0;
    this._items = [];
    this._offset = 0;
}
function _cleanQueue(q) {
    q._items = q._items.slice(q._offset);
    q._offset = 0;
}
var Queue$ = {
    clear: function () {
        this._items.length = 0;
        this._offset = 0;
        this.count = 0;
    },
    contains: function (item) {
        for (var i = this._offset, length = this._items.length; i <= length; i++) {
            if (this._items[i] === item) {
                return true;
            }
        }
        return false;
    },
    dequeue: function () {
        if (this.count) {
            var item = this._items[this._offset];
            if (++this._offset * 2 >= this._items.length) {
                _cleanQueue(this);
            }
            this.count--;
            return item;
        }
        return undefined;
    },
    enqueue: function (item) {
        this._items.push(item);
        this.count++;
    },
    getEnumerator: function () {
        if (this._offset != 0) {
            _cleanQueue(this);
        }
        return new Enumerator(this._items);
    },
    peek: function () {
        return this._items.length
            ? this._items[this._offset]
            : undefined;
    }
};