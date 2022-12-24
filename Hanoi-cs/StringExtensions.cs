using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi_cs
{
    internal static class StringExtensions
    {
        public static string Repeat(this string text, int n) {
        
            if (String.IsNullOrEmpty(text) || n<=1)
                return text;

            var builder = new StringBuilder(text.Length * n);

            for (var i = 0; i < n; i++)
                builder.Append(text);

            return builder.ToString();
        }
    }
}
