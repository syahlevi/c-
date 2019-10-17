using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

/// <summary>
/// Summary description for Class1
/// </summary>
public static class Class1
{


    public static string ToMonthName(this DateTime dateTime)
    {
        return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
    }
}