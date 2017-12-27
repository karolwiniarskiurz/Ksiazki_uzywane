using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UzywaneKsiazki.Extensions
{
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        public static string RemoveSpacesAndSpecialMarks(this string text)
        {
            var reg = new Regex("[^a-z0-9-ąćęłńóśźż ]+");
            var array = reg.Replace(text.ToLower(), string.Empty).Trim().ToCharArray();
            var sb = new StringBuilder();
            foreach (var letter in array)
            {
                switch (letter)
                {
                    case 'ą':
                        sb.Append("a");
                        break;
                    case 'ć':
                        sb.Append("c");
                        break;
                    case 'ę':
                        sb.Append("e");
                        break;
                    case 'ł':
                        sb.Append("l");
                        break;
                    case 'ń':
                        sb.Append("n");
                        break;
                    case 'ó':
                        sb.Append("o");
                        break;
                    case 'ś':
                        sb.Append("s");
                        break;
                    case 'ż':
                        sb.Append("z");
                        break;
                    case 'ź':
                        sb.Append("z");
                        break;
                    case ' ':
                        sb.Append("_");
                        break;
                    default:
                        sb.Append(letter);
                        break;
                }
            }

            return sb.ToString();
        }
    }
}


