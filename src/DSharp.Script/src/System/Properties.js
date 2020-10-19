function createReadonlyProperty(instance, propertyName , value) {
    Object.defineProperty(instance, propertyName, {
        get: function () { return value; },
        enumerable: true
    });

    return value;
}

function createPropertyGet(obj, propertyName, fn) {
    Object.defineProperty(obj, propertyName, {
        configurable: true,
        enumerable: true,
        get: fn
    });
}

function createPropertySet(obj, propertyName, fn) {
    Object.defineProperty(obj, propertyName, {
        configurable: true,
        enumerable: true,
        set: fn
    });
}

function defineProperty(instance, propertyName, value) {
    instance[propertyName] = value;
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