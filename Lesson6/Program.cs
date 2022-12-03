using System.Threading;

namespace Lesson6
{
    internal class Program
    {
        //Тут должен быть мэин
        Scientist Daniil = new Scientist("Daniil", 20, -10000, "Даже не балаклавр");
    }
    public abstract class Person
    {
        private string _name;

        public string Name { get { return _name; } set { _name = value; } }

        private int _age;

        public int Age { get { return _age; } set { _age = value; } }

        public int Salary;

        public virtual void WriteCharacterisitics()
        {
            ;
        }
    }

    public class Scientist : Person
    {
        private string _grade;

        public string Grade { get { return _grade; } set { _grade = value; } }

        public override void WriteCharacterisitics()
        {
            Console.WriteLine($"Работник: {Name} \n Возраст:{Age} \n Зарплата:{salary} \n Учёное звание: {_grade}");
        }
        public Scientist(string name, int age, int salary, string grade)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Grade = grade;
        }
    }
}