// Formatting Helpers

function _commaFormatNumber(number, groups, decimal, comma) {
  var decimalPart = null;
  var decimalIndex = number.indexOf(decimal);
  if (decimalIndex > 0) {
    decimalPart = number.substr(decimalIndex);
    number = number.substr(0, decimalIndex);
  }

  var negative = startsWith(number, '-');
  if (negative) {
    number = number.substr(1);
  }

  var groupIndex = 0;
  var groupSize = groups[groupIndex];
  if (number.length < groupSize) {
    return decimalPart ? number + decimalPart : number;
  }

  var index = number.length;
  var s = '';
  var done = false;
  while (!done) {
    var length = groupSize;
    var startIndex = index - length;
    if (startIndex < 0) {
      groupSize += startIndex;
      length += startIndex;
      startIndex = 0;
      done = true;
    }
    if (!length) {
      break;
    }

    var part = number.substr(startIndex, length);
    if (s.length) {
      s = part + comma + s;
    }
    else {
      s = part;
    }
    index -= length;

    if (groupIndex < groups.length - 1) {
      groupIndex++;
      groupSize = groups[groupIndex];
    }
  }

  if (negative) {
    s = '-' + s;
  }
  return decimalPart ? s + decimalPart : s;
}

_formatters['Number'] = function(number, format, culture) {
  var nf = culture.nf;
  var s = '';
  var precision = -1;

  if (format.length > 1) {
    precision = parseInt(format.substr(1));
  }

  var fs = format.charAt(0);
  switch (fs) {
    case 'd': case 'D':
      s = parseInt(Math.abs(number)).toString();
      if (precision != -1) {
        s = padLeft(s, precision, '0');
      }
      if (number < 0) {
        s = '-' + s;
      }
      break;
    case 'x': case 'X':
      s = parseInt(Math.abs(number)).toString(16);
      if (fs == 'X') {
        s = s.toUpperCase();
      }
      if (precision != -1) {
        s = padLeft(s, precision, '0');
      }
      break;
    case 'e': case 'E':
      if (precision == -1) {
        s = number.toExponential();
      }
      else {
        s = number.toExponential(precision);
      }
      if (fs == 'E') {
        s = s.toUpperCase();
      }
      break;
    case 'f': case 'F':
    case 'n': case 'N':
      if (precision == -1) {
        precision = nf.dd;
      }
      s = number.toFixed(precision).toString();
      if (precision && (nf.ds != '.')) {
        var index = s.indexOf('.');
        s = s.substr(0, index) + nf.ds + s.substr(index + 1);
      }
      if ((fs == 'n') || (fs == 'N')) {
        s = _commaFormatNumber(s, nf.gw, nf.ds, nf.gs);
      }
      break;
    case 'c': case 'C':
      if (precision == -1) {
        precision = nf.curDD;
      }
      s = Math.abs(number).toFixed(precision).toString();
      if (precision && (nf.curDS != '.')) {
        var index = s.indexOf('.');
        s = s.substr(0, index) + nf.curDS + s.substr(index + 1);
      }
      s = _commaFormatNumber(s, nf.curGW, nf.curDS, nf.curGS);
      if (number < 0) {
        s = String.format(culture, nf.curNP, s);
      }
      else {
        s = String.format(culture, nf.curPP, s);
      }
      break;
    case 'p': case 'P':
      if (precision == -1) {
        precision = nf.perDD;
      }
      s = (Math.abs(number) * 100.0).toFixed(precision).toString();
      if (precision && (nf.perDS != '.')) {
        var index = s.indexOf('.');
        s = s.substr(0, index) + nf.perDS + s.substr(index + 1);
      }
      s = _commaFormatNumber(s, nf.perGW, nf.perDS, nf.perGS);
      if (number < 0) {
        s = String.format(culture, nf.perNP, s);
      }
      else {
        s = String.format(culture, nf.perPP, s);
      }
      break;
  }

  return s;
}


var _dateFormatRE = /'.*?[^\\]'|dddd|ddd|dd|d|MMMM|MMM|MM|M|yyyy|yy|y|hh|h|HH|H|mm|m|ss|s|tt|t|fff|ff|f|zzz|zz|z/g;

