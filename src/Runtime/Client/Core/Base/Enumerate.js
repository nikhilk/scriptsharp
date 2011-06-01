// Enumeration (of enumerables, arrays and objects)

function enumerate(o, cb) {
  var cancel = false;
  if (isOfType(o, IEnumerable)) {
    var enumerator = o.getEnumerator();
    while (enumerator.moveNext()) {
      cancel = cb(enumerator.get_current());
      if (cancel) {
        break;
      }
    }
  }
  else if (o.forEach) {
    o.forEach(function(item) {
      if (!cancel) {
        cancel = cb(item);
      }
    });
  }
  else if (o.length !== undefined) {
    for (var l = o.length, i = 0; i < l; i++) {
      cancel = cb(o[i]);
      if (cancel) {
        break;
      }
    }
  }
  else {
    for (var n in o) {
      cancel = cb({ key: n, value: o[n] });
      if (cancel) {
        break;
      }
    }
  }
}
