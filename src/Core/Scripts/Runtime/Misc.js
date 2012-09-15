// Various Helpers/Utilities

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

Math.truncate = function(n) {
  return (n >= 0) ? Math.floor(n) : Math.ceil(n);
}

function _nop() {
}

