//Random rnd = new Random();
using System.Globalization;

namespace Lesson_5
{
    internal class Rnd
    {
        public static Random rnd = new Random();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> entitys = new List<Employee>();

            for (int j = 0; j < 3; j++)
            {
                int[] emplSalarys = new int[] { };
                for (int i = 0; i < 11; i++)
                {
                    emplSalarys.ToList().Add(Rnd.rnd.Next(10000, 12000));
                }
                Employee entity_ = new Employee($"empl{j}", emplSalarys);
                entitys.Add(entity_);
            }
            foreach (Employee entity in entitys)
            {
                Console.WriteLine(entity.Name);
                Thread.Sleep(2000);
                if (entity.Name == "empl2")
                {
                    double emplMean = Employee.MeanSalary(entity.Salarys);
                    Console.WriteLine($"Средняя зарплата: {emplMean}");
                    int emplMonthMax = Employee.MonthWithMaxSalary(entity.Salarys);
                    Console.WriteLine($"номер месяца с максимальной зарплатой: {emplMean+1}");
                    Thread.Sleep(2000);
                }
            }
        }
    }
    internal class Employee
    {
        public string Name;

        public int[] Salarys;

        public static double MeanSalary(int[] salarys)
        {
            double mean = salarys.Average();
            return mean;
        }

        public static int MonthWithMaxSalary(int[] salarys)
        {
            int max = salarys.Max();
            int indexMax = salarys.ToList().IndexOf(max);
            int result = indexMax;
            return result;
        }

        public Employee(string name, int[] salarys)
        {
            Name = name;
            Salarys = salarys;
        }
    }


}
