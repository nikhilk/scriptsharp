function Nullable(value) {
    this.value = value;
}

Nullable.prototype.valueOf = function () {
    return this.value;
};
Nullable.prototype.toString = function () {
    return this.value;
};
var Nullable$ = {
    getValueOrDefault: function (defaultValue) {
        return this.value || defaultValue;
    },
    $get_Value: function () {
        return this.value;
    },
    $get_HasValue: function () {
        return this.value !== undefined;
    }
}