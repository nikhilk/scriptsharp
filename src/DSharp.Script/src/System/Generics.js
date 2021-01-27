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
        }
        else {
            genericInstance = function () {
                ctorMethod.apply(this, Array.prototype.slice.call(arguments));
                var ctr = this.__proto__.constructor;
                ctr.$typeArguments = typeArguments || {};
                ctr.$base = ctr.$base || genericInstance.$base;
                ctr.$interfaces = ctr.$interfaces || genericInstance.$interfaces;
                ctr.$type = ctr.$type || genericInstance.$type;
                ctr.$name = ctr.$name || genericInstance.$name;
                ctr.$constructorParams = ctr.$constructorParams || genericInstance.$constructorParams;
            };
            genericInstance.$base = ctorMethod.$base;
            genericInstance.$interfaces = ctorMethod.$interfaces;
            genericInstance.$type = ctorMethod.$type;
            genericInstance.$name = ctorMethod.$name;
            genericInstance.$constructorParams = ctorMethod.$constructorParams;
        }
        genericInstance.prototype = Object.create(ctorMethod.prototype);
        genericInstance.prototype.constructor = genericInstance;
        genericInstance.$typeArguments = typeArguments || {};
        genericInstance.IsGenericTypeDefinition = true;
        genericInstance.GenericTypeArguments = values(typeArguments || {});
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
        return instance && instance.toString();
    }
}

function getTypeArgument(instance, typeArgumentName) {
    if (!isValue(instance) || emptyString(typeArgumentName) || !isValue(instance.constructor.$typeArguments)) {
        return null;
    }

    return instance.constructor.$typeArguments[typeArgumentName];
}

function getGenericTemplate(ctorMethod, typeParameters) {
    if (!isValue(ctorMethod)) {
        return null;
    }

    var params = {};
    for (var i = 0, ln = typeParameters.length; i < ln; ++i) {
        params[typeParameters[i]] = null;
    }

    return {
        $type: ctorMethod.$type,
        $name: ctorMethod.$name,
        $interfaces: ctorMethod.$interfaces,
        $typeArguments: params,
        IsGenericTypeDefinition: true,
        GenericTypeArguments: values(params || {}),
        makeGenericType: function (typeArguments) {
            var args = {};
            for (var i = 0, ln = typeParameters.length; i < ln; ++i) {
                args[typeParameters[i]] = typeArguments[i];
            }
            return getGenericConstructor(ctorMethod, args);
        }
    }
}

var makeGenericType = paramsGenerator(1, function (genericTemplate, typeArguments) {
    if (!isValue(genericTemplate) || !genericTemplate.IsGenericTypeDefinition) {
        return null;
    }

    return genericTemplate.makeGenericType(typeArguments);
});