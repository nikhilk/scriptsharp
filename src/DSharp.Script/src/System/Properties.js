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
    var prop = value;

    if (instance.hasOwnProperty(propertyName))
    {
        instance[propertyName] = prop;
        return;
    }

    Object.defineProperty(instance, propertyName, {
        get: function () { return prop; },
        set: function (value) { prop = value; },
        configurable: true,
        enumerable: true
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