_formatters['Date'] = function(dt, format, culture) {
  if (format == 'iso') {
    return dt.toISOString();
  }
  else if (format.charAt(0) == 'i') {
    var fnName = 'String';
    switch (format) {
      case 'id': fnName = 'DateString'; break;
      case 'it': fnName = 'TimeString'; break;
    }
    return culture == neutralCulture ? dt['to' + fnName]() : dt['toLocale' + fnName]();
  }

  var dtf = culture.dtf;

  if (format.length == 1) {
    switch (format) {
      case 'f': format = dtf.ld + ' ' + dtf.st; break;
      case 'F': format = dtf.dt; break;

      case 'd': format = dtf.sd; break;
      case 'D': format = dtf.ld; break;

      case 't': format = dtf.st; break;
      case 'T': format = dtf.lt; break;

      case 'g': format = dtf.sd + ' ' + dtf.st; break;
      case 'G': format = dtf.sd + ' ' + dtf.lt; break;

      case 'R': case 'r':
        dtf = neutralCulture.dtf;
        format = dtf.gmt;
        break;
      case 'u': format = dtf.uni; break;
      case 'U':
        format = dtf.dt;
        dt = new Date(dt.getUTCFullYear(), dt.getUTCMonth(), dt.getUTCDate(),
                      dt.getUTCHours(), dt.getUTCMinutes(), dt.getUTCSeconds(), dt.getUTCMilliseconds());
        break;

      case 's': format = dtf.sort; break;
    }
  }

  if (format.charAt(0) == '%') {
    format = format.substr(1);
  }

  var sb = new StringBuilder();

  _dateFormatRE.lastIndex = 0;
  while (true) {
    var index = _dateFormatRE.lastIndex;
    var match = _dateFormatRE.exec(format);

    sb.append(format.slice(index, match ? match.index : format.length));
    if (!match) {
      break;
    }

    var fs = match[0];
    var part = fs;
    switch (fs) {
      case 'dddd':
        part = dtf.day[dt.getDay()];
        break;
      case 'ddd':
        part = dtf.sday[dt.getDay()];
        break;
      case 'dd':
        part = padLeft(dt.getDate().toString(), 2, '0');
        break;
      case 'd':
        part = dt.getDate();
        break;
      case 'MMMM':
        part = dtf.mon[dt.getMonth()];
        break;
      case 'MMM':
        part = dtf.smon[dt.getMonth()];
        break;
      case 'MM':
        part = padLeft((dt.getMonth() + 1).toString(), 2, '0');
        break;
      case 'M':
        part = (dt.getMonth() + 1);
        break;
      case 'yyyy':
        part = dt.getFullYear();
        break;
      case 'yy':
        part = padLeft((dt.getFullYear() % 100).toString(), 2, '0');
        break;
      case 'y':
        part = (dt.getFullYear() % 100);
        break;
      case 'h': case 'hh':
        part = dt.getHours() % 12;
        if (!part) {
          part = '12';
        }
        else if (fs == 'hh') {
          part = padLeft(part.toString(), 2, '0');
        }
        break;
      case 'HH':
        part = padLeft(dt.getHours().toString(), 2, '0');
        break;
      case 'H':
        part = dt.getHours();
        break;
      case 'mm':
        part = padLeft(dt.getMinutes().toString(), 2, '0');
        break;
      case 'm':
        part = dt.getMinutes();
        break;
      case 'ss':
        part = padLeft(dt.getSeconds().toString(), 2, '0');
        break;
      case 's':
        part = dt.getSeconds();
        break;
      case 't': case 'tt':
        part = (dt.getHours() < 12) ? dtf.am : dtf.pm;
        if (fs == 't') {
          part = part.charAt(0);
        }
        break;
      case 'fff':
        part = padLeft(dt.getMilliseconds().toString(), 3, '0');
        break;
      case 'ff':
        part = padLeft(dt.getMilliseconds().toString(), 3).substr(0, 2);
        break;
      case 'f':
        part = padLeft(dt.getMilliseconds().toString(), 3).charAt(0);
        break;
      case 'z':
        part = dt.getTimezoneOffset() / 60;
        part = ((part >= 0) ? '-' : '+') + Math.floor(Math.abs(part));
        break;
      case 'zz': case 'zzz':
        part = dt.getTimezoneOffset() / 60;
        part = ((part >= 0) ? '-' : '+') + padLeft(Math.floor(Math.abs(part)).toString(), 2, '0');
        if (fs == 'zzz') {
          part += dtf.ts + padLeft(Math.abs(dt.getTimezoneOffset() % 60).toString(), 2, '0');
        }
        break;
      default:
        if (part.charAt(0) == '\'') {
          part = part.substr(1, part.length - 2).replace(/\\'/g, '\'');
        }
        break;
    }
    sb.append(part);
  }

  return sb.toString();
}

