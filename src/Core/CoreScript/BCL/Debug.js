///////////////////////////////////////////////////////////////////////////////
// Debug Extensions

ss.Debug = window.Debug || function() {};
ss.Debug.__typeName = 'Debug';

if (!ss.Debug.writeln) {
    ss.Debug.writeln = function#? DEBUG Debug$writeln##(text) {
        if (window.console) {
            if (window.console.debug) {
                window.console.debug(text);
                return;
            }
            else if (window.console.log) {
                window.console.log(text);
                return;
            }
        }
        else if (window.opera &&
            window.opera.postError) {
            window.opera.postError(text);
            return;
        }
    }
}

ss.Debug._fail = function#? DEBUG Debug$_fail##(message) {
    ss.Debug.writeln(message);
    eval('debugger;');
}

ss.Debug.assert = function#? DEBUG Debug$assert##(condition, message) {
    if (!condition) {
        message = 'Assert failed: ' + message;
        if (confirm(message + '\r\n\r\nBreak into debugger?')) {
            ss.Debug._fail(message);
        }
    }
}

ss.Debug.fail = function#? DEBUG Debug$fail##(message) {
    ss.Debug._fail(message);
}
