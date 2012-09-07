///////////////////////////////////////////////////////////////////////////////
// String Extensions

String.__typeName = 'String';
String.Empty = '';

String.compare = function#? DEBUG String$compare##(s1, s2, ignoreCase) {
    if (ignoreCase) {
        if (s1) {
            s1 = s1.toUpperCase();
        }
        if (s2) {
            s2 = s2.toUpperCase();
        }
    }
    s1 = s1 || '';
    s2 = s2 || '';

    if (s1 == s2) {
        return 0;
    }
    if (s1 < s2) {
        return -1;
    }
    return 1;
}

String.prototype.compareTo = function#? DEBUG String$compareTo##(s, ignoreCase) {
    return String.compare(this, s, ignoreCase);
}

String.concat = function#? DEBUG String$concat##() {
    if (arguments.length === 2) {
        return arguments[0] + arguments[1];
    }
    return Array.prototype.join.call(arguments, '');
}

String.prototype.endsWith = function#? DEBUG String$endsWith##(suffix) {
    if (!suffix.length) {
        return true;
    }
    if (suffix.length > this.length) {
        return false;
    }
    return (this.substr(this.length - suffix.length) == suffix);
}

String.equals = function#? DEBUG String$equals1##(s1, s2, ignoreCase) {
    return String.compare(s1, s2, ignoreCase) == 0;
}

String._format = function#? DEBUG String$_format##(format, values, useLocale) {
    if (!String._formatRE) {
        String._formatRE = /(\{[^\}^\{]+\})/g;
    }

    return format.replace(String._formatRE,
                          function(str, m) {
                              var index = parseInt(m.substr(1));
                              var value = values[index + 1];
                              if (ss.isNullOrUndefined(value)) {
                                  return '';
                              }
                              if (value.format) {
                                  var formatSpec = null;
                                  var formatIndex = m.indexOf(':');
                                  if (formatIndex > 0) {
                                      formatSpec = m.substring(formatIndex + 1, m.length - 1);
                                  }
                                  return useLocale ? value.localeFormat(formatSpec) : value.format(formatSpec);
                              }
                              else {
                                  return useLocale ? value.toLocaleString() : value.toString();
                              }
                          });
}

String.format = function#? DEBUG String$format##(format) {
    return String._format(format, arguments, /* useLocale */ false);
}

String.fromChar = function#? DEBUG String$fromChar##(ch, count) {
    var s = ch;
    for (var i = 1; i < count; i++) {
        s += ch;
    }
    return s;
}

String.prototype.htmlDecode = function#? DEBUG String$htmlDecode##() {
    var div = document.createElement('div');
    div.innerHTML = this;
    return div.textContent || div.innerText;
}

String.prototype.htmlEncode = function#? DEBUG String$htmlEncode##() {
    var div = document.createElement('div');
    div.appendChild(document.createTextNode(this));
    return div.innerHTML.replace(/\"/g, '&quot;');
}

String.prototype.indexOfAny = function#? DEBUG String$indexOfAny##(chars, startIndex, count) {
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
}

String.prototype.insert = function#? DEBUG String$insert##(index, value) {
    if (!value) {
        return this.valueOf();
    }
    if (!index) {
        return value + this;
    }
    var s1 = this.substr(0, index);
    var s2 = this.substr(index);
    return s1 + value + s2;
}

String.isNullOrEmpty = function#? DEBUG String$isNullOrEmpty##(s) {
    return !s || !s.length;
}

String.isNullOrWhiteSpace = function#? DEBUG String$isNullOrWhiteSpace##(s) {
    return String.isNullOrEmpty(s) || s.trim() === "";
}

String.prototype.lastIndexOfAny = function#? DEBUG String$lastIndexOfAny##(chars, startIndex, count) {
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
}

String.localeFormat = function#? DEBUG String$localeFormat##(format) {
    return String._format(format, arguments, /* useLocale */ true);
}

String.prototype.padLeft = function#? DEBUG String$padLeft##(totalWidth, ch) {
    if (this.length < totalWidth) {
        ch = ch || ' ';
        return String.fromChar(ch, totalWidth - this.length) + this;
    }
    return this.valueOf();
}

String.prototype.padRight = function#? DEBUG String$padRight##(totalWidth, ch) {
    if (this.length < totalWidth) {
        ch = ch || ' ';
        return this + String.fromChar(ch, totalWidth - this.length);
    }
    return this.valueOf();
}

String.prototype.remove = function#? DEBUG String$remove##(index, count) {
    if (!count || ((index + count) > this.length)) {
        return this.substr(0, index);
    }
    return this.substr(0, index) + this.substr(index + count);
}

String.prototype.replaceAll = function#? DEBUG String$replaceAll##(oldValue, newValue) {
    newValue = newValue || '';
    return this.split(oldValue).join(newValue);
}

String.prototype.startsWith = function#? DEBUG String$startsWith##(prefix) {
    if (!prefix.length) {
        return true;
    }
    if (prefix.length > this.length) {
        return false;
    }
    return (this.substr(0, prefix.length) == prefix);
}

if (!String.prototype.trim) {
    String.prototype.trim = function#? DEBUG String$trim##() {
        return this.trimEnd().trimStart();
    }
}

String.prototype.trimEnd = function#? DEBUG String$trimEnd##() {
    return this.replace(/\s*$/, '');
}

String.prototype.trimStart = function#? DEBUG String$trimStart##() {
    return this.replace(/^\s*/, '');
}
