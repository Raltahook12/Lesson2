

namespace Lesson4_HW
{
    internal class Rnd
    {
        public static Random rnd = new Random();
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Entity> entitys = ListGenerator();
            List<Entity> bufferList = BuffersGenerator(entitys);
            Battle(bufferList,entitys);
         
            /*foreach(Entity e in entitys)
            {
                Console.WriteLine($"{e.Health} + {e.Age} + {e.MaxAge}");
                Thread.Sleep(500);
            }*/
            Console.WriteLine(entitys.Count);
            Thread.Sleep(500);

            bufferList = BuffersGenerator(entitys);
            EntitysMultiply(bufferList,entitys);

            Console.WriteLine(entitys.Count);
            Thread.Sleep(500);
            
            float sumHealth = 0;
            float sumAge = 0;
            float sumMaxAge = 0;
            float sumArmor = 0;
            float sumStrength = 0;
            
            foreach(Entity e in entitys) 
            { 
                sumHealth = sumHealth + e.Health;
                sumAge = sumAge + e.Age;
                sumArmor = sumArmor + e.Armor;
                sumMaxAge = sumMaxAge + e.MaxAge;
                sumStrength = sumStrength + e.Strenght;
            }
            
            sumStrength = sumStrength/entitys.Count;
            sumMaxAge = sumMaxAge/entitys.Count;
            sumHealth = sumHealth/entitys.Count;
            sumArmor = sumArmor/entitys.Count;
            sumAge = sumAge/entitys.Count;
            
            Console.WriteLine($"Средние характеристики новой популяции: \n Здоровье:{sumStrength} \n Возраст:{sumAge} \n Максимальный возраст:{sumMaxAge} \n Броня:{sumArmor} \n Сила: {sumStrength} ");
            Thread.Sleep(5000);
        }


        
        public static List<Entity> ListGenerator()
        {
            List<Entity> entitys = new List<Entity>();
            for (int i = 0; i < 100; i++)
            {
                float _health = Rnd.rnd.Next(25);
                float _age = Rnd.rnd.Next(1, 20);
                float _maxAge = Rnd.rnd.Next(1,40);
                float _strength = Rnd.rnd.Next(5, 10);
                float _armor = Rnd.rnd.Next(1, 10);

                Entity entity_ = new Entity(_health, _age, _maxAge, _strength, _armor);
                entitys.Add(entity_);
            }
            return entitys;
        }
        
        public static List<Entity> BuffersGenerator(List<Entity> entitys)
        {
            List<Entity> bufferList = new List<Entity>();

            foreach (Entity e in entitys)
            {
                bufferList.Add(e);
            }
            return bufferList;
        }
        
        static void Battle(List<Entity> list1,List<Entity> list2)
        {
            for (int i = 0; i < (list1.Count-1)/2; i++)
            {
                if (list1[i].Age / list1[i].MaxAge < 2) 
                {
                    list1[i + 50].Health = list1[i+50].Health - list1[i].Strenght * 2 + list1[i + 50].Armor; 
                }
                else
                { 
                  list1[i + 50].Health = list1[i+50].Health - list1[i].Strenght + list1[i + 50].Armor;   
                }
                if (list1[i+50].Age / list1[i+50].MaxAge < 2)
                {
                    list1[i].Health = list1[i].Health - list1[i + 50].Strenght * 2 + list1[i].Armor;
                }
                else
                { 
                     list1[i].Health = list1[i].Health - list1[i + 50].Strenght + list1[i].Armor;
                }
            }
            foreach (Entity e in list1)
            {
                if (e.Health == 0 || e.Age >= e.MaxAge)
                {
                    list2.Remove(e);
                }
            }
        }
        public static List<Entity> EntitysMultiply(List<Entity> buffer,List<Entity> entitys)
        {
            foreach(Entity e in buffer)
            { 
                float _health = Rnd.rnd.Next(Convert.ToInt32(0.8*e.Health),Convert.ToInt32(1.2*e.Health));
                float _age = Rnd.rnd.Next(Convert.ToInt32(0.8*e.Age),Convert.ToInt32(1.2*e.Age));
                float _maxAge = Rnd.rnd.Next(Convert.ToInt32(0.8*e.MaxAge),Convert.ToInt32(1.2*e.MaxAge));
                float _strength = Rnd.rnd.Next(Convert.ToInt32(0.8*e.Strenght),Convert.ToInt32(1.2*e.Strenght));
                float _armor = Rnd.rnd.Next(Convert.ToInt32(0.8*e.Armor), Convert.ToInt32(1.2*e.Armor));
                
                Entity entity_ = new Entity(_health, _age, _maxAge, _strength, _armor) { Health = _health, Age = _age, MaxAge = _maxAge, Strenght = _strength, Armor = _armor };
                entitys.Add(entity_);            
            }
            return entitys;

        }
    }


    internal class Entity
    {
        private float _health;
        public float Health
            {
            set
            {
                if (value >=0)
                {
                    _health = value;
                }
                else
                {
                    _health = 0;
                }
            }
            get
            {
                return _health; 
            }
        }

        public float Armor;

        private float _age;
        public float Age
        { 
            set
            {
                if (value >= 0 && value <= MaxAge)
                {
                    _age = value;
                }
            }
            get
            {
                return _age;
            }
        }


        public float MaxAge;

        public float Strenght;

        public Entity( float health, float age, float maxAge, float strenght, float armor)
        {
            _health = health;
            _age = age;
            MaxAge = maxAge;
            Strenght = strenght;
            Armor = armor;
        }

    }
}