// Various Helpers/Utilities

function isValue(o) {
  return (o !== null) && (o !== undefined);
}

function extend(o, items) {
  for (var n in items) {
    o[n] = items[n];
  }
  return o;
}

function clearKeys(obj) {
  for (var key in obj) {
    delete obj[key];
  }
}
function keyExists(obj, key) {
  return obj[key] !== undefined;
}
function keys(obj) {
  if (Object.keys) {
    return Object.keys(obj);
  }
  var keys = [];
  for (var key in obj) {
    keys.push(key);
  }
  return keys;
}
function keyCount(obj) {
  return keys(obj).length;
}

function toArray(obj) {
  return obj ? (typeof obj == 'string' ? JSON.parse('(' + obj + ')') : Array.prototype.slice.call(obj)) : null;
}

function parseBoolean(s) {
  return (s.toLowerCase() == 'true');
}

function parseRegExp(s) {
  if (s[0] == '/') {
    var endSlashIndex = s.lastIndexOf('/');
    if (endSlashIndex > 1) {
      var expression = s.substring(1, endSlashIndex);
      var flags = s.substr(endSlashIndex + 1);
      return new RegExp(expression, flags);
    }
  }

  return null;
}

function parseNumber(s) {
  if (!s || !s.length) {
    return 0;
  }
  if ((s.indexOf('.') >= 0) || (s.indexOf('e') >= 0) ||
    s.endsWith('f') || s.endsWith('F')) {
    return parseFloat(s);
  }
  return parseInt(s, 10);
}

function truncate(n) {
  return (n >= 0) ? Math.floor(n) : Math.ceil(n);
}

function now() {
  return new Date();
}

function today() {
  var d = new Date();
  return new Date(d.getFullYear(), d.getMonth(), d.getDate());
}


function _nop() {
}

function Enumerator(obj, keys) {
  var index = -1;
  var length = keys ? keys.length : obj.length;
  var lookup = keys ? function() { return { key: keys[index], value: obj[keys[index]] }; } :
                      function() { return obj[index]; };

  this.current = null;
  this.moveNext = function() {
    index++;
    this.current = lookup();
    return index < length;
  };
  this.reset = function() {
    index = -1;
    this.current = null;
  };
}
var _nopEnumerator = {
  current: null,
  moveNext: function() { return false; },
  reset: _nop
};

function enumerate(o) {
  if (!isValue(o)) {
    return _nopEnumerator;
  }
  if (o.getEnumerator) {
    return o.getEnumerator();
  }
  if (o.length !== undefined) {
    return new Enumerator(o);
  }
  return new Enumerator(o, keys(o));
}

function _popStackFrame(e) {
  if (!isValue(e.stack) ||
      !isValue(e.fileName) ||
      !isValue(e.lineNumber)) {
    return;
  }

  var stackFrames = e.stack.split('\n');
  var currentFrame = stackFrames[0];
  var pattern = e.fileName + ':' + e.lineNumber;
  while (isValue(currentFrame) && currentFrame.indexOf(pattern) === -1) {
    stackFrames.shift();
    currentFrame = stackFrames[0];
  }

  var nextFrame = stackFrames[1];
  if (!isValue(nextFrame)) {
    return;
  }

  var nextFrameParts = nextFrame.match(/@(.*):(\d+)$/);
  if (!isValue(nextFrameParts)) {
    return;
  }

  stackFrames.shift();
  e.stack = stackFrames.join('\n');
  e.fileName = nextFrameParts[1];
  e.lineNumber = parseInt(nextFrameParts[2], 10);
}

function error(message, errorInfo, innerException) {
  var e = new Error(message);
  if (errorInfo) {
    for (var v in errorInfo) {
      e[v] = errorInfo[v];
    }
  }
  if (innerException) {
    e.innerException = innerException;
  }

  _popStackFrame(e);
  return e;
}

function fail(message) {
  console.assert(false, message);
  if (global.navigator && (global.navigator.userAgent.indexOf('MSIE') > 0)) {
    eval('debugger;');
  }
}

