
// See https://aka.ms/new-console-template for more information

using Hanoi_cs;
using xterm256Colour = System.String;

//using Colour = Hanoi_cs.HanoiColour;

xterm256Colour[] cylinders = { HanoiColour.Yellow, HanoiColour.Cyan, HanoiColour.Green, HanoiColour.Red };

Hanoi H = new Hanoi(cylinders);
H.PrintTower();

H.Solve();

Console.WriteLine("=======");

H.Solve();

Console.WriteLine("=======");

H.Solve();
