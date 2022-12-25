using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cursor = Hanoi_cs.xterm256Cursor;
using xterm256Colour = System.String;

namespace Hanoi_cs
{

    struct Cylinder
    {
        public int peg;
        public readonly xterm256Colour colour;
        
        public Cylinder(int peg, xterm256Colour colour)
        {
            this.peg = peg;
            this.colour = colour;
        }
    }

    internal class Hanoi
    {
        // Tower array
        Cylinder[] T;

        public int n
        {
            get { return T.Length; }
        }

        // size of cylinder implicit in pos in array
        public Hanoi(xterm256Colour[] C, int peg = 2)
        {
            T = new Cylinder[C.Length];

            for (int i = 0; i < n; i++) T[i] = new Cylinder(peg, C[i]);
        }

        public void PrintTower()
        {
            /*

             Render peg board - "ascii-art" version of tower configuration

             largest cylinder width = 1 + (T.Length << 1) = w
             g = gap between largest cylinder if 2 copies on neighbouring pegs

              ^                 |             |             |               <--- pegRow string
              |                 |             |             |
             n+1                |             |             |
              v   ((w-1)/2)+1   |      w      |      w      |  ((w-1)/2)+1
                 ---------------------------------------------------------- <--- baseline
             */

            // Build and render peg rows and baseline
            int w = 1 + (n << 1);
            string pegRow = new String(
                new String(' ', ((w - 1) >> 1) + 1) +
                '|' +
                new String(' ', w) +
                '|' +
                new String(' ', w) +
                '|' +
                new String(' ', ((w - 1) >> 1) + 1)
                );

            for (int j = 0; j <= n; j++) { Console.WriteLine(pegRow); }
            Console.WriteLine("\u25AC".Repeat(w * 3 + 4));

            int[] offset = { ((w - 1) >> 1) + (w << 1) + 3, ((w - 1) >> 1) + w + 2, ((w - 1) >> 1) + 1 };
            int[] count = { 0, 0, 0 };

            for (int i=0; i < n; i++) {

                int size = 1 + ((n - i) << 1);
                int x = offset[T[i].peg] - ((size - 1) >> 1);

                // set cursor position and colour
                var printString = Cursor.up(count[T[i].peg] + 2) + Cursor.right(x) + T[i].colour;

                // print cylinder
                printString += "\u25A0".Repeat(size);

                // reset colour and cursor position
                printString += HanoiColour.Default + Cursor.down(count[T[i].peg] + 2) + "\r";

                // draw
                Console.Write(printString);

                // Update cylinder count
                count[T[i].peg] += 1;
            }
        }

        public void Solve(int i = 0)
        {
            if (i<n)
            {
                Solve(i + 1);

                T[i].peg = ((i & 0b1) == 0) ? (T[i].peg + 1) % 3 : Math.Min((T[i].peg - 1) & 0b11, 2);
                PrintTower();

                Solve(i + 1);
            }
        }

    }
}
