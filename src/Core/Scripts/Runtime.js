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

  var ns_System = "System";
  var ns_System$Collections = "System.Collections";
  var ns_System$ComponentModel = "System.ComponentModel";
  var ns_System$Reflection = "System.Reflection";
  var ns_System$Text = "System.Text";
  var ns_System$Threading = "System.Threading";

  return extend(module('ss', '1.0.0.0', null, {
      IDisposable: defineInterface(IDisposable, [], ns_System),
      IEnumerable: defineInterface(IEnumerable, [], ns_System$Collections),
      IEnumerator: defineInterface(IEnumerator, [], ns_System$Collections),
      IObserver: defineInterface(IObserver, [], ns_System$ComponentModel),
      IApplication: defineInterface(IApplication, [], ns_System$ComponentModel),
      IContainer: defineInterface(IContainer, [], ns_System$ComponentModel),
      IObjectFactory: defineInterface(IObjectFactory, [], ns_System$ComponentModel),
      IEventManager: defineInterface(IEventManager, [], ns_System$ComponentModel),
      IInitializable: defineInterface(IInitializable, [], ns_System$ComponentModel),
      Assembly: defineClass(Assembly, Assembly$, [], null, [], ns_System$Reflection),
      AssemblyName: defineClass(AssemblyName, AssemblyName$, [], null, [], ns_System$Reflection),
      EventArgs: defineClass(EventArgs, {}, [], null, [], ns_System),
      CancelEventArgs: defineClass(CancelEventArgs, {}, [], null, [], ns_System),
      StringBuilder: defineClass(StringBuilder, StringBuilder$, [], null, [], ns_System$Text),
      Stack: defineClass(Stack, Stack$, [], null, [], ns_System$Collections),
      Queue: defineClass(Queue, Queue$, [], null, [], ns_System$Collections),
      Observable: defineClass(Observable, Observable$, [], null, [], ns_System$ComponentModel),
      ObservableCollection: defineClass(ObservableCollection, ObservableCollection$, [], null, [IEnumerable], ns_System$Collections),
      Task: defineClass(Task, Task$, [], null, [], ns_System$Threading),
      Guid: defineClass(Guid, Guid$, [], null, [], ns_System),
      Version: defineClass(Version, Version$, [], null, [], ns_System)
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
