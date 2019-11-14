function Nullable(value) {
    this.value = value;
}
createPropertyGet(Nullable, 'Value', function () {
    return this.value;
});
createPropertyGet(Nullable, 'HasValue', function () {
    return this.value !== undefined;
});
Nullable.prototype.valueOf = function () {
    return this.value;
};
Nullable.prototype.toString = function () {
    return this.value;
};
var Nullable$ = {
    getValueOrDefault: function (defaultValue) {
        return this.value || defaultValue;
    }
}