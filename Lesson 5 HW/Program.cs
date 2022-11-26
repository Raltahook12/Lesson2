namespace Lesson_5_HW;

Random rnd = new Random();

class Program
{
    static void Main(string[] args)
    {
       
    }
}
public abstract class Character
{
    private int _health;
    
    public int Atack;

    public int Health { get { return _health; } set { _health = value; } };

    public virtual void Fight()
    {

    }
    public virtual void TakeDamage(Character DamageDealer)
    {
        Health = Health - DamageDealer.Atack;
    }
}
public class Warrior : Character
{
    public override void Fight(Character Aim)
    {
        Aim.TakeDamage(this);
    }
}
public class Archer : Character
{   
    private int _dodgeChanse;

    public override void ArcherTakeDamage(Character DamageDealer)
    {
        if(rnd > _dodgeChanse)
        { 
            Console.WriteLine("Промах")
        }
        else
        {
           Health = Health - DamageDealer.Atack;;
        }
    }
}
