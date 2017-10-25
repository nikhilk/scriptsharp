function Assembly(name, exports) {
    var fullName = name;
    var exportedTypes = exports

    createPropertyGet(this, "fullName", function () {
        return fullName;
    });
    createPropertyGet(this, "exportedTypes", function () {
        return exportedTypes;
    });
}