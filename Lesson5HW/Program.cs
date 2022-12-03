using System.Runtime.CompilerServices;
using System.Threading;

namespace Lesson5HW
{
    internal class Randdom
    {
        public static Random rnd = new Random();
    }
    class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior(Randdom.rnd.Next(6, 15), Randdom.rnd.Next(2, 5));
            Archer archer = new Archer(Randdom.rnd.Next(6, 10), Randdom.rnd.Next(4, 7), Randdom.rnd.Next(10,30));
            Shielder shielder = new Shielder(Randdom.rnd.Next(8, 19), Randdom.rnd.Next(1, 4), Randdom.rnd.Next(1, 3));

            Console.WriteLine($"Броня щитоносца: {shielder.Armor}");
            battle(shielder, warrior);
            Console.ReadKey();

            Console.WriteLine($"Броня щитоносца: {shielder.Armor}");
            Console.WriteLine($"Уклонение лучника: {archer.DodheChanse}%");
            battle(shielder, archer);
            Console.ReadKey();

            Console.WriteLine($"Уклонение лучника: {archer.DodheChanse}%");
            battle(archer, warrior);
            Console.ReadKey();

        }
        static void battle( Character Chalenger1, Character Chalenger2)
        {
            int startHeatlh1 = Chalenger1.Health;
            int startHeatlh2 = Chalenger2.Health;
            Console.WriteLine($"{Chalenger1} {Chalenger2}");
            Console.WriteLine($"Здоровье: \n {Chalenger1.Health} {Chalenger2.Health}");
            Console.WriteLine($"Атака: \n {Chalenger1.Atack} {Chalenger2.Atack}");
            while (Chalenger1.Health != 0 && Chalenger2.Health != 0)
            {
                Chalenger1.Fight(Chalenger2);
                Chalenger2.Fight(Chalenger1);
                Console.WriteLine($"{Chalenger1.Health} {Chalenger2.Health}");
            }
            Chalenger1.Health = startHeatlh1;
            Chalenger2.Health = startHeatlh2;
        }
    }
    public abstract class Character
    {
        private int _health;

        public int Atack;

        public int Health { get { return _health; } set { if (value > 0) { _health = value; } else { _health = 0; } } }

        public virtual void Fight(Character DamageDealer)
        {

        }
        public virtual void TakeDamage(Character DamageDealer)
        {
            Health = Health - DamageDealer.Atack;
        }
        public Character(int health, int atack)
        { 
            Health = health;
            Atack = atack;
        }

    }
    public class Warrior : Character
    {
        public override void Fight(Character Aim)
        {
            Aim.TakeDamage(this);
        }
        public Warrior(int health,int atack) : base(health,atack)
    }
    public class Archer : Character
    {
        private int _dodgeChanse;
        public int DodheChanse { get { return _dodgeChanse; } set {_dodgeChanse = value; } }

        public override void TakeDamage(Character DamageDealer)
        {
            if (Randdom.rnd.Next(0, 100) < _dodgeChanse)
            {
                Console.WriteLine("Промах");
            }
            else
            {
                Health = Health - DamageDealer.Atack; ;
            }
        }

        public override void Fight(Character Aim)
        {
            Aim.TakeDamage(this);
        }

        public Archer(int health, int atack, int dodgeChanse) : base(health,atack)
        {
            _dodgeChanse = dodgeChanse;
        }
    }
    public class Shielder : Character
    {
        private int _armor;

        public int Armor { get { return _armor; } set {_armor = value; } }

        public override void TakeDamage(Character DamageDealer)
        {
            Health = Health + _armor - DamageDealer.Atack;
        }

        public override void Fight(Character Aim)
        {
            Aim.TakeDamage(this);
        }
        public Shielder(int health,int atack, int armor) : base(health,atack)
        { 
            _armor = armor;
        }
       
    }
}