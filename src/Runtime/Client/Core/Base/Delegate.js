// Function binding and delegates

// Create a function that invokes the specified function, in the
// context of the specified object.
// Optionally it can be cached on the object, so the same function
// is returned across calls.
function bindObject(fn, o, cacheKey) {
  var cache = cacheKey ? o.$dc || {} : null;

  var d = null;
  if (cache) {
    d = cache[cacheKey];
  }

  if (!d) {
    d = function() {
      return fn.apply(o, arguments);
    };
    if (cache) {
      cache[cacheKey] = d;
      o.$dc = cache;
    }
  }

  return d;
}

function bindName(fn, multiUse, name, root) {
  // Generate a unique name if one is not specified
  name = name || '__' + (new Date()).valueOf();

  // If unspecified, exported delegates go on the global object
  // (so they are callable using a simple identifier).
  root = root || global;

  var binding = {
    name: name,
    dispose: function() {
      try { delete root[name]; } catch (e) { root[name] = undefined; }
    },
    nop: function() {
      root[name] = function() { };
    }
  };

  // Multi-use delegates are exported directly; for the rest a stub is exported, and the stub
  // first deletes, and then invokes the actual delegate.
  root[name] = multiUse ? fn : function() {
    binding.dispose();
    return fn.apply(null, arguments);
  };

  return binding;
}

function _createDelegate(fnList) {
  var d = function() {
    var args = arguments;
    var r = null;
    for (var i = 0, l = fnList.length; i < l; i++) {
      r = args.length ? fnList[i].apply(null, args) : fnList[i].call(null);
    }
    return r;
  };
  d._fnList = fnList;
  return d;
}

function combineDelegates(source, value) {
  if (!source) {
    return value;
  }
  if (!value) {
    return source;
  }

  var fnList = [].concat(source._fnList || source, value);
  return _createDelegate(fnList);
}

function removeDelegate(source, value) {
  if (!source) {
    return null;
  }
  if (!value) {
    return source;
  }

  var fnList = source._fnList || [ source ];
  var index = fnList.indexOf(value);
  if (index >= 0) {
    if (fnList.length == 1) {
      return null;
    }

    fnList = index ? fnList.slice(0, index).concat(fnList.slice(index + 1)) : fnList.slice(1);
    return _createDelegate(fnList);
  }
  return source;
}
