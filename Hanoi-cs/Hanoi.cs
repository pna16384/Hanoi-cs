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
    internal class Hanoi
    {
        // The tower T is represented by an implicit group of cylinders < ci : (0 <= i < n); size(ci) > size(ci+1) (for all i>=0)> (so cylinder sizes decrease as we iterate through the array)
        // Each T[i] corresponds to cylinder ci's peg location.  All cylinders default to start on peg 2, where pegs are labelled (from left to right) <2, 1, 0>.  Each C[i] corresponds to cylinder ci's colour.
        int[] T; // cylinder peg index
        xterm256Colour[] C; // cylinder colours

        // Return tower height in cylinders
        public int Height
        {
            get { return T.Length; }
        }

        public Hanoi(xterm256Colour[] cylinderStack, int peg = 2)
        {
            T = new int[cylinderStack.Length];
            C = new xterm256Colour[cylinderStack.Length];

            for (int i = 0; i < Height; i++)
            {
                T[i] = peg;
                C[i] = cylinderStack[i];
            }
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
            int w = 1 + (Height << 1);
            string pegRow = new String(
                new String(' ', ((w - 1) >> 1) + 1) +
                '|' +
                new String(' ', w) +
                '|' +
                new String(' ', w) +
                '|' +
                new String(' ', ((w - 1) >> 1) + 1)
                );

            for (int j = 0; j <= Height; j++) { Console.WriteLine(pegRow); }
            Console.WriteLine("\u25AC".Repeat(w * 3 + 4));

            // Create offsets and cylinder counts for each peg
            int[] offset = { ((w - 1) >> 1) + (w << 1) + 3, ((w - 1) >> 1) + w + 2, ((w - 1) >> 1) + 1 };
            int[] count = { 0, 0, 0 };

            // Position and render each cylinder
            for (int i=0; i < Height; i++) {

                int size = 1 + ((Height - i) << 1);
                int x = offset[T[i]] - ((size - 1) >> 1);

                // set cursor position and colour
                var printString = Cursor.up(count[T[i]] + 2) + Cursor.right(x) + C[i];

                // print cylinder
                printString += "\u25A0".Repeat(size);

                // reset colour and cursor position
                printString += HanoiColour.Default + Cursor.down(count[T[i]] + 2) + "\r";

                // draw
                Console.Write(printString);

                // Update cylinder count
                count[T[i]] += 1;
            }
        }

        // Solve the Hanoi problem.  The approach produces optimal number of moves so this is not tracked or verified in this version.  In addition, movement is calculated from cylinder index alone.  This gives rise to the following observations (1) Even numbered cylinders (including 0) move to the neighbouring left peg wrapping around as needed, while odd numbered cylinders move to the neighbouring right peg, wrapping round as needed. (2) Solve essentially moves the whole tower +1 peg to the left.  These behaviours mean the base cylinder at index 0 (and therefore whole tower) move +1 to the left from (the default left-most) peg 2, wrapping around to peg 0 (right-most peg).  So rather than explicitly specify peg 0 as a target, this behaviour instead emerges from the above observations.  Repeated calls to Solve move the tower to the next neighbouring left peg.
        public void Solve(int i = 0)
        {
            if (i < Height)
            {
                Solve(i + 1);
                T[i] = ((i & 0b1) == 0) ? (T[i] + 1) % 3 : Math.Min((T[i] - 1) & 0b11, 2);
                Solve(i + 1);
            }
        }


        // Solve method with console based tower rendering
        private int _solveRender(int i, int iteration)
        {
            if(i < Height)
            {
                iteration = _solveRender(i + 1, iteration);

                T[i] = ((i & 0b1) == 0) ? (T[i] + 1) % 3 : Math.Min((T[i] - 1) & 0b11, 2);
                iteration++;

                Console.WriteLine("\n\nIteration {0}:\n", iteration);
                PrintTower();

                iteration = _solveRender(i + 1, iteration);
            }

            return iteration;
        }

        public void SolveRender()
        {
            Console.WriteLine("Initial state:\n");
            PrintTower();

            _solveRender(0, 0);
        }
    }
}
