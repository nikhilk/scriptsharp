// String Extensions

var _formatPlaceHolderRE = /(\{[^\}^\{]+\})/g;
var _formatters = {
};

function stringFromChar(ch, count) {
  return count ? new Array(count + 1).join(ch) : ch;
}

extend(String, {
  fromChar: stringFromChar,
  concat: function() {
    return Array.prototype.join.call(arguments, '');
  },
  compare: function(s1, s2, ignoreCase) {
    s1 = s1 || '';
    s2 = s2 || '';

    if (ignoreCase) {
      s1 = s1.toUpperCase();
      s2 = s2.toUpperCase();
    }

    return (s1 == s2) ? 0 : (s1 < s2) ? -1 : 1;
  },
  equals: function(s1, s2, ignoreCase) {
    return String.compare(s1, s2, ignoreCase) == 0;
  },
  format: function(cultureOrFormat) {
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

        var formatter = _formatters[value.constructor.name];
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
  },
  isNullOrEmpty: function(s) {
    return !s || !s.length;
  },
  isNullOrWhiteSpace: function(s) {
    return String.isNullOrEmpty(s) || s.trim() === "";
  }
});

extend(String.prototype, {
  compareTo: function(s, ignoreCase) {
    return String.Compare(this, s, ignoreCase);
  },
  endsWith: function(suffix) {
    if (!suffix.length) {
      return true;
    }
    if (suffix.length > this.length) {
      return false;
    }
    return this.substr(-suffix.length) == suffix;
  },
  indexOfAny: function(chars, startIndex, count) {
    var length = this.length;
    if (!length) {
      return -1;
    }

    startIndex = startIndex || 0;
    count = count || length;

    var endIndex = startIndex + count - 1;
    if (endIndex >= length) {
      endIndex = length - 1;
    }

    for (var i = startIndex; i <= endIndex; i++) {
      if (chars.indexOf(this.charAt(i)) >= 0) {
        return i;
      }
    }
    return -1;
  },
  insert: function(index, value) {
    if (!value) {
      return this.valueOf();
    }
    if (!index) {
      return value + this;
    }
    var s1 = this.substr(0, index);
    var s2 = this.substr(index);
    return s1 + value + s2;
  },
  lastIndexOfAny: function(chars, startIndex, count) {
    var length = this.length;
    if (!length) {
      return -1;
    }

    startIndex = startIndex || length - 1;
    count = count || length;

    var endIndex = startIndex - count + 1;
    if (endIndex < 0) {
      endIndex = 0;
    }

    for (var i = startIndex; i >= endIndex; i--) {
      if (chars.indexOf(this.charAt(i)) >= 0) {
        return i;
      }
    }
    return -1;
  },
  padLeft: function(totalWidth, ch) {
    return (this.length < totalWidth) ? stringFromChar(ch || ' ', totalWidth - this.length) + this : this.valueOf();
  },
  padRight: function(totalWidth, ch) {
    return (this.length < totalWidth) ? this + stringFromChar(ch || ' ', totalWidth - this.length) : this.valueOf();
  },
  remove: function(index, count) {
    if (!count || ((index + count) > this.length)) {
      return this.substr(0, index);
    }
    return this.substr(0, index) + this.substr(index + count);
  },
  replaceAll: function(oldValue, newValue) {
    newValue = newValue || '';
    return this.split(oldValue).join(newValue);
  },
  startsWith: function(prefix) {
    if (!prefix.length) {
      return true;
    }
    if (prefix.length > this.length) {
      return false;
    }
    return this.substr(0, prefix.length) == prefix;
  },
  trimEnd: function() {
    return this.replace(/\s*$/, '');
  },
  trimStart: function() {
    return this.replace(/^\s*/, '');
  }
});

if (!String.prototype.trim) {
  String.prototype.trim = function() {
    return this.trimEnd().trimStart();
  }
}

