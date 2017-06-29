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
      IDisposable: [ _interfaceMarker, IDisposable ],
      IEnumerable: [ _interfaceMarker, IEnumerable ],
      IEnumerator: [ _interfaceMarker, IEnumerator ],
      IObserver: [ _interfaceMarker, IObserver ],
      IApplication: [ _interfaceMarker, IApplication ],
      IContainer: [ _interfaceMarker, IContainer ],
      IObjectFactory: [ _interfaceMarker, IObjectFactory ],
      IEventManager: [ _interfaceMarker, IEventManager ],
      IInitializable: [ _interfaceMarker, IInitializable ],
      EventArgs: [ _classMarker, EventArgs, { } ],
      CancelEventArgs: [ _classMarker, CancelEventArgs, { }, EventArgs ],
      StringBuilder: [ _classMarker, StringBuilder, StringBuilder$ ],
      Stack: [ _classMarker, Stack, Stack$ ],
      Queue: [ _classMarker, Queue, Queue$ ],
      Observable: [ _classMarker, Observable, Observable$ ],
      ObservableCollection: [ _classMarker, ObservableCollection, ObservableCollection$, null, IEnumerable ],
      Task: [ _classMarker, Task, Task$ ]
    }), {
      version: '0.8',

      isValue: isValue,
      value: value,
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
      date: parseDate,
      truncate: truncate,
      now: now,
      today: today,
      compareDates: compareDates,
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
      trim: trim,
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
      paramsGenerator: paramsGenerator,
      createPropertyGet: createPropertyGet,
      createPropertySet: createPropertySet,
      
      module: module,
      modules: _modules,

      isClass: isClass,
      isInterface: isInterface,
      typeOf: typeOf,
      type: type,
      typeName: typeName,
      canCast: canCast,
      safeCast: safeCast,
      canAssign: canAssign,
      instanceOf: instanceOf,
      baseProperty : baseProperty,
      classMarker : _classMarker,
      interfaceMarker : _interfaceMarker,
      getConstructorParams : getConstructorParams,

      culture: {
        neutral: neutralCulture,
        current: currentCulture
      },

      fail: fail
    });
  }


  function _export() {
    var ss = _ss();
    typeof exports == 'object' ? ss.extend(exports, ss) : global.ss = ss;
  }

  global.define ? global.define('ss', [], _ss) : _export();
})(this);
