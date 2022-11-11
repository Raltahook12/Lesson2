using System;

namespace Lesson3HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            PoketMon Charmander = new PoketMon();
            Charmander.hp = random.Next(20, 30);
            Charmander.def = random.Next(2, 6);
            Charmander.atk = random.Next(6, 10);
            Charmander.agil = random.Next(5, 10);
            Charmander.name = "Charmander";

            PoketMon Bulbasavr = new PoketMon();
            Bulbasavr.hp = random.Next(30, 40);
            Bulbasavr.def = random.Next(6, 10);
            Bulbasavr.atk = random.Next(6, 10);
            Bulbasavr.agil = random.Next(1, 6);
            Bulbasavr.name = "Bulbasavr";

            Console.WriteLine("Начало боя, статы участников:");
            Console.WriteLine($"{Charmander.name},Здоровье:{Charmander.hp},Атака: {Charmander.atk}, Защита: {Charmander.def}, Ловкость: {Charmander.agil}");
            Console.WriteLine($"{Bulbasavr.name},Здоровье:{Bulbasavr.hp},Атака: {Bulbasavr.atk}, Защита: {Bulbasavr.def}, Ловкость: {Bulbasavr.agil}");
            while (Bulbasavr.hp > 0 & Charmander.hp > 0)
            {
                Battle(ref Charmander,ref Bulbasavr);
            }

        }
        static void Battle(ref PoketMon Pokemon1,ref PoketMon Pokemon2)
        {
            int sleep = 2000;
            Random random = new Random();
            int doing = random.Next(0, 2);

            if (doing == 0)
            {
                Console.WriteLine($"{Pokemon1.name} атакует");
                int poke2move = random.Next(0, 2);
                if (poke2move == 0)
                {
                    Console.WriteLine($"{Pokemon2.name} атакует");
                    Pokemon1.atack(Pokemon1, Pokemon2);
                    Pokemon2.atack(Pokemon2, Pokemon1);
                }
                else if (poke2move == 1)
                {
                    Console.WriteLine($"{Pokemon2.name} защищается");
                    Pokemon2.protect(Pokemon1, Pokemon2);
                }
                else if (poke2move == 2)
                {
                    Console.WriteLine($"{Pokemon2.name} уклоняется");
                    Pokemon2.dodge(Pokemon2, Pokemon1);
                }
                Console.WriteLine($"Здоровье {Pokemon1.name}: {Pokemon1.hp} ");
                Console.WriteLine($"Здоровье {Pokemon2.name}: {Pokemon2.hp} ");
                Thread.Sleep(sleep);
            }
            if (doing == 1)
            {
                Console.WriteLine($"{Pokemon1.name} защищается");
                int poke2move = random.Next(0, 2);
                if (poke2move == 0)
                {
                    Console.WriteLine($"{Pokemon2.name} атакует");
                    Pokemon1.protect(Pokemon2, Pokemon1);
                }
                else if (poke2move == 1)
                {
                    Console.WriteLine($"{Pokemon2.name} защищается");
                    Console.WriteLine("Ничего не произошло");
                }
                else if (poke2move == 2)
                {
                    Console.WriteLine($"{Pokemon2.name} уклоняется");
                    Console.WriteLine("Ничего не произошло");
                }
                Console.WriteLine($"Здоровье {Pokemon1.name}: {Pokemon1.hp} ");
                Console.WriteLine($"Здоровье {Pokemon2.name}: {Pokemon2.hp} ");
                Thread.Sleep(sleep);
            }
            if (doing == 2)
            {
                Console.WriteLine($"{Pokemon1.name} уклоняется");
                int poke2move = random.Next(0, 2);
                if (poke2move == 0)
                {
                    Console.WriteLine($"{Pokemon2.name} атакует");
                    Pokemon1.dodge(Pokemon1, Pokemon2);
                }
                else if (poke2move == 1)
                {
                    Console.WriteLine($"{Pokemon2.name} защищается");
                    Console.WriteLine("Ничего не произошло");
                }
                else if (poke2move == 2)
                {
                    Console.WriteLine($"{Pokemon2.name} уклоняется");
                    Console.WriteLine("Ничего не произошло");
                }
                Console.WriteLine($"Здоровье {Pokemon1.name}: {Pokemon1.hp}");
                Console.WriteLine($"Здоровье {Pokemon2.name}: {Pokemon2.hp} ");
                Thread.Sleep(sleep);
            }
        }
    }
    internal class PoketMon
    {
        public string name;
        public int atk;
        public int def;
        public int hp;
        public int agil;

        public void atack(PoketMon atacker,PoketMon defender)
        {
           defender.hp = defender.hp - atacker.atk;   
        }
        public void protect(PoketMon atacker, PoketMon defender)
        {
            defender.hp = defender.hp - (1 / (defender.def - atacker.atk) + 1);
        }
        public void dodge(PoketMon doger, PoketMon atacker)
        {
            if (doger.agil / atacker.agil > 2)
            {
                doger.hp = doger.hp;
            }
            else
            {
                doger.hp = doger.hp - atacker.atk;
            }
        }

    }
}