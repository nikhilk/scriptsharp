// Error Extensions

Error.prototype.popStackFrame = function Error$popStackFrame() {
  if (isNullOrUndefined(this.stack) ||
      isNullOrUndefined(this.fileName) ||
      isNullOrUndefined(this.lineNumber)) {
    return;
  }

  var stackFrames = this.stack.split('\n');
  var currentFrame = stackFrames[0];
  var pattern = this.fileName + ':' + this.lineNumber;
  while (!isNullOrUndefined(currentFrame) &&
         currentFrame.indexOf(pattern) === -1) {
    stackFrames.shift();
    currentFrame = stackFrames[0];
  }

  var nextFrame = stackFrames[1];
  if (isNullOrUndefined(nextFrame)) {
    return;
  }

  var nextFrameParts = nextFrame.match(/@(.*):(\d+)$/);
  if (isNullOrUndefined(nextFrameParts)) {
    return;
  }

  stackFrames.shift();
  this.stack = stackFrames.join('\n');
  this.fileName = nextFrameParts[1];
  this.lineNumber = parseInt(nextFrameParts[2], 10);
}

Error.createError = function(message, errorInfo, innerException) {
  var e = new Error(message);
  if (errorInfo) {
    for (var v in errorInfo) {
      e[v] = errorInfo[v];
    }
  }
  if (innerException) {
    e.innerException = innerException;
  }

  e.popStackFrame();
  return e;
}
