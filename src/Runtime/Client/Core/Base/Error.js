// Error helpers

function _popStackFrame(e) {
  if ((e.stack == null) || (e.fileName == null) || (e.lineNumber == null)) {
    return;
  }

  var stackFrames = e.stack.split('\n');
  var currentFrame = stackFrames[0];
  var pattern = e.fileName + ':' + e.lineNumber;
  while (isValue(currentFrame) && (currentFrame.indexOf(pattern) === -1)) {
    stackFrames.shift();
    currentFrame = stackFrames[0];
  }

  var nextFrame = stackFrames[1];
  if (nextFrame == null) {
      return;
  }

  var nextFrameParts = nextFrame.match(/@(.*):(\d+)$/);
  if (nextFrameParts == null) {
      return;
  }

  stackFrames.shift();
  e.stack = stackFrames.join("\n");
  e.fileName = nextFrameParts[1];
  e.lineNumber = parseInt(nextFrameParts[2], 10);
}

function createError(message, errorInfo, innerError) {
  var e = new Error(message);
  if (errorInfo) {
    for (var v in errorInfo) {
      e[v] = errorInfo[v];
    }
  }
  if (innerError) {
    e.innerError = innerError;
  }

  _popStackFrame(e);
  return e;
}
