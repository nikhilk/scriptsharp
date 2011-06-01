// Number Formatting Functionality

function _commaFormatNumber(number, groups, decimal, comma) {
  var decimalPart = null;
  var decimalIndex = number.indexOf(decimal);
  if (decimalIndex > 0) {
    decimalPart = number.substr(decimalIndex);
    number = number.substr(0, decimalIndex);
  }

  var negative = number.startsWith('-');
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

ss.formatters.Number = function(number, format, culture) {
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
        s = s.padLeft(precision, '0');
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
        s = s.padLeft(precision, '0');
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
