
// See https://aka.ms/new-console-template for more information

using Colour = Hanoi_cs.xterm256Colour;
using Cursor = Hanoi_cs.xterm256Cursor;

Console.WriteLine("Foo");
Console.WriteLine("");
Console.WriteLine("Bar");
Console.WriteLine("");
Console.WriteLine(Colour.Red + "Hello," + Colour.Cyan + " World!" + Colour.Default + "!!!");

Console.Write(Cursor.up(4) + "---");
Console.Write(Cursor.down(4) + Cursor.left(3));
