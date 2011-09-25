// IoC, core services, and observability

function IApplication() { }
// getSetting(name)

function IContainer() { }
// getObject(objectType)
// registerObject(objectType, o)
// registerFactory(objectType, factory)

function IEventManager() { }
// publishEvent(eventArgs)
// subscribeEvent(eventArgsType, eventHandler)
// unsubscribeEvent(subscriptionCookie)

function IInitializable() { }
// beginInitialization
// endInitialization

function IObserver() { }
// invalidateObserver

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
  }
  return observers;
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
var Observable$proto = {
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
var ObservableCollection$proto = {
  get_item: function(index) {
    this._observers = _captureObservers(this._observers);
    return this._items[index];
  },
  set_item: function(index, item) {
    this._items[index] = item;
    this._updated();
  },
  get_length: function() {
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
    this._items = index == 0 ? this._items.splice(1) : this._items.splice(0, index).concat(this._items.splice(index + 1));
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
