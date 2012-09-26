/*! Script# Runtime
 * Designed and licensed for use and distribution with Script#-generated scripts.
 * Copyright (c) 2012, Nikhil Kothari, and the Script# Project.
 * More information at http://scriptsharp.com
 */

"use strict";

(function(global) {
  function _ss() {

  #include "Runtime\Misc.js"
  #include "Runtime\Collections.js"
  #include "Runtime\String.js"
  #include "Runtime\Delegate.js"
  #include "Runtime\EventArgs.js"
  #include "Runtime\Contracts.js"
  #include "Runtime\StringBuilder.js"
  #include "Runtime\Observable.js"
  #include "Runtime\Task.js"
  #include "Runtime\Culture.js"
  #include "Runtime\Format.js"
  #include "Runtime\TypeSystem.js"

  return extend(module('ss', null, {
      IDisposable: [ IDisposable ],
      IEnumerable: [ IEnumerable ],
      IEnumerator: [ IEnumerator ],
      IObserver: [ IObserver ],
      IApplication: [ IApplication ],
      IContainer: [ IContainer ],
      IObjectFactory: [ IObjectFactory ],
      IEventManager: [ IEventManager ],
      IInitializable: [ IInitializable ],
      EventArgs: [ EventArgs, { } ],
      CancelEventArgs: [ CancelEventArgs, { }, EventArgs ],
      StringBuilder: [ StringBuilder, StringBuilder$ ],
      Stack: [ Stack, Stack$ ],
      Queue: [ Queue, Queue$ ],
      Observable: [ Observable, Observable$ ],
      ObservableCollection: [ ObservableCollection, ObservableCollection$, null, IEnumerable ],
      Task: [ Task, Task$ ]
    }), {
      version: '0.8',

      isValue: isValue,
      extend: extend,
      keys: keys,
      keyCount: keyCount,
      keyExists: keyExists,
      clearKeys: clearKeys,
      enumerate: enumerate,
      array: toArray,
      remove: removeItem,
      boolean: parseBoolean,
      regexp: parseRegExp,
      number: parseNumber,
      truncate: truncate,
      now: now,
      today: today,
      error: error,
      string: string,
      emptyString: emptyString,
      whitespace: whitespace,
      format: format,
      compareStrings: compareStrings,
      startsWith: startsWith,
      endsWith: endsWith,
      padLeft: padLeft,
      padRight: padRight,
      trimStart: trimStart,
      trimEnd: trimEnd,
      insertString: insertString,
      removeString: removeString,
      replaceString: replaceString,
      bind: bind,
      bindAdd: bindAdd,
      bindSub: bindSub,
      bindExport: bindExport,
      deferred: deferred,

      module: module,

      isClass: isClass,
      isInterface: isInterface,
      typeOf: typeOf,
      type: type,
      canCast: canCast,
      safeCast: safeCast,
      canAssign: canAssign,
      instanceOf: instanceOf,

      culture: {
        neutral: neutralCulture,
        current: currentCulture
      },

      fail: fail
    });
  }

  global.define ? global.define('ss', [], _ss) : global.ss = _ss();
})(this);
