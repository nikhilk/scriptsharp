// Delegate

function _delegateContains(targets, object, method) {
  for (var i = 0; i < targets.length; i += 2) {
    if (targets[i] === object && targets[i + 1] === method) {
      return true;
    }
  }
  return false;
}

function _createDelegate(targets) {
  var delegate = function() {
    if (targets.length == 2) {
      return targets[1].apply(targets[0], arguments);
    }
    else {
      var clone = targets.clone();
      for (var i = 0; i < clone.length; i += 2) {
        if (_delegateContains(targets, clone[i], clone[i + 1])) {
          clone[i + 1].apply(clone[i], arguments);
        }
      }
      return null;
    }
  };
  delegate._targets = targets;

  return delegate;
}

function Delegate() {
}

Delegate.create = function(object, method) {
  if (!object) {
      return method;
  }
  return _createDelegate([object, method]);
}

Delegate.combine = function(delegate1, delegate2) {
  if (!delegate1) {
    if (!delegate2._targets) {
      return Delegate.create(null, delegate2);
    }
    return delegate2;
  }
  if (!delegate2) {
    if (!delegate1._targets) {
      return sDelegate.create(null, delegate1);
    }
    return delegate1;
  }

  var targets1 = delegate1._targets ? delegate1._targets : [null, delegate1];
  var targets2 = delegate2._targets ? delegate2._targets : [null, delegate2];

  return _createDelegate(targets1.concat(targets2));
}

Delegate.remove = function(delegate1, delegate2) {
  if (!delegate1 || (delegate1 === delegate2)) {
    return null;
  }
  if (!delegate2) {
    return delegate1;
  }

  var targets = delegate1._targets;
  var object = null;
  var method;
  if (delegate2._targets) {
    object = delegate2._targets[0];
    method = delegate2._targets[1];
  }
  else {
    method = delegate2;
  }

  for (var i = 0; i < targets.length; i += 2) {
    if ((targets[i] === object) && (targets[i + 1] === method)) {
      if (targets.length == 2) {
        return null;
      }
      targets.splice(i, 2);
      return _createDelegate(targets);
    }
  }

  return delegate1;
}

Delegate.createExport = function(delegate, multiUse, name) {
  // Generate a unique name if one is not specified
  name = name || '__' + (new Date()).valueOf();

  // Exported delegates go on global object (so they are callable using a simple identifier).

  // Multi-use delegates are exported directly; for the rest a stub is exported, and the stub
  // first deletes, and then invokes the actual delegate.
  global[name] = multiUse ? delegate : function() {
    try { delete global[name]; } catch(e) { global[name] = undefined; }
    delegate.apply(null, arguments);
  };

  return name;
}

Delegate.deleteExport = function(name) {
  delete global[name];
}

Delegate.clearExport = function(name) {
  global[name] = Delegate.empty;
}
