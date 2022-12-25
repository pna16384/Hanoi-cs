using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using xterm256Colour = System.String;

namespace Hanoi_cs
{
    internal class HanoiColour
    {
        public const xterm256Colour Default = "\x1b[0m";
        public const xterm256Colour Black = "\x1b[38;5;0m";
        public const xterm256Colour Red = "\x1b[38;5;1m";
        public const xterm256Colour Green = "\x1b[38;5;2m";
        public const xterm256Colour Yellow = "\x1b[38;5;3m";
        public const xterm256Colour Blue = "\x1b[38;5;4m";
        public const xterm256Colour Magenta = "\x1b[38;5;5m";
        public const xterm256Colour Cyan = "\x1b[38;5;6m";
        public const xterm256Colour White = "\x1b[38;5;7m";

        public static xterm256Colour BuildColour(uint value, uint? background = null)
        {
            string str = "\x1b[38;5;" + (value & 0xFF) + "m";

            if (background is uint bground)
            {
                str += "\x1b[48;5;" + (bground & 0xFF) + "m";
            }

            return str;
        }
    }
}
