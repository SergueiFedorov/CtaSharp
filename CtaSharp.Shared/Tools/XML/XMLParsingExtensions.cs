using System;

namespace CtaSharp.Shared.Tools.XML
{
    public static class XMLParsingExtensions
    {
        public static bool ToBoolean(this string value)
        {
            if (value != "1" && value != "0")
            {
                throw new Exception($"Value passed to ParseBool is not 1 or 0. Value passed: {value}");
            }

            return value == "1";
        }

        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }

        public static Decimal ToDecimal(this string value)
        {
            return Decimal.Parse(value);
        }

        public static DateTime ToBusDateTime(this string value)
        {
            var year = int.Parse(value.Substring(0, 4));
            var month = int.Parse(value.Substring(4, 2));
            var day = int.Parse(value.Substring(6, 2));

            var timeSegments = value.Substring(9, 5).Split(':');

            var hour = int.Parse(timeSegments[0]);
            var minute = int.Parse(timeSegments[1]);

            return new DateTime(year, month, day, hour, minute, 0);
        }

        public static DateTime ToTrainDateTime(this string value)
        {
            var year = int.Parse(value.Substring(0, 4));
            var month = int.Parse(value.Substring(4, 2));
            var day = int.Parse(value.Substring(6, 2));

            var timeSegments = value.Substring(9, 8).Split(':');

            var hour = int.Parse(timeSegments[0]);
            var minute = int.Parse(timeSegments[1]);
            var seconds = int.Parse(timeSegments[2]);

            return new DateTime(year, month, day, hour, minute, seconds);
        }
    }
}
