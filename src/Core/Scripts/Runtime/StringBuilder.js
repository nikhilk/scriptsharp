// StringBuilder

function StringBuilder(s) {
  this._parts = isValue(s) && s !== '' ? [s] : [];
  this.isEmpty = this._parts.length == 0;
}
var StringBuilder$ = {
  append: function(s) {
    if (isValue(s) && s !== '') {
      this._parts.push(s);
      this.isEmpty = false;
    }
    return this;
  },

  appendLine: function(s) {
    this.append(s);
    this.append('\r\n');
    this.isEmpty = false;
    return this;
  },

  clear: function() {
    this._parts = [];
    this.isEmpty = true;
  },

  toString: function(s) {
    return this._parts.join(s || '');
  }
};

