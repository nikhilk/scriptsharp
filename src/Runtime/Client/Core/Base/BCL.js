// C#'ish patterns - Common BCL functionality

function Tuple(first, second, third) {
  this.first = first;
  this.second = second;
  if (arguments.length == 3) {
    this.third = third;
  }
}

function StringBuilder(s) {
  this._parts = isValue(s) ? [s] : [];
  this.isEmpty = this._parts.length == 0;
}
var StringBuilder$proto = {
  append: function(s) {
    if (isValue(s)) {
      this._parts.push(s);
      this.isEmpty = false;
    }
    return this;
  },

  appendLine: function(s) {
    this.append(s);
    this._parts.push('\r\n');
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

function EventArgs() {
}

function CancelEventArgs() {
  this.cancel = false;
}

function IDisposable() { }
// dispose()

function IEnumerable() { }
// getEnumerator()

function IEnumerator() { }
// get_current
// moveNext()
// reset()
