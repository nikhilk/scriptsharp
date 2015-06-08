// String

function string(arg1, arg2) {
  if (typeof arg2 == 'number') {
    return arg2 > 1 ? new Array(arg2 + 1).join(arg1) : arg1;
  }
  return Array.prototype.join.call(arguments, '');
}

function emptyString(s) {
  return !s || !s.length;
}

function whitespace(s) {
  return emptyString(s) || !s.replace(/^\s*/, '').length;
}

function compareStrings(s1, s2, ignoreCase) {
  s1 = s1 || '', s2 = s2 || '';
  ignoreCase ? (s1 = s1.toUpperCase(), s2 = s2.toUpperCase()) : 0;
  return (s1 === s2) ? 0 : (s1 < s2) ? -1 : 1;
}

var _formatPlaceHolderRE = /(\{[^\}^\{]+\})/g;
var _formatters = {};

function format(cultureOrFormat) {
  var culture = neutralCulture;
  var format = cultureOrFormat;
  var values = Array.prototype.slice.call(arguments, 1);

  if (cultureOrFormat.constructor != String) {
    culture = cultureOrFormat;
    format = values[0];
    values = values.slice(1);
  }

  return format.replace(_formatPlaceHolderRE,
    function(str, match) {
      var index = parseInt(match.substr(1), 10);
      var value = values[index];
      if (!isValue(value)) {
        return '';
      }

      var formatter = _formatters[typeName(value)];
      if (formatter) {
        var formatSpec = '';
        var formatIndex = match.indexOf(':');
        if (formatIndex > 0) {
          formatSpec = match.substring(formatIndex + 1, match.length - 1);
        }
        if (formatSpec && (formatSpec != 'i')) {
          return formatter(value, formatSpec, culture);
        }
      }
      return culture == neutralCulture ? value.toString() : value.toLocaleString();
    });
}

function trim(s, tc) {
  if (tc || !String.prototype.trim) {
    tc = tc ? tc.join('') : null;
    var r = tc ? new RegExp('^[' + tc + ']+|[' + tc + ']+$', 'g') : /^\s+|\s+$/g;
    return s.replace(r, '');
  }
  return s.trim();
}
function trimStart(s, tc) {
  var r = tc ? new RegExp('^[' + tc.join('') + ']+') : /^\s+/;
  return s.replace(r, '');
}
function trimEnd(s, tc) {
  var r = tc ? new RegExp('[' + tc.join('') + ']+$') : /\s+$/;
  return s.replace(r, '');
}
function startsWith(s, prefix) {
  if (emptyString(prefix)) {
    return true;
  }
  if (emptyString(s) || (prefix.length > s.length)) {
    return false;
  }
  return s.substr(0, prefix.length) == prefix;
}
function endsWith(s, suffix) {
  if (emptyString(suffix)) {
    return true;
  }
  if (emptyString(s) || (suffix.length > s.length)) {
    return false;
  }
  return s.substr(-suffix.length) == suffix;
}
function padLeft(s, totalWidth, ch) {
  return (s.length < totalWidth) ? string(ch || ' ', totalWidth - s.length) + s : s;
}
function padRight(s, totalWidth, ch) {
  return (s.length < totalWidth) ? s + string(ch || ' ', totalWidth - s.length) : s;
}
function removeString(s, index, count) {
  if (!count || ((index + count) > s.length)) {
    return s.substr(0, index);
  }
  return s.substr(0, index) + s.substr(index + count);
}
function insertString(s, index, value) {
  if (!value) {
    return s;
  }
  if (!index) {
    return value + s;
  }
  return s.substr(0, index) + value + s.substr(index);
}
function replaceString(s, oldValue, newValue) {
  return s.split(oldValue).join(newValue || '');
}

