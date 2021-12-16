// See https://aka.ms/new-console-template for more information

// Using
using System.Timers;
using GameOfLife;
using static GameOfLife.Utils;
using Timer = System.Timers.Timer;

// Declarations
var (Left, Top) = Console.GetCursorPosition();
Console.CursorVisible = false;

//Instantiate Game Object
var game = new Game(Left, Top);

//Begin the Game
Listener();
game.BuildScreen();
var t = new Timer();
t.Interval = game.speed; // In milliseconds
t.AutoReset = false; // Stops it from repeating
t.Elapsed += TimerElapsed!;
t.Start();

while (true)
{
    if (Start)
    {
        Wrapper(game.CountNeighbors, game);
        game.PrintGrid();
        Wrapper(game.SetAlive, game);
        Start = false;
        t.Interval = game.speed;
        t.Start();
    }

    if (THold!.IsCompleted)
    {
        // ...or allow continuing to exit 
        if (THold.Result.Key == ConsoleKey.Escape)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(THold.Result.Key);
            return;
        }

        if (THold.Result.Key == ConsoleKey.Add)
        {
            game.speed += 250;
            //Console.WriteLine(speed);
            Listener();
        }
        else if (THold.Result.Key == ConsoleKey.Subtract)
        {
            if (game.speed > 250) game.speed -= 250;
            Listener();
        }
    }
}