extend(ss, {
  neutralCulture: {},
  currentCulture: {},
  formatters: {
    Date: function (dt, format, culture) {
      var fnName = 'String';
      switch (format) {
        case 'iso':
          return dt.toISOString();
        case 'id':
          fnName = 'DateString';
          break;
        case 'it':
          fnName = 'TimeString';
          break;
      }
      return culture == ss.neutralCulture ? dt['to' + fnName]() : dt['toLocale' + fnName]();
    }
  }
});
