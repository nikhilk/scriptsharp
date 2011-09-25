// String utilities

var _formatPlaceHolder = /(\{[^\}^\{]+\})/g;

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
  format: function(cultureOrFormat) {
    var culture = ss.neutralCulture;
    var format = cultureOrFormat;
    var values = Array.prototype.slice.call(arguments, 1);

    if (cultureOrFormat.constructor != String) {
      culture = cultureOrFormat;
      format = values[0];
      values = values.slice(1);
    }

    return format.replace(_formatPlaceHolder,
      function(str, match) {
        var index = parseInt(match.substr(1));
        var value = values[index];
        if (!isValue(value)) {
          return '';
        }

        var formatter = ss.formatters[value.constructor.name];
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
        return culture == ss.neutralCulture ? value.toString() : value.toLocaleString();
      });
  }
});

extend(String.prototype, {
  endsWith: function(suffix) {
    if (!suffix.length) {
      return true;
    }
    if (suffix.length > this.length) {
      return false;
    }
    return this.substr(-suffix.length) == suffix;
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
  padLeft: function(totalWidth, ch) {
    return (this.length < totalWidth) ? stringFromChar(ch || ' ', totalWidth - this.length) + this : this;
  },
  padRight: function(totalWidth, ch) {
    return (this.length < totalWidth) ? this + stringFromChar(ch || ' ', totalWidth - this.length) : this;
  },
  trimEnd: function() {
    return this.replace(/\s*$/, '');
  },
  trimStart: function() {
    return this.replace(/^\s*/, '');
  },
  insert: function(index, value) {
    if (!value) {
      return this;
    }
    if (!index) {
      return value + this;
    }
    return this.substr(0, index) + value + this.substr(index);
  },
  remove: function(index, count) {
    if (!count || ((index + count) > this.length)) {
      return this.substr(0, index);
    }
    return this.substr(0, index) + this.substr(index + count);
  },
  replaceAll: function(oldValue, newValue) {
    return this.split(oldValue).join(newValue || '');
  }
});

if (!String.prototype.trim) {
  String.prototype.trim = function() {
    return this.trimEnd().trimStart();
  }
}
