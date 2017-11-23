// Observable

var _observerStack = [];
var _observerRegistration = {
  dispose: function() {
    _observerStack.pop();
  }
}
function _captureObservers(observers) {
  var registeredObservers = _observerStack;
  var observerCount = registeredObservers.length;

  if (observerCount) {
    observers = observers || [];
    for (var i = 0; i < observerCount; i++) {
      var observer = registeredObservers[i];
      if (observers.indexOf(observer) < 0) {
        observers.push(observer);
      }
    }
    return observers;
  }
  return null;
}
function _invalidateObservers(observers) {
  for (var i = 0, len = observers.length; i < len; i++) {
    observers[i].invalidateObserver();
  }
}

function Observable(v) {
  this._v = v;
  this._observers = null;
}
var Observable$ = {

  getValue: function() {
    this._observers = _captureObservers(this._observers);
    return this._v;
  },
  setValue: function(v) {
    if (this._v !== v) {
      this._v = v;

      var observers = this._observers;
      if (observers) {
        this._observers = null;
        _invalidateObservers(observers);
      }
    }
  }
};
Observable.registerObserver = function(o) {
  _observerStack.push(o);
  return _observerRegistration;
}


function ObservableCollection(items) {
  this._items = items || [];
  this._observers = null;
}
var ObservableCollection$ = {

  get_item: function (index) {
    this._observers = _captureObservers(this._observers);
    return this._items[index];
  },
  set_item: function(index, item) {
    this._items[index] = item;
    this._updated();
  },
  $get_length: function() {
    this._observers = _captureObservers(this._observers);
    return this._items.length;
  },
  add: function(item) {
    this._items.push(item);
    this._updated();
  },
  clear: function() {
    this._items.clear();
    this._updated();
  },
  contains: function(item) {
    return this._items.indexOf(item) >= 0;
  },
  getEnumerator: function() {
    this._observers = _captureObservers(this._observers);
    // TODO: Change this
    return this._items.getEnumerator();
  },
  indexOf: function(item) {
    return this._items.indexOf(item);
  },
  insert: function(index, item) {
    this._items.insert(index, item);
    this._updated();
  },
  remove: function(item) {
    if (this._items.remove(item)) {
      this._updated();
      return true;
    }
    return false;
  },
  removeAt: function(index) {
    this._items.splice(index, 1);
    this._updated();
  },
  toArray: function() {
    return this._items;
  },
  _updated: function() {
    var observers = this._observers;
    if (observers) {
      this._observers = null;
      _invalidateObservers(observers);
    }
  }
}

