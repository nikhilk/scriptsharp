// Type System

var _modules = {};

var _classMarker = 'class';
var _interfaceMarker = 'interface';

function createType(typeName, typeInfo, typeRegistry) {
  // The typeInfo is either an array of information representing
  // classes and interfaces, or an object representing enums and resources
  // or a function, representing a record factory.

  if (Array.isArray(typeInfo)) {
    var type = typeInfo[0];

    // A class is minimally the class type and an object representing
    // its prototype members, and optionally the base type, and references
    // to interfaces implemented by the class.
    if (typeInfo.length >= 2) {
      var baseType = typeInfo[2];
      if (baseType) {
        // Chain the prototype of the base type (using an anonymous type
        // in case the base class is not creatable, or has side-effects).
        var anonymous = function() {};
        anonymous.prototype = baseType.prototype;
        type.prototype = new anonymous();
        type.prototype.constructor = type;
      }

      // Add the type's prototype members if there are any
      typeInfo[1] && extend(type.prototype, typeInfo[1]);

      type.$base = baseType || Object;
      type.$interfaces = typeInfo.slice(3);
      type.$type = _classMarker;
    }
    else {
      type.$type = _interfaceMarker;
    }

    type.$name = typeName;
    return typeRegistry[typeName] = type;
  }

  return typeInfo;
}

function isClass(fn) {
  return fn.$type == _classMarker;
}

function isInterface(fn) {
  return fn.$type == _interfaceMarker;
}

function getType(instance) {
  var ctor = null;

  // NOTE: We have to catch exceptions because the constructor
  //       cannot be looked up on native COM objects
  try {
    ctor = instance.constructor;
  }
  catch (ex) {
  }
  if (!ctor || !ctor.$type) {
    ctor = Object;
  }
  return ctor;
}

function getBaseType(type) {
  return type.$base || Object;
}

function getInterfaces(type) {
  return type.$interfaces || [];
}

function canAssign(type, otherType) {
  // Checks if the specified type is equal to otherType,
  // or is a parent of otherType

  if ((type == Object) || (type == otherType)) {
    return true;
  }
  if (type.$type == _classMarker) {
    var baseType = otherType.$base;
    while (baseType) {
      if (type == baseType) {
        return true;
      }
      baseType = baseType.$base;
    }
  }
  else if (type.$type == _interfaceMarker) {
    var baseType = otherType;
    while (baseType) {
      var interfaces = baseType.$interfaces;
      if (interfaces && (interfaces.indexOf(type) >= 0)) {
        return true;
      }
      baseType = baseType.$base;
    }
  }
  return false;
}

function isOfType(instance, type) {
  // Checks if the specified instance is of the specified type

  if (!isValue(instance)) {
    return false;
  }

  if ((type == Object) || (instance instanceof type)) {
    return true;
  }

  var instanceType = getType(instance);
  return canAssign(type, instanceType);
}

function canCast(instance, type) {
  return isOfType(instance, type);
}

function safeCast(instance, type) {
  return isOfType(instance, type) ? instance : null;
}

function getTypeName(type) {
  return type.$name;
}

function parseType(s) {
  var nsIndex = s.indexOf('.');
  var ns = nsIndex > 0 ? _modules[s.substr(0, nsIndex)] : global;
  var name = nsIndex > 0 ? s.substr(nsIndex + 1) : s;

  return ns ? ns[name] : null;
}

function module(name, implementation, exports) {
  var registry = _modules[name] = {};

  if (implementation) {
    for (var typeName in implementation) {
      createType(typeName, implementation[typeName], registry);
    }
  }

  var api = {};
  if (exports) {
    for (var typeName in exports) {
      api[typeName] = createType(typeName, exports[typeName], registry);
    }
  }

  return api;
}

