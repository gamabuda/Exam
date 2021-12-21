using System;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            //Интерфейс
            Animal animal = new Animal("Панда", 200);
            animal.Move();

            Car car = new Car();
            car.Move();

            //Наследование
            Tiger tiger = new Tiger("Тигра");
            tiger.Roar();

            Hog hog = new Hog("Свинка");
            hog.Roar();
        }
    }

    //Интерфейс
    //Абстрактный класс наследуется, а интерфейс реализуется
    //Не может содержать в себе конструктор
    //В нем нельзя прописывать реализацию членов
    //Любой класс может реализовывать несколько интерфейсов
    //(Множественного наследования быть не может, во придурки что делают сами нам костыли разработали)

    //Cам интерфейс
    interface IMovable
    {
        int MaxSpeed { get; }

        void Move();
    }

    //Класс животное
    public class Animal : IMovable
    {
        public string Name;
        public int MaxSpeed { get; }

        public Animal(string name, int MaxSpeed)
        {
            this.Name = name;
            this.MaxSpeed = MaxSpeed;
        }

        public void Move()
        {
            Console.WriteLine($"{Name} бежит со скоростью {MaxSpeed}");
        }
    }

    //Класс машина
    public class Car : IMovable
    {
        public int MaxSpeed { get; }

        public Car()
        {
            MaxSpeed = 0;
        }

        public void Move()
        {
            Console.WriteLine($"Машина хасанит со скоростью {MaxSpeed}");
        }
    }

    //Далее пример с наследованием
    public abstract class WildAnimal
    {
        public string Name;

        public abstract void Roar();

        public WildAnimal(string Name)
        {
            this.Name = Name;
        }
    }

    public class Tiger : WildAnimal
    {
        public override void Roar()
        {
            Console.WriteLine($"{Name} рычит: Ррр!");
        }

        public Tiger(string Name): base (Name)
        { }
    }

    public class Hog : WildAnimal
    {
        public override void Roar()
        {
            Console.WriteLine($"{Name} хрюкает: Оньк-оньк!");
        }

        public Hog(string Name) : base(Name)
        { }
    }

    //Встал вопрос, когда юзать наследование, а когда интерфейс?
    //Абстрактный класс используют тогда, когда необходимо выделить некое
    //СЕМЕЙСТВО КЛАССОВ с общим функционалом. 
    //Например: Дикие животные из наследуются кабаны, тигры, носороги и так далее.
    //А интерфейсы юзать, когда у вас нет жесткой связи у наследников, но есть общее поведение.
    //Например: Машина и Животное оба имеют название, оба передвигаются.

    //НО НИКТО НЕ ГОВОРИЛ, что ты не сможешь использовать интерфейсы в наследовательных классах
    //Эта фигня может переплетаться между собой создавая мозголомные пазлы
}
