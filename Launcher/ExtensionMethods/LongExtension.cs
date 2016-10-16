using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.ExtensionMethods
{
    public static class LongExtension
    {
            public const long OneKb = 1024;
            private const long OneMb = OneKb * 1024;
            private const long OneGb = OneMb * 1024;
            private const long OneTb = OneGb * 1024;

            public static string ToPrettySize(this int value, int decimalPlaces = 0)
            {
                return ((long)value).ToPrettySize(decimalPlaces);
            }

            public static string ToPrettySize(this long value, int decimalPlaces = 0)
            {
                var asTb = Math.Round((double)value / OneTb, decimalPlaces);
                var asGb = Math.Round((double)value / OneGb, decimalPlaces);
                var asMb = Math.Round((double)value / OneMb, decimalPlaces);
                var asKb = Math.Round((double)value / OneKb, decimalPlaces);
                return asTb > 1
                    ? $"{asTb}Tb"
                    : asGb > 1
                        ? $"{asGb}Gb"
                        : asMb > 1
                            ? $"{asMb}Mb"
                            : asKb > 1
                                ? $"{asKb}Kb"
                                : $"{Math.Round((double) value, decimalPlaces)}B";
            }
        }
}
