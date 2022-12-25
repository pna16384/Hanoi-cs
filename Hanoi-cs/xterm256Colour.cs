using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi_cs
{
    using xterm256Colour = String;

    internal class HanoiColour
    {
        public const xterm256Colour Default = "\x1b[0m";
        public const xterm256Colour Red = "\x1b[38;5;9m";
        public const xterm256Colour Green = "\x1b[38;5;10m";
        public const xterm256Colour Yellow = "\x1b[38;5;11m";
        public const xterm256Colour Magenta = "\x1b[38;5;13m";
        public const xterm256Colour Cyan = "\x1b[38;5;14m";
    }
}
