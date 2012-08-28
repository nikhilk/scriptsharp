//! Script# Core Runtime
//! More information at http://projects.nikhilk.net/ScriptSharp
//!

(function(global) {
  global.ss = {
    version: '0.7.6.0',

    isUndefined: function(o) {
      return (o === undefined);
    },

    isNull: function(o) {
      return (o === null);
    },

    isNullOrUndefined: function(o) {
      return (o === null) || (o === undefined);
    },

    isValue: function(o) {
      return (o !== null) && (o !== undefined);
    }
  };

#include "Extensions\Object.js"

#include "Extensions\Boolean.js"

#include "Extensions\Number.js"

#include "Extensions\String.js"

#include "Extensions\Array.js"

#include "Extensions\RegExp.js"

#include "Extensions\Date.js"

#include "Extensions\Error.js"

#include "BCL\Debug.js"

#include "TypeSystem\Type.js"

#include "BCL\Delegate.js"

#include "BCL\CultureInfo.js"

#include "BCL\IEnumerator.js"

#include "BCL\IEnumerable.js"

#include "BCL\ArrayEnumerator.js"

#include "BCL\IDisposable.js"

#include "BCL\StringBuilder.js"

#include "BCL\EventArgs.js"

#include "BCL\CancelEventArgs.js"

#include "BCL\Tuple.js"

#include "BCL\Observable.js"

#include "BCL\Task.js"

#include "BCL\App.js"
})(this);
