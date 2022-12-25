
// See https://aka.ms/new-console-template for more information

using Hanoi_cs;
using xterm256Colour = System.String;

xterm256Colour[] cylinders = {
    //HanoiColour.Yellow,
    //HanoiColour.Blue,
    //HanoiColour.Green,
    //HanoiColour.Red
    HanoiColour.BuildColour(15, 93),
    HanoiColour.BuildColour(31),
    HanoiColour.BuildColour(47),
    HanoiColour.BuildColour(63),
    HanoiColour.BuildColour(126)
};

Hanoi H = new Hanoi(cylinders);
H.PrintTower();
H.Solve();
Console.WriteLine(HanoiColour.Red.Length);