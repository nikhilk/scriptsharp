///////////////////////////////////////////////////////////////////////////////
// Debug Extensions

if (!console) {
  global.console = {
    log: function() {
    },
    assert: function() {
    }
  }
}

global.console.fail = function(message) {
  console.assert(false, message);
  if (global.navigator && (global.navigator.userAgent.indexOf('MSIE') > 0)) {
    eval('debugger;');
  }
}
