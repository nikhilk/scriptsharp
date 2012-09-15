//! Script# Core Runtime
//! More information at http://scriptsharp.com
//!

define('ss', [], function() {
"use strict";

var global = this;

// TODO: Inline and remove
function isUndefined(o) {
  return (o === undefined);
}

// TODO: Inline and remove
function isNull(o) {
  return (o === null);
}

// TODO: Use !isValue
function isNullOrUndefined(o) {
  return (o === null) || (o === undefined);
}

function isValue(o) {
  return (o !== null) && (o !== undefined);
}

function extend(o, items) {
  for (var n in items) {
    o[n] = items[n];
  }
  return o;
}

#include "Runtime\Object.js"
#include "Runtime\Array.js"
#include "Runtime\String.js"
#include "Runtime\Console.js"
#include "Runtime\Error.js"
#include "Runtime\Date.js"
#include "Runtime\Math.js"

#include "Runtime\TypeSystem.js"
#include "Runtime\Delegate.js"
#include "Runtime\EventArgs.js"
#include "Runtime\Contracts.js"
#include "Runtime\Enumerator.js"
#include "Runtime\StringBuilder.js"
#include "Runtime\Observable.js"
#include "Runtime\Tuple.js"
#include "Runtime\Task.js"
#include "Runtime\Culture.js"
#include "Runtime\Parse.js"
#include "Runtime\Format.js"

var ss = module('ss', null, {
  IDisposable: [ IDisposable ],
  IEnumerable: [ IEnumerable ],
  IEnumerator: [ IEnumerator ],
  IObserver: [ IObserver ],
  IApplication: [ IApplication ],
  IContainer: [ IContainer ],
  IObjectFactory: [ IObjectFactory ],
  IEventManager: [ IEventManager ],
  IInitializable: [ IInitializable ],
  ArrayEnumerator: [ ArrayEnumerator, ArrayEnumerator$, null, IEnumerator ],
  Delegate: [ Delegate, { } ],
  EventArgs: [ EventArgs, { } ],
  CancelEventArgs: [ CancelEventArgs, { }, EventArgs ],
  StringBuilder: [ StringBuilder, StringBuilder$ ],
  Observable: [ Observable, Observable$ ],
  ObservableCollection: [ ObservableCollection, ObservableCollection$, null, IEnumerable ],
  Tuple: [ Tuple, { } ],
  Task: [ Task, Task$ ],
  Deferred: [ Deferred, Deferred$ ]
});

Delegate.Empty = function() { };
EventArgs.Empty = new EventArgs();

return extend(ss, {
  version: '0.7.6.0',

  isUndefined: isUndefined,
  isNull: isNull,
  isNullOrUndefined: isNullOrUndefined,
  isValue: isValue,

  module: module,
  isClass: isClass,
  isInterface: isInterface,
  getType: getType,
  baseType: getBaseType,
  interfaces: getInterfaces,
  canCast: canCast,
  safeCast: safeCast,
  canAssign: canAssign,
  isOfType: isOfType,
  typeName: getTypeName,
  type: parseType,

  culture: {
    neutral: neutralCulture,
    current: currentCulture
  }
});

});
