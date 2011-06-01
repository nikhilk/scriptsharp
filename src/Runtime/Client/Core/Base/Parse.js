// Parsing utilities

function parseNumber(s) {
  if (!s || !s.length) {
    return 0;
  }
  if ((s.indexOf('.') >= 0) || (s.indexOf('e') >= 0) ||
    (s.substr(-1).toLowerCase() == 'f')) {
    return parseFloat(s);
  }
  return parseInt(s, 10);
}

function parseBoolean(s) {
  return (s.toLowerCase() == 'true');
}

function parseDate(s) {
  // Date.parse returns the number of milliseconds
  // so we use that to create an actual Date instance
  return new Date(Date.parse(s));
}

function parseRegExp(s) {
  if (s.indexOf('/') == 0) {
    var endSlashIndex = s.lastIndexOf('/');
    if (endSlashIndex > 1) {
      var expression = s.substring(1, endSlashIndex);
      var flags = s.substr(endSlashIndex + 1);
      return new RegExp(expression, flags);
    }
  }

  return null;    
}
