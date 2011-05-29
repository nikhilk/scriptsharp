//! Sharpen Core Runtime
//!

(function(global) {
"use strict";

function extend(o, items) {
  for (var n in items) {
    o[n] = items[n];
  }
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

// Core Type System - namespaces, classes and interfaces

#include "Base\TypeSystem.js"


// C# Patterns

#include "Base\Delegate.js";
#include "Base\Enumerate.js";
#include "Base\BCL.js"
#include "Base\ComponentModel.js"
#include "Base\Error.js"
#include "Base\Parse.js"
#include "Base\Misc.js"

createTypes(ss,
  [ IDisposable, 'IDisposable' ],
  [ IEnumerable, 'IEnumerable' ],
  [ IEnumerator, 'IEnumerator' ],
  [ IApplication, 'IApplication' ],
  [ IContainer, 'IContainer' ],
  [ IObjectFactory, 'IObjectFactory' ],
  [ IEventManager, 'IEventManager' ],
  [ IInitializable, 'IInitializable' ],
  [ IObserver, 'IObserver' ],
  [ Tuple, 'Tuple', null ],
  [ StringBuilder, 'StringBuilder', StringBuilder$proto ],
  [ EventArgs, 'EventArgs', null ],
  [ CancelEventArgs, 'CancelEventArgs', null, EventArgs ],
  [ Observable, 'Observable', Observable$proto, null ],
  [ ObservableCollection, 'ObservableCollection', ObservableCollection$proto, null, [ IEnumerable ] ]);

EventArgs.empty = new EventArgs();


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
  canAssign: canAssign,
  bind: bindObject,
  bindName: bindName,
  delegate: combineDelegates,
  undelegate: removeDelegate,
  enumerate: enumerate,
  number: parseNumber,
  date: parseDate,
  bool: parseBoolean,
  regExp: parseRegExp,
  error: createError,
  truncate: truncateNumber
});
})(window);
