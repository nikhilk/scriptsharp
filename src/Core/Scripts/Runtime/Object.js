// Object Extensions

Object.clearKeys = function(d) {
  for (var n in d) {
    delete d[n];
  }
}

Object.keyExists = function(d, key) {
  return d[key] !== undefined;
}

if (!Object.keys) {
  Object.keys = function(d) {
    var keys = [];
    for (var n in d) {
      keys.push(n);
    }
    return keys;
  }

  Object.getKeyCount = function(d) {
    var count = 0;
    for (var n in d) {
      count++;
    }
    return count;
  }
}
else {
  Object.getKeyCount = function(d) {
    return Object.keys(d).length;
  }
}

