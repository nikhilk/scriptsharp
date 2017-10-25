/*! Script# Runtime
 * Designed and licensed for use and distribution with Script#-generated scripts.
 * Copyright (c) 2012, Nikhil Kothari, and the Script# Project.
 * More information at http://scriptsharp.com
 */

"use strict";

(function(global) {
  function _ss() {
  #include "Runtime\Assembly.js"
  #include "Runtime\Misc.js"
  #include "Runtime\Collections.js"
  #include "Runtime\Guid.js"
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

  var namespaceTable = {
      System: "System",
      SystemCollections: "System.Collections",
      SystemComponentModel: "System.ComponentModel",
      SystemReflection: "System.Reflection",
      SystemText: "System.Text",
      SystemThreading: "System.Threading"
  }

  return extend(module('ss', null, {
      IDisposable: defineInterface(IDisposable, [], namespaceTable.System),
      IEnumerable: defineInterface(IEnumerable, [], namespaceTable.SystemCollections),
      IEnumerator: defineInterface(IEnumerator, [], namespaceTable.SystemCollections),
      IObserver: defineInterface(IObserver, [], namespaceTable.SystemComponentModel),
      IApplication: defineInterface(IApplication, [], namespaceTable.SystemComponentModel),
      IContainer: defineInterface(IContainer, [], namespaceTable.SystemComponentModel),
      IObjectFactory: defineInterface(IObjectFactory, [], namespaceTable.SystemComponentModel),
      IEventManager: defineInterface(IEventManager, [], namespaceTable.SystemComponentModel),
      IInitializable: defineInterface(IInitializable, [], namespaceTable.SystemComponentModel),
      Assembly: defineClass(Assembly, {}, [], null, [], namespaceTable.SystemReflection),
      EventArgs: defineClass(EventArgs, {}, [], null, [], namespaceTable.System),
      CancelEventArgs: defineClass(CancelEventArgs, {}, [], null, [], namespaceTable.System),
      StringBuilder: defineClass(StringBuilder, StringBuilder$, [], null, [], namespaceTable.SystemText),
      Stack: defineClass(Stack, Stack$, [], null, [], namespaceTable.SystemCollections),
      Queue: defineClass(Queue, Queue$, [], null, [], namespaceTable.SystemCollections),
      Observable: defineClass(Observable, Observable$, [], null, [], namespaceTable.SystemComponentModel),
      ObservableCollection: defineClass(ObservableCollection, ObservableCollection$, [], null, [IEnumerable], namespaceTable.SystemCollections),
      Task: defineClass(Task, Task$, [], null, [], namespaceTable.SystemThreading),
      Guid: defineClass(Guid, Guid$, [], null, [], namespaceTable.System)
    }), {
      version: '1.0',

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
      defineClass : defineClass,
      defineInterface : defineInterface,
      getConstructorParams : getConstructorParams,
      createInstance : paramsGenerator(1, createInstance),
      
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
