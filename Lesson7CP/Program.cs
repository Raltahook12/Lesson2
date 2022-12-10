namespace Lesson7CP;

internal class Program
{
    static List<Ship> ships = new List<Ship>();
    static List<Ship> falenShips = new List<Ship>();
    static List<Ship> buffer = new List<Ship>();
    static List<Selection> selections = new List<Selection>();
    static Field field = new Field(10, 10);
    static Random rnd = new Random();

  


    static void Main()
    {
        Cursor cursor = new Cursor(5, 5);
        selections.Add(cursor);
        for (int i = 0; i < 3; i++)
        {
            Ship s = new Ship(rnd.Next(0, (field.Space.GetLength(0) - 1)), rnd.Next(0, (field.Space.GetLength(1) - 1)));
            ships.Add(s);
            buffer.Add(s);

        }
        while (true)
        {
            field.InitializeField();
            PlaceObjects();
            RenderField();




            ConsoleKeyInfo pushedKey = Console.ReadKey();
            int dir =  -1;
            if (pushedKey.Key == ConsoleKey.RightArrow)
                dir = 0;
            else if (pushedKey.Key == ConsoleKey.DownArrow)
                dir = 1;
            else if (pushedKey.Key == ConsoleKey.LeftArrow)
                dir = 2;
            else if (pushedKey.Key == ConsoleKey.UpArrow)
                dir = 3;
            if (dir != -1)
            {
                foreach (Selection cur in selections)
                {
                    if (cur is Cursor)
                    {
                        cur.Move(dir);
                    }
                }
            }
            
            if (pushedKey.Key == ConsoleKey.Enter)
            {
                foreach (Selection cur in selections)
                {
                    if (cur is Cursor)
                    {
                        Eat(cur.X, cur.Y);
                    }
                }
            }
        }
    }
    static void Eat(int WolfX, int WolfY)
    {
        foreach (Ship a in ships)
        {
            if (a is Ship)
            {
                if (a.X == WolfX && a.Y == WolfY)
                {
                    buffer.Remove(a);
                    falenShips.Add(a);
                }
                else
                {
                    Missing miss = new Missing(WolfX, WolfY);
                    selections.Add(miss);
                }
                
            }
        }
        for (int i = 0; i < ships.Count; i++)
        {
           ships.Remove(ships[i]);
        }
        foreach (Ship s in buffer)
        {
            ships.Add(s);
        }

       
    }
    static void PlaceObjects()
    {

        foreach (Ship a in ships)
        {
            field.Space[a.X, a.Y] = 's';
        }
        foreach (Selection selection in selections)
        {
            if (selection is Cursor)
            {
                field.Space[selection.X, selection.Y] = 'C';
            }
        }
        foreach (Ship a in falenShips)
        {
            field.Space[a.X, a.Y] = 'X';
        }

    }
    static void RenderField()
    {
        Console.Clear();
        for (int y = 0; y < field.Space.GetLength(1); y++)
        {
            for (int x = 0; x < field.Space.GetLength(0); x++)
            {
                if (field.Space[x, y] == 's')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(field.Space[x, y]);
                    Console.ResetColor();
                }
                if (field.Space[x, y] == 'C')
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(field.Space[x, y]);
                    Console.ResetColor();
                }
                if (field.Space[x, y] == 'X')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(field.Space[x, y]);
                    Console.ResetColor();
                }
                else if (field.Space[x, y] == '\0')
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
    }
}