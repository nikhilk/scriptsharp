(function() {
  var currentModule = null;
  var logData = '';
  
  function appendLog(logText) {
    logData = logData + logText + '\r\n';

    var logHolder = document.getElementById('qunit-log');
    if (logHolder) {
      logHolder.value = logData;
    }
  }
  
  QUnit.log = function(result, message) {
    if (arguments.length === 1) {
      message = arguments[0];
    }
    appendLog('    ' + message);
  }

  QUnit.done = function(failures, total) {
      appendLog('\r\nCompleted; ' + 'failures = ' + failures + '; total = ' + total);

      var logUrl = '/log/' + ((failures === 0) ? 'success' : 'failure');
      var xhr = new XMLHttpRequest();
      xhr.onreadystatechange = function() {
        if (xhr.readyState == 4) {
          window.open('', '_self', '');
          window.close();
        }
      };
      xhr.open('POST', logUrl, /* async */ false);
      xhr.setRequestHeader('Content-Type', 'text/plain');
      xhr.send(logData);
  }

  QUnit.testStart = function(name) {
    appendLog('  Test Started: ' + name);
  }
  
  QUnit.testDone = function(name, failures, total) {
    appendLog('  Test Done: ' + name + '; failures = ' + failures + '; total = ' + total);
    appendLog('');
  }

  QUnit.moduleStart = function(name, testEnv) {
    currentModule = name;
    appendLog('Module Started: ' + name);
  }

  QUnit.moduleDone = function(name, failures, total) {
    if (name === currentModule) {
      appendLog('Module Done: ' + name + '; failures = ' + failures + '; total = ' + total + '\r\n');
      appendLog('');
      appendLog('');
    }
    currentModule = null;
  }
})();
