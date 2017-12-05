// Collections

function toArray(obj) {
  return obj ? (typeof obj == 'string' ? JSON.parse('(' + obj + ')') : Array.prototype.slice.call(obj)) : null;
}
function removeItem(a, item) {
  var index = a.indexOf(item);
  return index >= 0 ? (a.splice(index, 1), true) : false;
}

function clearKeys(obj) {
  for (var key in obj) {
    delete obj[key];
  }
}
function keyExists(obj, key) {
  return obj[key] !== undefined;
}
function keys(obj) {
  if (Object.keys) {
    return Object.keys(obj);
  }
  var keys = [];
  for (var key in obj) {
    keys.push(key);
  }
  return keys;
}
function keyCount(obj) {
  return keys(obj).length;
}

function Enumerator(obj, keys) {
  var index = -1;
  var length = keys ? keys.length : obj.length;
  var lookup = keys ? function() { return { key: keys[index], value: obj[keys[index]] }; } :
                      function() { return obj[index]; };

  this.current = null;
  this.moveNext = function() {
    index++;
    this.current = lookup();
    return index < length;
  };
  this.reset = function() {
    index = -1;
    this.current = null;
  };
}
var _nopEnumerator = {
  current: null,
  moveNext: function() { return false; },
  reset: _nop
};

function enumerate(o) {
  if (!isValue(o)) {
    return _nopEnumerator;
  }
  if (o.getEnumerator) {
    return o.getEnumerator();
  }
  if (o.length !== undefined) {
    return new Enumerator(o);
  }
  return new Enumerator(o, keys(o));
}

function Stack() {
  this.count = 0;
  this._items = [];
}
var Stack$ = {

  clear: function() {
    this._items.length = 0;
    this.count = 0;
  },
  contains: function(item) {
    for (var i = this.count - 1; i >= 0; i--) {
      if (this._items[i] === item) {
        return true;
      }
    }
    return false;
  },
  getEnumerator: function() {
    return new Enumerator(this._items.reverse());
  },
  peek: function() {
    return this._items[this.count - 1];
  },
  push: function(item) {
    this._items.push(item);
    this.count++;
  },
  pop: function() {
    if (this.count) {
      this.count--;
      return this._items.pop();
    }
    return undefined;
  }
}

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

  clear: function() {
    this._items.length = 0;
    this._offset = 0;
    this.count = 0;
  },
  contains: function(item) {
    for (var i = this._offset, length = this._items.length; i <= length; i++) {
      if (this._items[i] === item) {
        return true;
      }
    }
    return false;
  },
  dequeue: function() {
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
  enqueue: function(item) {
    this._items.push(item);
    this.count++;
  },
  getEnumerator: function() {
    if (this._offset != 0) {
      _cleanQueue(this);
    }
    return new Enumerator(this._items);
  },
  peek: function() {
    return this._items.length ? this._items[this._offset] : undefined;
  }
}

