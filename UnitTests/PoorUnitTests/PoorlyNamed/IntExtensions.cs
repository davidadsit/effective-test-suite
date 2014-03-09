using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorUnitTests.PoorlyNamed
{
    public static class IntExtensions
    {
        static readonly Dictionary<int, string> Translations = new Dictionary<int, string>
                                                                   {
                                                                       {1000, "M"},
                                                                       {900, "CM"},
                                                                       {500, "D"},
                                                                       {400, "CD"},
                                                                       {100, "C"},
                                                                       {90, "XC"},
                                                                       {50, "L"},
                                                                       {40, "XL"},
                                                                       {10, "X"},
                                                                       {9, "IX"},
                                                                       {5, "V"},
                                                                       {4, "IV"},
                                                                       {1, "I"},
                                                                   };

        public static string ToRoman(this int x)
        {
            var result = new StringBuilder();
            foreach (var translation in Translations.OrderByDescending(map => map.Key))
            {
                while (x >= translation.Key)
                {
                    result.Append(translation.Value);
                    x -= translation.Key;
                }
            }
            return result.ToString();
        }
    }
}