///////////////////////////////////////////////////////////////////////////////
// Observable

ss.Observable = function(v) {
    this._v = v;
    this._observers = null;
}
ss.Observable.prototype = {

  getValue: function () {
    this._observers = ss.Observable._captureObservers(this._observers);
    return this._v;
  },
  setValue: function (v) {
    if (this._v !== v) {
      this._v = v;

      var observers = this._observers;
      if (observers) {
        this._observers = null;
        ss.Observable._invalidateObservers(observers);
      }
    }
  }
};

ss.Observable._observerStack = [];
ss.Observable._observerRegistration = {
  dispose: function () {
    ss.Observable._observerStack.pop();
  }
}
ss.Observable.registerObserver = function (o) {
  ss.Observable._observerStack.push(o);
  return ss.Observable._observerRegistration;
}
ss.Observable._captureObservers = function (observers) {
  var registeredObservers = ss.Observable._observerStack;
  var observerCount = registeredObservers.length;

  if (observerCount) {
    observers = observers || [];
    for (var i = 0; i < observerCount; i++) {
      var observer = registeredObservers[i];
      if (!observers.contains(observer)) {
        observers.push(observer);
      }
    }
    return observers;
  }
  return null;
}
ss.Observable._invalidateObservers = function (observers) {
  for (var i = 0, len = observers.length; i < len; i++) {
    observers[i].invalidateObserver();
  }
}

ss.Observable.registerClass('Observable');


ss.ObservableCollection = function (items) {
  this._items = items || [];
  this._observers = null;
}
ss.ObservableCollection.prototype = {

  get_item: function (index) {
    this._observers = ss.Observable._captureObservers(this._observers);
    return this._items[index];
  },
  set_item: function (index, item) {
    this._items[index] = item;
    this._updated();
  },
  get_length: function () {
    this._observers = ss.Observable._captureObservers(this._observers);
    return this._items.length;
  },
  add: function (item) {
    this._items.push(item);
    this._updated();
  },
  clear: function () {
    this._items.clear();
    this._updated();
  },
  contains: function (item) {
    return this._items.contains(item);
  },
  getEnumerator: function () {
    this._observers = ss.Observable._captureObservers(this._observers);
    return this._items.getEnumerator();
  },
  indexOf: function (item) {
    return this._items.indexOf(item);
  },
  insert: function (index, item) {
    this._items.insert(index, item);
    this._updated();
  },
  remove: function (item) {
    if (this._items.remove(item)) {
      this._updated();
      return true;
    }
    return false;
  },
  removeAt: function (index) {
    this._items.removeAt(index);
    this._updated();
  },
  toArray: function () {
    return this._items;
  },
  _updated: function() {
    var observers = this._observers;
    if (observers) {
      this._observers = null;
      ss.Observable._invalidateObservers(observers);
    }
  }
}
ss.ObservableCollection.registerClass('ObservableCollection', null, ss.IEnumerable);
