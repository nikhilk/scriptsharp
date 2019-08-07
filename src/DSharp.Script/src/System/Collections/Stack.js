function Stack() {
    this.count = 0;
    this._items = [];
}
var Stack$ = {
    clear: function () {
        this._items.length = 0;
        this.count = 0;
    },
    contains: function (item) {
        for (var i = this.count - 1; i >= 0; i--) {
            if (this._items[i] === item) {
                return true;
            }
        }
        return false;
    },
    getEnumerator: function () {
        return new Enumerator(this._items.reverse());
    },
    peek: function () {
        return this._items[this.count - 1];
    },
    push: function (item) {
        this._items.push(item);
        this.count++;
    },
    pop: function () {
        if (this.count) {
            this.count--;
            return this._items.pop();
        }
        return undefined;
    }
};