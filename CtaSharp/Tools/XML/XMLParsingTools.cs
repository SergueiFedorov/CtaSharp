﻿using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

[assembly: InternalsVisibleTo("CtaSharp.UnitTests")]

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

        internal static bool ParseBool(string value)
        {
            if (value != "1" && value != "0")
            {
                throw new Exception($"Value passed to ParseBool is not 1 or 0. Value passed: {value}");
            }

            return value == "1";
        }

        internal static string ExtractValue(XElement parent, string name)
        {
            return parent.Descendants().Single(x => x.Name == name).Value;
        }

		internal static string ExtractAttribute(XElement element, string attributeName)
		{
			return element.Attributes().Single(attrib => attrib.Name == attributeName).Value;
		}

        internal static decimal ParseDecimal(string value)
        {
            return decimal.Parse(value);
        }
			
        internal static DateTime PraseDateTime(string value)
        {
			//Todo: needs clean up. Prone to format change crashes
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
