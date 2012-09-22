// Array Extensions

extend(Array.prototype, {
  clear: function() {
    this.length = 0;
  },

  contains: function(item) {
    return (this.indexOf(item) >= 0);
  },

  getRange: function(index, count) {
    return this.slice(index, index + count);
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
