// See https://aka.ms/new-console-template for more information
int SCREENHEIGHT = 6;
int SCREENWIDTH = 6;
Cell[,] grid = new Cell[SCREENWIDTH, SCREENHEIGHT];
var (Left, Top) = Console.GetCursorPosition();
void RandomFill(int i, int j)
{
    grid[i, j] = new Cell(RandomAliveCell());
}

void Printgrid()
{
    Console.SetCursorPosition(Left, Top);
    for (int i = 0; i < grid.GetLength(0); i++)
    {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
            if (grid[i, j].IsAlive)
            {
                //  Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("1");
            }
            else
            {
                // Console.BackgroundColor = ConsoleColor.White;
                Console.Write("0");
            }
            //Console.Write(" ");
        }
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine();
    }

}

void CountNeighbors(int x, int y)
{
    //South
    if (y + 1 < SCREENHEIGHT)
    {
        if (grid[x, y + 1].IsAlive)
        {
            grid[x, y].NumNeighbors++;
        }
    }
    // East
    if (x + 1 < SCREENWIDTH)
    {
        if (grid[x + 1, y].IsAlive)
        {
            grid[x, y].NumNeighbors++;
        }
    }
    //North
    if (y - 1 >= 0)
    {
        if (grid[x, y - 1].IsAlive)
        {
            grid[x, y].NumNeighbors++;
        }
    }
    //West
    if (x - 1 >= 0)
    {
        if (grid[x - 1, y].IsAlive)
        {
            grid[x, y].NumNeighbors++;
        }
    }
    //SouthEest
    if (x + 1 < SCREENWIDTH && y + 1 < SCREENHEIGHT)
    {
        if (grid[x + 1, y + 1].IsAlive)
        {
            grid[x, y].NumNeighbors++;
        }
    }
    //SouthWest
    if (x - 1 >= 0 && y + 1 < SCREENHEIGHT)
    {
        if (grid[x - 1, y + 1].IsAlive)
        {
            grid[x, y].NumNeighbors++;
        }
    }
    //NorthWest
    if (x - 1 >= 0 && y - 1 >= 0)
    {
        if (grid[x - 1, y - 1].IsAlive)
        {
            grid[x, y].NumNeighbors++;
        }
    }
    //NorthEast
    if (x + 1 < SCREENWIDTH && y - 1 >= 0)
    {
        if (grid[x + 1, y - 1].IsAlive)
        {
            grid[x, y].NumNeighbors++;
        }
    }

}

bool RandomAliveCell()
{
    var rnd = new Random();
    int rand = rnd.Next(0, 100);
    if (rand > 75)
    {
        return true;
    }
    else
    {
        return false;
    }
}

void Wrapper(Action<int, int> functopass)
{
    for (int i = 0; i < grid.GetLength(0); i++)
    {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
            functopass(i,j);
        }
    }
}

void SetAlive(int x, int y)
{
    if (grid[x, y].IsAlive)
    {
        if (grid[x, y].NumNeighbors != 2 && grid[x, y].NumNeighbors != 3)
        {
            grid[x, y].SetAlive(!grid[x, y].IsAlive);
        }
    }
    else
    {
        if (grid[x, y].NumNeighbors == 3)
        {
            grid[x, y].SetAlive(!grid[x, y].IsAlive);
        }
    }
}
Wrapper(RandomFill);
while (true)
{
    Printgrid();
    Wrapper(CountNeighbors);
    Wrapper(SetAlive);
    Console.ReadKey();
   // Thread.Sleep(1000);
}