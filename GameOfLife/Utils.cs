using System.Reflection.Metadata.Ecma335;
using System.Timers;

namespace GameOfLife;

public static class Utils
{
    public static bool Start = true;
    public static Task<ConsoleKeyInfo>? THold { get; set; }

    public static void Wrapper(Action<int, int> functopass,Game game)
    {
        for (var i = 0; i < game.grid.GetLength(0); i++)
        for (var j = 0; j < game.grid.GetLength(1); j++)
            functopass(i, j);
    }

    public static bool RandomAliveCell()
    {
        var rnd = new Random();
        var rand = rnd.Next(0, 100);
        return rand > 75;
    }

    public static async Task<ConsoleKeyInfo> Listener()
    {
        THold = Task.Run(()  => Console.ReadKey(true));
        return await THold;
    }
    public static void TimerElapsed(object sender, ElapsedEventArgs e) => Start = true;
}