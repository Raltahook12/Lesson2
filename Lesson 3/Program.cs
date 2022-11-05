namespace Lesson_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sheep sheep1 = new Sheep();
            sheep1.Health = 100;
            sheep1.Age = 0;
            Sheep sheep2 = new Sheep();
            sheep2.Health = 100;
            sheep2.Age = 1;
            Console.WriteLine($"Овца 1: health -{sheep1.Health}, age - {sheep1.Age}");
            Console.WriteLine($"Овца 2: health -{sheep2.Health}, age - {sheep2.Age}");

            sheep1.Eat();
            sheep2.Eat();

            Student student1 = new Student();
            
            student1.Intelegent = 50;
            student1.knowlages = 100;
            student1.StudentHealth = 100;
            student1.Happynes = 100;

            student1.Study();
            student1.HappyHour();
            student1.Exam();

        }
    }
    internal class Sheep
    {
        public int Health;
        public byte Age;

        public void Eat()
        {
            Health += 10;
            Console.WriteLine($"Овца поела. Здоровье {Health}");
        }

        public int growOld(byte incAge)
        {
            Age += incAge;
            return Age;
        }
    }
    internal class Student 
    {
        public int Intelegent;
        public int StudentHealth;
        public int Happynes;
        public int knowlages;

        public void HappyHour()
        {
            knowlages = knowlages - 10;
            Happynes = Happynes + 10;
            Console.WriteLine($"Студент поразвлекался. Знания:{knowlages}.Счастье:{Happynes} ");
        }

        public void Study()
        {
            knowlages = knowlages + 15;
            Happynes = Happynes - 10;
            Console.WriteLine($"Студент поучился. Знания:{knowlages}.Счастье:{Happynes} ");
        }

        public void Exam()
        {
            Happynes = Happynes - 50;
            StudentHealth = StudentHealth - 40;
            knowlages = 0;
            Console.WriteLine($"Студент сдал экзамен. Знания:{knowlages}.Счастье:{Happynes}. Здоровье:{StudentHealth} ");
        }
    }
}