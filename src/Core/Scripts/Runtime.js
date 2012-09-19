//! Script# Core Runtime
//! More information at http://scriptsharp.com
//!

"use strict";

(function(global) {
  function _ss() {

  #include "Runtime\Misc.js"
  #include "Runtime\Delegate.js"

  #include "Runtime\Object.js"
  #include "Runtime\Array.js"
  #include "Runtime\String.js"
  #include "Runtime\Console.js"
  #include "Runtime\Error.js"
  #include "Runtime\Date.js"

  #include "Runtime\TypeSystem.js"
  #include "Runtime\EventArgs.js"
  #include "Runtime\Contracts.js"
  #include "Runtime\Enumerator.js"
  #include "Runtime\StringBuilder.js"
  #include "Runtime\Observable.js"
  #include "Runtime\Task.js"
  #include "Runtime\Culture.js"
  #include "Runtime\Parse.js"
  #include "Runtime\Format.js"

    var ss = extend(module('ss', null, {
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
      EventArgs: [ EventArgs, { } ],
      CancelEventArgs: [ CancelEventArgs, { }, EventArgs ],
      StringBuilder: [ StringBuilder, StringBuilder$ ],
      Observable: [ Observable, Observable$ ],
      ObservableCollection: [ ObservableCollection, ObservableCollection$, null, IEnumerable ],
      Task: [ Task, Task$ ],
      Deferred: [ Deferred, Deferred$ ]
    }), {
      version: '0.8',

      isUndefined: isUndefined,
      isNull: isNull,
      isNullOrUndefined: isNullOrUndefined,
      isValue: isValue,

      extend: extend,

      bind: bind,
      bindAdd: bindAdd,
      bindSub: bindSub,
      bindExport: bindExport,

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
      }
    });

    if (!global.define) {
      global.ss = ss;
    }
    return ss;
  }

  global.define ? global.define('ss', [], _ss) : _ss();
})(this);
