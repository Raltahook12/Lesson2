using System.Threading;

namespace Lesson6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Scientist Daniil = new Scientist("Daniil", 20, -10000, "Даже не балаклавр");
            Daniil.WriteCharacterisitics();
            Console.ReadKey();
        }
    }
    public abstract class Person
    {
        private string _name;

        public string Name { get { return _name; } }

        private int _age;

        public int Age { get { return _age; } }

        public int Salary;

        public abstract void WriteCharacterisitics();

        public Person(string name, int age , int salary)
        {
            _age = age;
            _name = name;
            Salary = salary;
        }
    }

    public class Scientist : Person
    {
        private string _grade;

        public string Grade { get { return _grade; } set { _grade = value; } }

        public override void WriteCharacterisitics()
        {
            Console.WriteLine($"Работник: {Name} \n Возраст:{Age} \n Зарплата:{Salary} \n Учёное звание: {_grade}");
        }
        public Scientist(string name, int age, int salary, string grade) : base(name, age , salary)
        {
            Grade = grade;
        }
    }
}