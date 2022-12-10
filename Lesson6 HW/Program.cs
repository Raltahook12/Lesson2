using System.Security.Cryptography.X509Certificates;

namespace Lesson6_HW
{
    internal class Program
    {
        static List<Animal> animals = new List<Animal>();
        static List<Animal> sheeps = new List<Animal>();
      
        static Field field = new Field(15, 15);
        static Random rnd = new Random();



        static void Main()
        {
            
            Wolf w = new Wolf(5, 5);
           
            animals.Add(w);
            for (int i = 0; i < 3; i++)
            {
                Sheep s = new Sheep(rnd.Next(0, (field.Space.GetLength(0) - 1)), rnd.Next(0, (field.Space.GetLength(1) - 1)));
                animals.Add(s);
                sheeps.Add(s);

            }
            while (true)
            {
                field.InitializeField();
                Eat(animals[0].X, animals[0].Y);
                PlaceObjects();
                RenderField();
                



                ConsoleKeyInfo pushedKey = Console.ReadKey();
                int dir = 0;
                if (pushedKey.Key == ConsoleKey.RightArrow)
                    dir = 0;
                else if (pushedKey.Key == ConsoleKey.DownArrow)
                    dir = 1;
                else if (pushedKey.Key == ConsoleKey.LeftArrow)
                    dir = 2;
                else if (pushedKey.Key == ConsoleKey.UpArrow)
                    dir = 3;
                       
                foreach (Animal a in animals)
                {

                    if (a is Wolf)
                    {
                        a.Move(dir);
                        
                    }
                    else
                    {
                        a.Move(rnd.Next(0, 3));
                    }
                }
                Eat(animals[0].X, animals[0].Y);



            }
        }
        static void Eat(int WolfX,int WolfY)
        {
            foreach (Animal a in animals)
            {
                if (a is Sheep)
                {
                    if (a.X == WolfX && a.Y == WolfY)
                    {
                        sheeps.Remove(a);
                    }
                }
            }
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i] is Sheep)
                {
                    animals.Remove(animals[i]);
                }
            }
            foreach (Sheep s in sheeps)
            {
                animals.Add(s);
            }
        }
        static void PlaceObjects()
        {
            
            foreach (Animal a in animals)
            {
                char sprite = '\0';
                switch (a.Name)
                {
                    case "Wolf":
                        {
                            sprite = 'w';
                            break;
                        }
                    case "Sheep":
                        {
                            sprite = 's';
                            break;
                        }
                }
                if (a.X >= field.Space.GetLength(0) -1 || a.X <= 0 || a.Y >= field.Space.GetLength(1) -1|| a.Y <= 0)
                {
                    if (a.X >= field.Space.GetLength(0) - 1 )
                    {
                        a.Barier(0, field.Space.GetLength(0) - 1 );
                    }
                    else if (a.X <= 0)
                    {
                        a.Barier(0, 0);
                    }
                    else if (a.Y >= field.Space.GetLength(1)  - 1)
                    {
                        a.Barier(1, field.Space.GetLength(1) - 1);
                    }
                    else if (a.Y <= 0)
                    {
                        a.Barier(1, 0);
                    }
                }
                field.Space[a.X, a.Y] = sprite;
            }

        }
        static void RenderField()
        {
            Console.Clear();
            for (int y = 0; y < field.Space.GetLength(1); y++)
            {
                for (int x = 0; x < field.Space.GetLength(0); x++)
                {
                    if (field.Space[x, y] == 'w' || field.Space[x, y] == 's')
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
}
