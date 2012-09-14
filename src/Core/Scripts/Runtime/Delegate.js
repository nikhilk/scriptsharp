// Delegate

function _createDelegate(fnList) {
  var d = function() {
    var args = arguments;
    var result = null;
    for (var i = 0, l = fnList.length; i < l; i++) {
      result = args.length ? fnList[i].apply(null, args) : fnList[i].call(null);
    }
    return result;
  };
  d._fnList = fnList;
  return d;
}

function Delegate() {
}

Delegate.create = function(o, fn) {
  if (!o) {
    return fn;
  }

  // Create a function that invokes the specified function, in the
  // context of the specified object.
  return function() {
    return fn.apply(o, arguments);
  };
}

Delegate.combine = function(delegate, value) {
  if (!delegate) {
    return value;
  }
  if (!value) {
    return delegate;
  }

  var fnList = [].concat(delegate._fnList || delegate, value);
  return _createDelegate(fnList);
}

Delegate.remove = function(delegate, value) {
  if (!delegate) {
    return null;
  }
  if (!value) {
    return delegate;
  }

  var fnList = delegate._fnList || [delegate];
  var index = fnList.indexOf(value);
  if (index >= 0) {
    if (fnList.length == 1) {
      return null;
    }

    fnList = index ? fnList.slice(0, index).concat(fnList.slice(index + 1)) : fnList.slice(1);
    return _createDelegate(fnList);
  }
  return delegate;
}

Delegate.publish = function(fn, multiUse, name, root) {
  // Generate a unique name if one is not specified
  name = name || '__' + (new Date()).valueOf();

  // If unspecified, exported delegates go on the global object
  // (so they are callable using a simple identifier).
  root = root || global;

  var exp = {
    name: name,
    clear: function() {
      root[name] = Delegate.Empty;
    },
    dispose: function() {
      try { delete root[name]; } catch (e) { root[name] = undefined; }
    }
  };

  // Multi-use delegates are exported directly; for the rest a stub is exported, and the stub
  // first deletes, and then invokes the actual delegate.
  root[name] = multiUse ? fn : function() {
    exp.dispose();
    return fn.apply(null, arguments);
  };

  return exp;
}
