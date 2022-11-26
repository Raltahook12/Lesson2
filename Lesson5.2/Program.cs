using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Lesson5._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector2 v = new Vector2(2, 0);
            Sheep s = new Sheep(v);
        }
    }
    public class Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static double ScalarMultiple(Vector2 v, double scalar)
        { 
            return v.X * scalar + v.Y * scalar;
        }

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
    public abstract class Animal
    {
        public Vector2 Position { get; set; }
        public int Health { get; set; }

        public void Move(int direction)
        {
            if (direction == 0)
                Position.X += 1;
            else if (direction == 1)
                Position.Y -= 1;
            else if (direction == 2)
                Position.X -= 1;
            else
                Position.Y += 1;
        }

        public abstract void Eat();
        public Animal(Vector2 position, int health)
        {
            Position = position;
            Health = health;
        }
        public Animal(Vector2 position) : this(position, 100)
        {

        }
    }
    public class Sheep:Animal
    {
        public Vector2 Position { get; set; }
        public int Health { get; set; }

        public void Move(int direction)
        {
            if (direction == 0)
                Position.X += 1;
            else if (direction == 1)
                Position.Y -= 1;
            else if (direction == 2)
                Position.X -= 1;
            else
                Position.Y += 1;
        }

        public virtual void Eat()
        {
            Console.WriteLine("Овца поела");
        }
        public Sheep(Vector2 position, int health)
        {
            Position = position;
            Health = health;
        }
        public Sheep(Vector2 position) : this(position, 100)
        { 
        
        }
    }
    public class Wolf : Sheep
    {
        public int Attack { get; set; }
        public Wolf(Vector2 position, int health) : base(position, health)
        {
            Attack = 10;
        }

        public override void Eat()
        {
            Console.WriteLine("Волк съел овцу");
        }
    }

    class Person
    { 
        public string Name { get; set; }

        public int Salary { get; set; }

        public Person(string name, int salary)
        { 
            Name = name;
            Salary = salary;
        }

        public void IncreaseSalary(int step)
        {
            Salary += step;
        }
    }
    static class Calculator
    {
        public static int Sum(int n1, int n2)
        {
            return n1 + n2;
        }
        public static int Diff(int n1, int n2)
        {
            return n1 - n2;
        }
    }
}

