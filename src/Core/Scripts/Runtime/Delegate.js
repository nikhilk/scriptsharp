// Delegate Functionality

function _bindList(fnList) {
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

function bind(fn, o) {
  if (!o) {
    return fn;
  }

  var name = null;
  fn = typeof fn == 'string' ? o[name = fn] : fn;

  var cache = name ? o.$$b || (o.$$b = {}) : null;
  var binding = cache ? cache[name] : null;

  if (!binding) {
    // Create a function that invokes the specified function, in the
    // context of the specified object.
    binding = function() {
      return fn.apply(o, arguments);
    };

    if (cache) {
      cache[name] = binding;
    }
  }
  return binding;
}

function bindAdd(binding, value) {
  if (!binding) {
    return value;
  }
  if (!value) {
    return binding;
  }

  var fnList = [].concat(binding._fnList || binding, value);
  return _bindList(fnList);
}

function bindSub(binding, value) {
  if (!binding) {
    return null;
  }
  if (!value) {
    return binding;
  }

  var fnList = binding._fnList || [binding];
  var index = fnList.indexOf(value);
  if (index >= 0) {
    if (fnList.length == 1) {
      return null;
    }

    fnList = index ? fnList.slice(0, index).concat(fnList.slice(index + 1)) : fnList.slice(1);
    return _bindList(fnList);
  }
  return binding;
}


function bindExport(fn, multiUse, name, root) {
  // Generate a unique name if one is not specified
  name = name || '__' + (new Date()).valueOf();

  // If unspecified, exported bindings go on the global object
  // (so they are callable using a simple identifier).
  root = root || global;

  var exp = {
    name: name,
    detach: function() {
      root[name] = _nop;
    },
    dispose: function() {
      try { delete root[name]; } catch (e) { root[name] = undefined; }
    }
  };

  // Multi-use bindings are exported directly; for the rest a stub is exported, and the stub
  // first auto-disposes, and then invokes the actual binding.
  root[name] = multiUse ? fn : function() {
    exp.dispose();
    return fn.apply(null, arguments);
  };

  return exp;
}

