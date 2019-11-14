function createGenericType(ctorMethod, typeArguments) {
    var genericConstructor = getGenericConstructor(ctorMethod, typeArguments);
    var args = [null].concat(Array.prototype.slice.call(arguments).splice(2));
    return new (Function.prototype.bind.apply(genericConstructor, args));
}

function getGenericConstructor(ctorMethod, typeArguments) {
    if (!isValue(ctorMethod)) {
        return null;
    }

    var key = createGenericConstructorKey(ctorMethod, typeArguments);
    var genericInstance = _genericConstructorCache[key];

    if (!genericInstance) {
        if (isInterface(ctorMethod)) {
            genericInstance = function () { };
            genericInstance.$type = _interfaceMarker;
            genericInstance.$name = ctorMethod.$name;
            genericInstance.$interfaces = ctorMethod.$interfaces;
            genericInstance.$typeArguments = typeArguments || {};
        }
        else {
            genericInstance = function () {
                ctorMethod.apply(this, Array.prototype.slice.call(arguments));
                this.__proto__.constructor.$typeArguments = typeArguments || {};
                this.__proto__.constructor.$base = this.__proto__.constructor.$base || ctorMethod.$base;
                this.__proto__.constructor.$interfaces = this.__proto__.constructor.$interfaces  || ctorMethod.$interfaces;
                this.__proto__.constructor.$type = this.__proto__.constructor.$type || ctorMethod.$type;
                this.__proto__.constructor.$name = this.__proto__.constructor.$name || ctorMethod.$name;
                this.__proto__.constructor.$constructorParams = this.__proto__.constructor.$constructorParams || ctorMethod.$constructorParams;
            };
            genericInstance.prototype = Object.create(ctorMethod.prototype);
            genericInstance.prototype.constructor = genericInstance;
        }
        genericInstance.prototype = Object.create(ctorMethod.prototype);
        genericInstance.prototype.constructor = genericInstance;
        _genericConstructorCache[key] = genericInstance;
    }

    return genericInstance;
}

function createGenericConstructorKey(ctorMethod, typeArguments) {
    var key = getTypeName(ctorMethod);
    key += "<";
    key += Object.getOwnPropertyNames(typeArguments)
        .map(function (parameterKey) { return getTypeName(typeArguments[parameterKey]); })
        .join(",");
    key += ">";

    return key;
}

function getTypeName(instance) {
    try {
        return instance["$name"] || instance.constructor.$name || instance["name"];
    }
    catch (ex) {
        return instance.toString();
    }
}

function getTypeArgument(instance, typeArgumentName) {
    if (!isValue(instance) || emptyString(typeArgumentName) || !isValue(instance.constructor.$typeArguments)) {
        return null;
    }

    return instance.constructor.$typeArguments[typeArgumentName];
}