namespace GameOfLife;

public class Game
{
    private long generation = 0;
    private readonly int SCREENHEIGHT = 80;
    private readonly int SCREENWIDTH = 25;
    public int speed = 250;
    public Cell[,] grid;
    private readonly int Left;
    private readonly int Top;

    public Game(int left, int top)
    {
        Left = left;
        Top = top;
        grid = new Cell[SCREENWIDTH, SCREENHEIGHT];
        RandomFill();
    }

    public void RandomFill()
    {
        for (var i = 0; i < this.grid.GetLength(0); i++)
            for (var j = 0; j < this.grid.GetLength(1); j++)
                this.grid[i, j] = new Cell(Utils.RandomAliveCell());
    }

    public void BuildScreen()
    {
        Console.SetCursorPosition(Left + 30, Top);
        Console.WriteLine("The Game of Life!");
        Console.SetCursorPosition(Left, Top + 1);
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        for (var i = 0; i <= SCREENHEIGHT + 1; i++) Console.Write(" ");

        for (var i = 0; i <= SCREENWIDTH; i++)
        {
            Console.SetCursorPosition(Left, Top + 1 + i);
            Console.WriteLine(" ");
        }
        Console.SetCursorPosition(SCREENHEIGHT + 15, Top + 5);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write("Rules!");
        Console.SetCursorPosition(SCREENHEIGHT + 5, Top + 7);
        Console.Write("1. Any cell with less than 2");
        Console.SetCursorPosition(SCREENHEIGHT + 7, Top + 8);
        Console.Write(" Neighbors Dies.");
        Console.SetCursorPosition(SCREENHEIGHT + 5, Top + 10);
        Console.Write("2. Any cell with more than 3");
        Console.SetCursorPosition(SCREENHEIGHT + 7, Top + 11);
        Console.Write(" Neighbors Dies.");
        Console.SetCursorPosition(SCREENHEIGHT + 5, Top + 13);
        Console.Write("3. Any dead cell with exactly 3");
        Console.SetCursorPosition(SCREENHEIGHT + 7, Top + 14);
        Console.Write(" Neighbors comes to life.");

        Console.SetCursorPosition(SCREENHEIGHT + 7, Top + 16);
        Console.Write(" + or - To change the Speed.");
        Console.SetCursorPosition(SCREENHEIGHT + 7, Top + 17);
        Console.Write(" Press Escape to Quit.");


        Console.SetCursorPosition(SCREENHEIGHT + 7, Top + 2 + SCREENWIDTH);
        Console.Write("Adapted to C# by John Burns");
    }
    public void CountNeighbors(int x, int y)
    {
        grid[x, y].NumNeighbors = 0;
        //South
        if (y + 1 < SCREENHEIGHT)
            if (grid[x, y + 1].IsAlive)
                grid[x, y].NumNeighbors++;
        // East
        if (x + 1 < SCREENWIDTH)
            if (grid[x + 1, y].IsAlive)
                grid[x, y].NumNeighbors++;
        //North
        if (y - 1 >= 0)
            if (grid[x, y - 1].IsAlive)
                grid[x, y].NumNeighbors++;
        //West
        if (x - 1 >= 0)
            if (grid[x - 1, y].IsAlive)
                grid[x, y].NumNeighbors++;
        //SouthEast
        if (x + 1 < SCREENWIDTH && y + 1 < SCREENHEIGHT)
            if (grid[x + 1, y + 1].IsAlive)
                grid[x, y].NumNeighbors++;
        //SouthWest
        if (x - 1 >= 0 && y + 1 < SCREENHEIGHT)
            if (grid[x - 1, y + 1].IsAlive)
                grid[x, y].NumNeighbors++;
        //NorthWest
        if (x - 1 >= 0 && y - 1 >= 0)
            if (grid[x - 1, y - 1].IsAlive)
                grid[x, y].NumNeighbors++;
        //NorthEast
        if (x + 1 < SCREENWIDTH && y - 1 >= 0)
            if (grid[x + 1, y - 1].IsAlive)
                grid[x, y].NumNeighbors++;
    }

    public void PrintGrid()
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

    public void SetAlive(int x, int y)
    {
        if (grid[x, y].IsAlive)
        {
            if (grid[x, y].NumNeighbors != 2 && grid[x, y].NumNeighbors != 3) grid[x, y].SetAlive(!grid[x, y].IsAlive);
        }
        else
        {
            if (grid[x, y].NumNeighbors == 3) grid[x, y].SetAlive(!grid[x, y].IsAlive);
        }
    }
}