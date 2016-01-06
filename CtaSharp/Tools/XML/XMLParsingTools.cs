using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CtaSharp.Tools.XML
{
    internal static class XMLParsingTools
    {
        internal static ushort ParseUShort(string value)
        {
            return ushort.Parse(value);
        }

        internal static int ParseInt(string value)
        {
            return int.Parse(value);
        }

        internal static bool PraseBool(string value)
        {
            return value == "1";
        }

        internal static string ExtractValue(XElement parent, string name)
        {
            return parent.Descendants().Single(x => x.Name == name).Value;
        }

        internal static decimal ParseDecimal(string value)
        {
            return decimal.Parse(value);
        }

        internal static DateTime PraseDateTime(string value)
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
