namespace Lesson7CP;
public class Cursor : Selection
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Cursor(int x, int y) : base(x, y)
    { 
    }

    
    public void Move(int direction)
    {
        if (direction == 0)
            X += 1;
        else if (direction == 1)
            Y += 1;
        if (direction == 2)
            X -= 1;
        if (direction == 3)
            Y -= 1;
    }
}