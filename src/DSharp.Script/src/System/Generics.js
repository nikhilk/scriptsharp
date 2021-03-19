function createGenericType(ctorMethod, typeArguments) {
    var genericConstructor = getGenericConstructor(ctorMethod, typeArguments);
    var args = [null].concat(Array.prototype.slice.call(arguments).splice(2));
    return new (Function.prototype.bind.apply(genericConstructor, args));
}

function mapGenericType(type, typeArguments) {
    return type.IsGenericTypeDefinition
        ? type.makeGenericType(typeArguments)
        : type;
}

function getGenericConstructor(ctorMethod, typeArguments) {
    if (!isValue(ctorMethod)) {
        return null;
    }

    var key = createGenericConstructorKey(ctorMethod, typeArguments);

    if (!_genericConstructorCache[key]) {
        _genericConstructorCache[key] = createGenericConstructorProxy(key, ctorMethod, typeArguments);
    }
    return _genericConstructorCache[key];
}

function createGenericConstructorProxy(key, ctorMethod, typeArguments) {

    function proxyMember(name, impl) {
        Object.defineProperty(genericInstance, name, {
            get: function () { return impl ? impl() : ctorMethod[name]; }
        });
    }

    function getInterfaces() {
        var interfaces;
        return function () {
            if (!interfaces && ctorMethod.$interfaces) {
                interfaces = []
                for (var i = 0; i < ctorMethod.$interfaces.length; ++i) {
                    interfaces.push(mapGenericType(ctorMethod.$interfaces[i], typeArguments))
                }
            }
            return interfaces;
        }
    }

    function getConstructorParams() {
        var constructorParams;
        return function () {
            if (!constructorParams && ctorMethod.$constructorParams) {
                constructorParams = [];
                for (var i = 0; i < ctorMethod.$constructorParams.length; ++i) {
                    var param = ctorMethod.$constructorParams[i];
                    if (typeof (param) === "string") {
                        param = typeArguments[param];
                    }
                    constructorParams.push(mapGenericType(param, typeArguments))
                }
            }
            return constructorParams;
        }
    }

    function getTypeArguments() {
        return typeArguments;
    }

    var genericInstance = namedFunction(key, function () {
        ctorMethod.apply(this, Array.prototype.slice.call(arguments));
    });

    genericInstance.IsGenericTypeDefinition = true;
    genericInstance.$name = key;
    genericInstance.GenericTypeArguments = values(typeArguments || {});
    genericInstance.GenericTemplate = ctorMethod;

    proxyMember("$type");
    proxyMember("$members");
    proxyMember("$interfaces", getInterfaces());
    proxyMember("$constructorParams", getConstructorParams());
    proxyMember("$typeArguments", getTypeArguments);

    if (ctorMethod.$base && ctorMethod.$base.IsGenericTypeDefinition) {
        var baseType = ctorMethod.$base.makeGenericType(typeArguments);
        chainPrototype(genericInstance, baseType);
    }
    else {
        chainPrototype(genericInstance, ctorMethod);
    }

    ctorMethod.$prototypeDescription && extendType(genericInstance.prototype, ctorMethod.$prototypeDescription);

    return genericInstance;
}

function chainPrototype(instance, baseType) {
    instance.prototype = Object.create(baseType.prototype)
    instance.prototype.constructor = instance;
    instance.$base = baseType;
}

function createGenericConstructorKey(ctorMethod, typeArguments) {
    var key = getTypeName(ctorMethod);
    key += "\u1438";
    key += Object.getOwnPropertyNames(typeArguments)
        .map(function (parameterKey) { return getTypeName(typeArguments[parameterKey]); })
        .join("\u02cf");
    key += "\u1433";

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

function getTypeArgument(instance, typeArgumentName, templateType) {
    if (!isValue(instance) || emptyString(typeArgumentName)) {
        return null;
    }

    var type = instance.$type
        ? instance
        : instance.constructor;

    if (templateType) {
        while (type && type.GenericTemplate != templateType) {
            type = type.$base;
        }
    }

    if (isValue(type) && isValue(type.$typeArguments)) {
        return type.$typeArguments[typeArgumentName];
    }

    return null;
}

function getGenericTemplate(ctorMethod, typeParameters, makeGenericType) {
    if (!isValue(ctorMethod)) {
        return null;
    }

    makeGenericType = makeGenericType || function (typeArguments) {
        var args = {};
        for (var i = 0, ln = typeParameters.length; i < ln; ++i) {
            args[typeParameters[i]] = typeArguments[i];
        }
        return getGenericConstructor(ctorMethod, args);
    }

    var genericTemplate = {
        IsGenericTypeDefinition: true,
        makeGenericType: makeGenericType
    };

    function proxyMember(name, impl) {
        Object.defineProperty(genericTemplate, name, {
            get: function () { return impl ? impl() : ctorMethod[name]; }
        });
    }

    function getTypeParameters() {
        var params;
        return function () {
            if (!params) {
                params = {}
                for (var i = 0, ln = typeParameters.length; i < ln; ++i) {
                    params[typeParameters[i]] = null;
                }
            }
            return params;
        }
    }

    function getGenericTypeArguments() {
        return function () { values(getTypeParameters()() || {}) }
    }

    proxyMember("$type");
    proxyMember("$name");
    proxyMember("$interfaces");
    proxyMember("$typeArguments", getTypeParameters());
    proxyMember("GenericTypeArguments", getGenericTypeArguments());

    return genericTemplate;
}

var makeGenericType = paramsGenerator(1, function (genericTemplate, typeArguments) {
    if (!isValue(genericTemplate) || !genericTemplate.IsGenericTypeDefinition) {
        return null;
    }

    return genericTemplate.makeGenericType(typeArguments);
});

function makeMappedGenericTemplate(ctorMethod, typeMap) {
    if (!isValue(ctorMethod)) {
        return null;
    }
    var typeParameters = keys(typeMap);

    return getGenericTemplate(ctorMethod, typeParameters, function (typeArguments) {
        var args = {};
        for (var i = 0; i < typeParameters.length; ++i) {
            var mappedType = typeMap[typeParameters[i]];
            if (typeof (mappedType) === "string") {
                args[typeParameters[i]] = typeArguments[mappedType]
            }
            else {
                args[typeParameters[i]] = mappedType
            }
        }
        return getGenericConstructor(ctorMethod, args);
    });
}