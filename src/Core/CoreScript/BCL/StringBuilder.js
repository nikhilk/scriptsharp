///////////////////////////////////////////////////////////////////////////////
// StringBuilder

ss.StringBuilder = function#? DEBUG StringBuilder$##(s) {
    this._parts = !ss.isNullOrUndefined(s) ? [s] : [];
    this.isEmpty = this._parts.length == 0;
}
ss.StringBuilder.prototype = {
    append: function#? DEBUG StringBuilder$append##(s) {
        if (!ss.isNullOrUndefined(s)) {
            this._parts.add(s);
            this.isEmpty = false;
        }
        return this;
    },

    appendLine: function#? DEBUG StringBuilder$appendLine##(s) {
        this.append(s);
        this.append('\r\n');
        this.isEmpty = false;
        return this;
    },

    clear: function#? DEBUG StringBuilder$clear##() {
        this._parts = [];
        this.isEmpty = true;
    },

    toString: function#? DEBUG StringBuilder$toString##(s) {
        return this._parts.join(s || '');
    }
};

ss.StringBuilder.registerClass('StringBuilder');
