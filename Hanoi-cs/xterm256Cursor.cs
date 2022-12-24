using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi_cs
{
    internal class xterm256Cursor
    {
        public static string up(int n)
        {
            return "\x1b[A".Repeat(n);
        }
        public static string down(int n)
        {
            return "\x1b[B".Repeat(n);
        }
        public static string right(int n)
        {
            return "\x1b[C".Repeat(n);
        }
        public static string left(int n)
        {
            return "\x1b[D".Repeat(n);
        }

        //public static string cr() { return "\r"; }

        //public static string newLine() { return "\n"; }
    }
}
