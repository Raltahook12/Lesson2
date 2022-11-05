namespace Lesson2
{
    internal class Program
    {
        static void Main(string[] args)
        {
        https://prod.liveshare.vsengsaas.visualstudio.com/join?6E63E772A7AD894CA8AC7A93102925B0EE64
            string name = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите ЗП за кварталы");
            
            int chapt1 = int.Parse(Console.ReadLine());
            int chapt2 = int.Parse(Console.ReadLine());
            int chapt3 = int.Parse(Console.ReadLine());
            
            int chapt4 = int.Parse(Console.ReadLine());
            if (age >= 18)
                Console.WriteLine($"Имя сотрудника: {name} \n Фамилия сотрудника: {lastName} " +
                    $"\n  Возраст сотрудника: {age}\n Средняя зарплата за год: {(chapt1 + chapt2 + chapt3 + chapt4) / 4}");

            else if (age < 18)
                Console.WriteLine("Детский труд запрещён");
            else if (age < 0 | chapt1 < 0 | chapt2 < 0 | chapt3 < 0 | chapt4 < 0)
                Console.WriteLine("Некорректные данные");
        }


    }
}