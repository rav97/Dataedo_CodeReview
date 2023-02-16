using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting
{
    public static class ExtendedMethods
    {
        public static string RemoveAllWhitespaces(this string text)
        {
            return string.Concat(text.Where(c => !char.IsWhiteSpace(c)));
        }
    }
}
