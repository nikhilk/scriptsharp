// Culture

var neutralCulture = {
  name: '',
  // numberFormat
  nf: {
    nan: 'NaN',           // naNSymbol
    neg: '-',             // negativeSign
    pos: '+',             // positiveSign
    negInf: '-Infinity',  // negativeInfinityText
    posInf: 'Infinity',   // positiveInfinityText
    gw: [3],              // numberGroupSizes
    dd: 2,                // numberDecimalDigits
    ds: '.',              // numberDecimalSeparator
    gs: ',',             // numberGroupSeparator

    per: '%',             // percentSymbol
    perGW: [3],           // percentGroupSizes
    perDD: 2,             // percentDecimalDigits
    perDS: '.',           // percentDecimalSeparator
    perGS: ',',           // percentGroupSeparator
    perPP: '{0} %',       // percentPositivePattern
    perNP: '-{0} %',      // percentNegativePattern

    cur: '$',             // currencySymbol
    curGW: [3],           // currencyGroupSizes
    curDD: 2,             // currencyDecimalDigits
    curDS: '.',           // currencyDecimalSeparator
    curGS: ',',           // currencyGroupSeparator
    curNP: '(${0})',      // currencyNegativePattern
    curPP: '${0}'         // currencyPositivePattern
  },
  // dateFormat
  dtf: {
    am: 'AM',             // amDesignator
    pm: 'PM',             // pmDesignator

    ds: '/',              // dateSeparator
    ts: ':',              // timeSeparator

    gmt: 'ddd, dd MMM yyyy HH:mm:ss \'GMT\'',   // gmtDateTimePattern
    uni: 'yyyy-MM-dd HH:mm:ssZ',                // universalDateTimePattern
    sort: 'yyyy-MM-ddTHH:mm:ss',                // sortableDateTimePattern
    dt: 'dddd, MMMM dd, yyyy h:mm:ss tt',       // dateTimePattern

    ld: 'dddd, MMMM dd, yyyy',                  // longDatePattern
    sd: 'M/d/yyyy',                             // shortDatePattern

    lt: 'h:mm:ss tt',                           // longTimePattern
    st: 'h:mm tt',                              // shortTimePattern

    day0: 0,                                    // firstDayOfWeek
    day: ['Sunday', 'Monday', 'Tuesday',
          'Wednesday', 'Thursday',
          'Friday', 'Saturday'],                // dayNames
    sday: ['Sun', 'Mon', 'Tue', 'Wed',
           'Thu', 'Fri', 'Sat'],                // shortDayNames
    mday: ['Su', 'Mo', 'Tu', 'We',
           'Th', 'Fr', 'Sa'],                   // minimizedDayNames

    mon: ['January', 'February', 'March',
          'April', 'May', 'June', 'July',
          'August', 'September', 'October',
          'November', 'December', ''],          // monthNames
    smon: ['Jan', 'Feb', 'Mar', 'Apr',
           'May', 'Jun', 'Jul', 'Aug',
           'Sep', 'Oct', 'Nov', 'Dec', '']      // shortMonthNames
  }
};

var currentCulture = { name: 'en-us', dtf: neutralCulture.dtf, nf: neutralCulture.nf };

