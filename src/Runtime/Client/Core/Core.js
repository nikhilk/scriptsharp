//! Sharpen Core Runtime
//!

(function(global) {
"use strict";

function extend(o, items) {
  for (var n in items) {
    o[n] = items[n];
  }
  return o;
}

function remove(o, item) {
  if (o.constructor == Array) {
    var index = o.indexOf(item);
    return index >= 0 ? (o.splice(index, 1), true) : false;
  }
  if (o[item]) {
    delete o[item];
    return true;
  }
  return false;
}

function clear(o) {
  for (var n in o) {
    delete o[n];
  }
}

function isValue(o) {
  return (o !== undefined) && (o !== null);
}

#include "Base\Debug.js"
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
#include "Base\String.js"
#include "Base\Misc.js"

createTypes(ss,
  [ IDisposable, 'IDisposable' ],
  [ IEnumerable, 'IEnumerable' ],
  [ IEnumerator, 'IEnumerator' ],
  [ IApplication, 'IApplication' ],
  [ IContainer, 'IContainer' ],
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
  $version: '0.7.3.0',
  extend: extend,
  remove: remove,
  clear: clear,
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
  array: toArray,
  assert: debugAssert,
  fail: debugFail,
  trace: debugWriteLine,
  truncate: truncateNumber,
  now: now,
  today: today
});

// Minimal implementation that can be extended by Sharpen.Global.js

#include "Base\Global.js"

})(window);

/*
Misc notes -

Various Array, Dictionary and Script APIs to be handled via compiler transforms:

a.add(item) -> a.push(item)
a.addRange(items) -> a.push.apply(a, items)
a.clear() -> a.length = 0
a.clone() -> Array.apply(null, a)
a.contains(item) -> a.indexOf(item) >= 0
a.dequeue() -> a.shift()
a.enqueue(item) -> { a._queue = true; a.push(item); }
a.peek() -> a.length ? null : (a._queue ? a[0] : a[a.length - 1]) : null
a.extract(index, count) -> count ? a.slice(index, index + count) : a.slice(index)
a.insert(index, item) -> a.splice(index, 0, item)
a.insertRange(index, items) -> a.splice.apply(a, [index,0].concat(items))
a.remove(item) -> ss.remove(a, item)
a.removeAt(index) -> a.splice(index, 1)
a.removeRange(index, count) -> a.splice(index, count)

... assumes indexOf on Array.prototype

keyExists(o, k) -> o[k] !== undefined
keyCount(o) -> Object.keys(o).length

... assumes keys on Object

isNull(o) -> o === null
isUndefined(o) -> o === undefined
isNullOrUndefined(o) -> o == null


Various Array APIs not available in some IE versions:

every, filter, forEach, indexOf, lastIndexOf, map, some, reduce, reduceRight
*/
