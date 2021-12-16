class Game
{




    void PrintGrid()
    {
        Console.SetCursorPosition(SCREENHEIGHT + 2, Top + 1);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write($"Generation: {generation}");

        Console.SetCursorPosition(Left + 1, Top + 2);
        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (var j = 0; j < grid.GetLength(1); j++)
                if (grid[i, j].IsAlive)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" ");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
            //Console.Write(" ");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(" ");
        }

        Console.BackgroundColor = ConsoleColor.DarkGreen;
        for (var i = 0; i < SCREENHEIGHT + 1; i++) Console.Write(" ");

        generation++;
    }
}