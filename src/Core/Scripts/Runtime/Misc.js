// Various Helpers/Utilities

function _nop() {
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

