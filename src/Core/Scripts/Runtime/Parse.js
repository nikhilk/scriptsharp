// Parsing Helpers

Number.parse = function(s) {
  if (!s || !s.length) {
    return 0;
  }
  if ((s.indexOf('.') >= 0) || (s.indexOf('e') >= 0) ||
    s.endsWith('f') || s.endsWith('F')) {
    return parseFloat(s);
  }
  return parseInt(s, 10);
}

Boolean.parse = function(s) {
  return (s.toLowerCase() == 'true');
}

RegExp.parse = function(s) {
  if (s[0] == '/') {
    var endSlashIndex = s.lastIndexOf('/');
    if (endSlashIndex > 1) {
      var expression = s.substring(1, endSlashIndex);
      var flags = s.substr(endSlashIndex + 1);
      return new RegExp(expression, flags);
    }
  }

  return null;
}

Array.parse = function(s) {
  return eval('(' + s + ')');
}

