// Debug Helpers

function debugAssert(condition, msg, debug) {
  if (console && console.assert) {
    console.assert(condition, msg);
  }
  else if (!condition) {
    debugWrite('Assert failed: ' + msg);
  }
  if (debug || confirm('Assert failed:\r\n' + msg + '\r\nBreak into debugger?')) {
    eval('debugger;');
  }
}

function debugFail(msg) {
  debugAssert(false, msg, true);
}

function debugWriteLine(msg) {
  if (console) {
    console.log(text);
  }
  else if (Debug) {
    Debug.writeln(msg);
  }
}
