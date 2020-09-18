function createEnumMap(enumMap) {
    var outerMap = {};
    for (var key in enumMap) {
        outerMap[enumMap[key]] = key;
    }
    return {
        Values: outerMap,
        Keys: enumMap
    };
}

function Enum(name, enumMap) {
    Enum.map[name] = createEnumMap(enumMap);

    Object.defineProperty(this, '_name', {
        value: name,
        writable: false,
        enumerable: false
    });
    this.map = enumMap;
    Object.assign(this, enumMap);
};
Enum.prototype.toString = function () {
    return this._name;
};
Enum.prototype.valueOf = function () {
    return this._name;
};

Enum.map = {};
Enum.getValues = function (enumeration) {
    var map = Enum.map[enumeration._name];
    return map && Object.values(map.Keys);
};
Enum.getNames = function (enumeration) {
    var map = Enum.map[enumeration._name];
    return map && Object.keys(map.Keys);
};
Enum.getName = function (enumeration, value) {
    var map = Enum.map[enumeration._name];
    return map && map.Values[value];
};
Enum.hasFlag = function (enumValue, flag) {
    return (enumValue | flag) === enumValue;
};
Enum.isDefined = function (enumeration, value) {
    var map = Enum.map[enumeration._name];
    return isValue(map.Values[value]) || isValue(map.Keys[value]);
};