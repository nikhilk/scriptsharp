//! Sharpen Core Runtime
//!

(function(global) {

function extend(o, items) {
  for (var n in items) {
    o[n] = items[n];
  }
}

function contains(items, o) {
  for (var i = 0, len = items.length; i < len; i++) {
    if (items[i] == o) {
      return true;
    }
  }
  return false;
}

function isValue(o) {
  return (o !== undefined) && (o !== null);
}


#include "Base\Startup.js"

// The ss global object is created within the Loader script.
// If the Loader is not being used, create it right here, along with
// init and ready both referring to the onStartup method, so
// ss.init and ss.ready work without the Loader dependency.
 
var ss = global.ss;
if (!ss) {
  global.ss = ss = {
    init: onStartup,
    ready: onStartup
  };
}

#include "Base\TypeSystem.js"

// Finally populate the ss object with the public APIs

extend(ss, {
  $name: 'ss',
  $version: '0.7.2.0',
  isValue: isValue,
  ns: createNamespace,
  type: createTypes,
  parseType: parseType,
  getType: getType,
  isOfType: isOfType,
  safeCast: safeCast,
  canCast: canCast,
  canAssign: canAssign
});

})(window);
