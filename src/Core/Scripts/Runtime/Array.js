// Array Extensions

extend(Array.prototype, {
  add: function(item) {
    this[this.length] = item;
  },

  addRange: function(items) {
    this.push.apply(this, items);
  },

  clear: function() {
    this.length = 0;
  },

  clone: function() {
    if (this.length === 1) {
      return [this[0]];
    }
    else {
      return Array.apply(null, this);
    }
  },

  contains: function(item) {
    var index = this.indexOf(item);
    return (index >= 0);
  },

  dequeue: function() {
    return this.shift();
  },

  enqueue: function(item) {
    // We record that this array instance is a queue, so we
    // can implement the right behavior in the peek method.
    this._queue = true;
    this.push(item);
  },

  peek: function() {
    if (this.length) {
      var index = this._queue ? 0 : this.length - 1;
      return this[index];
    }
    return null;
  },

  extract: function(index, count) {
    if (!count) {
      return this.slice(index);
    }
    return this.slice(index, index + count);
  },

  getEnumerator: function() {
    return new ArrayEnumerator(this);
  },

  groupBy: function(callback, instance) {
    var length = this.length;
    var groups = [];
    var keys = {};
    for (var i = 0; i < length; i++) {
      if (i in this) {
        var key = callback.call(instance, this[i], i);
        if (String.isNullOrEmpty(key)) {
          continue;
        }
        var items = keys[key];
        if (!items) {
          items = [];
          items.key = key;

          keys[key] = items;
          groups.add(items);
        }
        items.add(this[i]);
      }
    }
    return groups;
  },

  index: function(callback, instance) {
    var length = this.length;
    var items = {};
    for (var i = 0; i < length; i++) {
      if (i in this) {
        var key = callback.call(instance, this[i], i);
        if (String.isNullOrEmpty(key)) {
          continue;
        }
        items[key] = this[i];
      }
    }
    return items;
  },

  insert: function(index, item) {
    this.splice(index, 0, item);
  },

  insertRange: function(index, items) {
    if (index === 0) {
      this.unshift.apply(this, items);
    }
    else {
      for (var i = 0; i < items.length; i++) {
        this.splice(index + i, 0, items[i]);
      }
    }
  },

  remove: function(item) {
    var index = this.indexOf(item);
    if (index >= 0) {
      this.splice(index, 1);
      return true;
    }
    return false;
  },

  removeAt: function(index) {
    this.splice(index, 1);
  },

  removeRange: function(index, count) {
    return this.splice(index, count);
  }
});

Array.toArray = function(obj) {
  return Array.prototype.slice.call(obj);
}
