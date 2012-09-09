//! Script# Core Runtime
//! More information at http://scriptsharp.com
//!

define('ss', [], function() {
"use strict";

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

#include "Runtime\Console.js"
#include "Runtime\TypeSystem.js"

var ss = module('ss');
return extend(ss, {
  version: '0.7.6.0',

  isUndefined: isUndefined,
  isNull: isNull,
  isNullOrUndefined: isNullOrUndefined,
  isValue: isValue,

  module: module
});

});
