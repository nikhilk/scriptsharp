// Startup Handling

var _startCallbacks = [];

function onStartup(cb) {
  // If startCallbacks is non-null, then startup callbacks haven't been invoked
  // yet, so just add this callback into the list.
  // Otherwise, invoke the callback directly.
  _startCallbacks ? _startCallbacks.push(cb) : setTimeout(cb, 0);
}
function _startup() {
  if (_startCallbacks) {
    var callbacks = _startCallbacks;
    _startCallbacks = null;
    for (var i = 0, l = callbacks.length; i < l; i++) {
      callbacks[i]();
    }
  }
}

// If the document is already loaded, invoke the startup callbacks,
// otherwise register for DOMContentLoaded (if addEventListener exists),
// or window.onload as a fallback.
document.readyState == 'complete' ? startup() :
  document.addEventListener ? document.addEventListener('DOMContentLoaded', _startup, false) :
                              window.attachEvent('onload', _startup);
