function ArrayEnumerator(obj) {
    var index = -1;
    var length = obj.length;
    this.current = null;

    this.moveNext = function () {
        index++;
        this.current = getItem(obj, index);
        return index < length;
    };

    this.reset = function () {
        index = -1;
        this.current = null;
    };
}

function KeyedEnumerator(obj, keys) {
    var index = -1;
    var length = keys.length;
    this.current = null;

    this.moveNext = function () {
        index++;
        this.current = { key: keys[index], value: getItem(obj, keys[index]), };
        return index < length;
    };

    this.reset = function () {
        index = -1;
        this.current = null;
    };
}

var _nopEnumerator = {
    current: null,
    moveNext: function () {
        return false;
    },
    reset: _nop
};

function enumerate(o) {

    if (!isValue(o)) {
        return _nopEnumerator;
    }

    if (typeof o.getEnumerator === "function") {
        return o.getEnumerator();
    }

    if (o.length !== undefined) {
        return new ArrayEnumerator(o);
    }

    return new KeyedEnumerator(o, keys(o));
}