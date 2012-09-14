// Enumerator

function ArrayEnumerator(array) {
  this._array = array;
  this._index = -1;
  this.current = null;
}
var ArrayEnumerator$ = {
  moveNext: function() {
    this._index++;
    this.current = this._array[this._index];
    return (this._index < this._array.length);
  },
  reset: function() {
    this._index = -1;
    this.current = null;
  }
}
