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

    return typeRegistry[typeName] = type;
  }

  return typeInfo;
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

