function createReadonlyProperty(instance, propertyName , value) {
    Object.defineProperty(instance, propertyName, {
        get: function () { return value; }
    });

    return value;
}

function createPropertyGet(obj, propertyName, fn) {
    Object.defineProperty(obj, propertyName, {
        configurable: true,
        get: fn
    });
}

function createPropertySet(obj, propertyName, fn) {
    Object.defineProperty(obj, propertyName, {
        configurable: true,
        set: fn
    });
}

function defineProperty(instance, propertyName) {
    var prop = undefined;
    Object.defineProperty(instance, propertyName, {
        get: function () { return prop; },
        set: function (value) { prop = value; }
    });
}
function initializeObject(obj, initializerMap) {
    if (!isValue(obj) || !isValue(initializerMap)) {
        return obj;
    }

    for (var prop in initializerMap) {
        obj[prop] = initializerMap[prop];
    }

    return obj;
}