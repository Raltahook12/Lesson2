using System.Security.Cryptography.X509Certificates;

namespace Lesson3CP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double b = 0;
            double a = Limits(out b);

            double x = a;
            for (a = a; a < b; a++)
            {
                x = a;
                double y = mathFunction(x);
                Console.WriteLine($"{x}",y);
            }
        }
        static double mathFunction(double x)
        {
            double y = Math.Pow((x - 1),2) - 5;
            return y;
        }
        static double Limits(out double b)
        {
            Console.WriteLine("Введите левую гранцу");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите правую границу");
            b = double.Parse(Console.ReadLine());
            return a;
        }
    }
}