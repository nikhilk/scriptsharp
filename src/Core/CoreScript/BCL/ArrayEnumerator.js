///////////////////////////////////////////////////////////////////////////////
// ArrayEnumerator

ss.ArrayEnumerator = function#? DEBUG ArrayEnumerator$##(array) {
    this._array = array;
    this._index = -1;
    this.current = null;
}
ss.ArrayEnumerator.prototype = {
    moveNext: function#? DEBUG ArrayEnumerator$moveNext##() {
        this._index++;
        this.current = this._array[this._index];
        return (this._index < this._array.length);
    },
    reset: function#? DEBUG ArrayEnumerator$reset##() {
        this._index = -1;
        this.current = null;
    }
}

ss.ArrayEnumerator.registerClass('ArrayEnumerator', null, ss.IEnumerator);
