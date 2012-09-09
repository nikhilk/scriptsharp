// Console

if (!global.console) {
  global.console = {
    log: function() {
    },
    assert: function() {
    }
  }
}

console.fail = function(message) {
  console.assert(false, message);
  if (global.navigator && (global.navigator.userAgent.indexOf('MSIE') > 0)) {
    eval('debugger;');
  }
}

