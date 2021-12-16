// See https://aka.ms/new-console-template for more information
class Cell
{
    public bool IsAlive { get; set; }
    public int NumNeighbors { get; set; }
    public bool WasAlive { get; set; }

    public void SetAlive(bool alive)
    {
        WasAlive = IsAlive;
        IsAlive = alive;

    }
    public Cell()
    {
        WasAlive = false;
        IsAlive = false;
        NumNeighbors = 0;
    }
    public Cell(bool alive)
    {
        IsAlive = alive;

    }
}