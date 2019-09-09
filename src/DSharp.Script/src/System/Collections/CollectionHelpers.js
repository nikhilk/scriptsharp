function createFallbackFunction(name, fallback) {
    return function (instance) {
        if (typeof instance[name] === "function") {
            return instance[name].apply(instance, Array.prototype.splice.call(arguments, 1));
        }

        return fallback.apply(null, arguments);
    };
}

function toArray(obj) {
    return obj
        ? typeof obj === "string"
            ? JSON.parse("(" + obj + ")")
            : Array.prototype.slice.call(obj)
        : null;
}

var removeAt = createFallbackFunction("removeAt", function (obj, index) {
    return index >= 0
        ? (obj.splice(index, 1), true)
        : false;
});

var removeItem = createFallbackFunction("remove", function (obj, item) {
    var index = obj.indexOf(item);
    return index >= 0
        ? (obj.splice(index, 1), true)
        : false;
});

function getRange(obj, start, end) {
    return obj.slice(start, end);
};

function clearKeys(obj) {
    for (var key in obj) {
        delete obj[key];
    }
}
function keyExists(obj, key) {
    return obj[key] !== undefined;
}
function keyValueExists(obj, keyValue) {
    return obj[keyValue.key] === keyValue.value;
}

function addKeyValue(obj, key, value) {
    return obj[key] = value;
}

function keys(obj) {
    if (Object.keys) {
        return Object.keys(obj);
    }
    var keys = [];
    for (var key in obj) {
        keys.push(key);
    }
    return keys;
}

function values(obj) {
    if (Object.values) {
        return Object.values(obj);
    }
    var values = [];
    for (var key in obj) {
        values.push(obj[key]);
    }
    return values;
}

function keyCount(obj) {
    return keys(obj).length;
}

var contains = createFallbackFunction("contains", function (obj, value) {
    return obj.indexOf(value) >= 0;
});

var insert = createFallbackFunction("insert", function (obj, index, value) {
    obj.splice(index, 0, value);
});

var clear = createFallbackFunction("clear", function (obj) {
    obj.length = 0;
});

var addRange = createFallbackFunction("addRange", function (obj, range) {
    if (Array.isArray(range)) {
        for (var i = 0; i < range.length; ++i) {
            obj.push(range[i]);
        }

        return;
    }

    while (range.moveNext()) {
        obj.push(range.current);
    }
});

function addRangeParams(obj) {
    var params = arguments.slice(1);
    addRange(obj, params);
}

var getItem = createFallbackFunction("get_item", function (obj, key) {
    return obj[key];
});

var setItem = createFallbackFunction("set_item", function (obj, key, val) {
    return obj[key] = val;
});
