function DateTime(year, month, day, hour, minute, second, millisecond)
{
    var constructorArgs = [];
    if (year != null) constructorArgs.push(year);
    if (month != null) constructorArgs.push(month - 1);
    if (day != null) constructorArgs.push(day);
    if (hour != null) constructorArgs.push(hour);
    if (minute != null) constructorArgs.push(minute);
    if (second != null) constructorArgs.push(second);
    if (millisecond != null) constructorArgs.push(millisecond);

    return new (Function.prototype.bind.apply(
        Date, [null].concat(constructorArgs)
    ));
}

createPropertyGet(DateTime, 'Now', function()
{
    return new Date();
});

createPropertyGet(DateTime, 'Today', function()
{
    var today = DateTime.Now;
    today.setHours(0, 0, 0, 0);

    return today;
});

DateTime.Equals = function (d1, d2)
{
    var parsedDate1 = DateTime._parseIfString(d1);
    var parsedDate2 = DateTime._parseIfString(d2);

    if (parsedDate1 == null || parsedDate2 == null)
    {
        return compareDates(parsedDate1, parsedDate2);
    }

    return parsedDate1.getTime() === parsedDate2.getTime();
};

DateTime.CompareTo = function (d1, d2)
{
    var parsedDate1 = DateTime._parseIfString(d1);
    var parsedDate2 = DateTime._parseIfString(d2);

    if (parsedDate1 == null || parsedDate2 == null)
    {
        throw new Error("Cannot compare null Dates");
    }

    var d1t = parsedDate1.getTime();
    var d2t = parsedDate2.getTime();

    return d1t === d2t
        ? 0
        : d1t < d2t
            ? -1
            : 1;
};

createPropertyGet(Date.prototype, 'Year', function ()
{
    return DateTime.GetYear(this);
});

DateTime.GetYear = function (date)
{
    date = DateTime._parseIfString(date);

    return date.getFullYear();
};

createPropertyGet(Date.prototype, 'Month', function ()
{
    return DateTime.GetMonth(this);
});

DateTime.GetMonth = function (date)
{
    date = DateTime._parseIfString(date);

    return date.getMonth() + 1;
};

createPropertyGet(Date.prototype, 'Day', function ()
{
    return DateTime.GetDay(this);
});

DateTime.GetDay = function (date)
{
    date = DateTime._parseIfString(date);

    return date.getDate();
};

createPropertyGet(Date.prototype, 'DayOfWeek', function ()
{
    return DateTime.GetDayOfWeek(this);
});

DateTime.GetDayOfWeek = function (date)
{
    date = DateTime._parseIfString(date);

    return date.getDay();
};

createPropertyGet(Date.prototype, 'Hour', function ()
{
    return DateTime.GetHours(this);
});

DateTime.GetHours = function (date)
{
    date = DateTime._parseIfString(date);

    return date.getHours();
};

createPropertyGet(Date.prototype, 'Minute', function ()
{
    return DateTime.GetMinutes(this);
});

DateTime.GetMinutes = function (date)
{
    date = DateTime._parseIfString(date);

    return date.getMinutes();
};

createPropertyGet(Date.prototype, 'Second', function ()
{
    return DateTime.GetSeconds(this);
});

DateTime.GetSeconds = function (date)
{
    date = DateTime._parseIfString(date);

    return date.getSeconds();
};

createPropertyGet(Date.prototype, 'Millisecond', function ()
{
    return DateTime.GetMilliseconds(this);
});

DateTime.GetMilliseconds = function (date)
{
    date = DateTime._parseIfString(date);

    return date.getMilliseconds();
};

DateTime.AddMilliseconds = function(date, value)
{
    var parsedDate = DateTime._parseIfString(date);

    if (parsedDate == null)
    {
        return new Date();
    }

    return new Date(value + parsedDate.getTime());
};

DateTime.AddSeconds = function(date, value)
{
    return DateTime.AddMilliseconds(date, value * 1E3); // 1E3 = 1s
};

DateTime.AddMinutes = function(date, value)
{
    return DateTime.AddMilliseconds(date, value * 6E4); // 6E4 = 1m
};

DateTime.AddHours = function(date, value)
{
    return DateTime.AddMilliseconds(date, value * 36E5); // 36E5 = 1h
};

DateTime.AddDays = function(date, value)
{
    return DateTime.AddMilliseconds(date, value * 864E5); // 864E5 = 1d
};

DateTime.ToLongDateString = function(date)
{
    return DateTime.ToStringFormatted(date, DateTime._getFormatter(culture.current.dtf.ld));
};

DateTime.ToLongTimeString = function(date)
{
    return DateTime.ToStringFormatted(date, DateTime._getFormatter(culture.current.dtf.lt));
};

DateTime.ToShortDateString = function(date)
{
    return DateTime.ToStringFormatted(date, DateTime._getFormatter(culture.current.dtf.sd));
};

DateTime.ToShortTimeString = function(date)
{
    return DateTime.ToStringFormatted(date, DateTime._getFormatter(culture.current.dtf.st));
};

DateTime.ToStringFormatted = function(date, formatter)
{
    if (arguments.length === 1)
    {
        return DateTime.ToString(date);
    }

    date = DateTime._parseIfString(date);

    return format(culture.current, formatter, date);
};

DateTime.ToString = function(date)
{
    if (date == null)
    {
        return '';
    }

    return DateTime._parseIfString(date).toString();
};

DateTime.Parse = function(date)
{
    if (date == null)
    {
        return null;
    }

    return DateTime._parseIfString(date);
};

DateTime._getFormatter = function(pattern)
{
    return '{0:' + pattern + '}';
};

DateTime._parseIfString = function(obj)
{
    if (typeOf(obj) === Date)
    {
        return obj;
    }

    if (typeOf(obj) === String)
    {
        var dateString = obj;

        if (!(endsWith(dateString, 'z') || endsWith(dateString, 'Z')))
        {
            dateString += 'Z';
        }

        var date = new Date(dateString);

        if (isNaN(date))
        {
            date = DateTime._manuallyParseDateFromJsonString(obj);
        }

        return date;
    }

    return null;
};

DateTime._manuallyParseDateFromJsonString = function(str)
{
    var s = str.split(new RegExp('\\D'));
    var s2 = new Array(7);

    for (var i = 0; i < 7; ++i)
    {
        s2[i] = (s[i] == null) ? 0 : parseInt(s[i]);
    }

    return new Date(Date.UTC(s2[0], s2[1] - 1, s2[2], s2[3], s2[4], s2[5]));
};
