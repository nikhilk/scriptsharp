var _namespaces = {
  ss: ss
};

function createNamespace(namespaceName) {
  var ns = _namespaces[namespaceName];
  return ns ? ns : global[namespaceName] = _namespaces[namespaceName] = { $name: namespaceName };
}

function createTypes(ns) {
  // Class Info:
  // [ fn, name, members, base, interfaces ]
  // - base and interfaces are optional
  //
  // Interface Info:
  // [ fn, name ]

  var typeInfos = Array.prototype.slice.call(arguments, 1);
  for (var i = 0, types = typeInfos.length; i < types; i++) {
    var typeInfo = typeInfos[i];
    var type = typeInfo[0];
    var name = typeInfo[1];
    var isClass = (typeInfo.length > 2);

    type.$type = type[isClass ? '$class' : '$interface'] = true;
    type.fullName = ns ? ns.$name + '.' + name : name;
    (ns || global)[name] = type;

    if (isClass) {
      var baseType = typeInfo[3];
      if (baseType) {
        var anonymous = function() {
        };
        anonymous.prototype = baseType.prototype;
        type.prototype = new anonymous();
        type.prototype.constructor = type;
      }

      type.baseType = baseType || Object;

      if (typeInfo[2]) {
        extend(type.prototype, typeInfo[2]);
      }

      if (typeInfo[4]) {
        type.$interfaces = typeInfo[4];
      }
    }
  }
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

function parseType(typeName) {
  // TODO: Support for walking the dots...
  var nsIndex = typeName.indexOf('.');
  var ns = nsIndex > 0 ? _namespaces[typeName.substr(0, nsIndex)] : global;
  var name = nsIndex > 0 ? typeName.substr(nsIndex + 1) : typeName;

  return ns ? ns[name] : null;
}

function canAssign(type, otherType) {
  // Checks if the specified type is equal to otherType,
  // or is a parent of otherType

  if ((type == Object) || (type == otherType)) {
    return true;
  }
  if (type.$class) {
    var baseType = otherType.baseType;
    while (baseType) {
      if (type == baseType) {
        return true;
      }
      baseType = baseType.baseType;
    }
  }
  else if (type.$interface) {
    var baseType = otherType;
    while (baseType) {
      var interfaces = baseType.$interfaces;
      if (interfaces && (interfaces.indexOf(type) >= 0)) {
        return true;
      }
      baseType = baseType.baseType;
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

// NOTE: Use /./.constructor to get a reference to the RegExp type
//       since explicitly referencing RegExp can turn off script minimization
//       optimizations.
var scriptTypes = [Error, Array, String, Number, Boolean, /./.constructor, Date, Function, Object];
for (var i = scriptTypes.length - 1; i >= 0; i--) {
  var type = scriptTypes[i];
  type.$type = type.$class = true;
  type.baseType = Object;
  type.fullName = type.name;
}
Object.baseType = null;
