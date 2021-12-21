using System;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero("Лучник");
            Console.WriteLine(hero.Name);
            hero.Name = "Арбалетчик";
            Console.WriteLine(hero.Name);

            //Но обращаться к hero.Level или hero.MoveSpeed мы не можем из-за уровня их защиты

            Creep creep = new Creep();
            creep.HP = 20;
            creep.Mana = 15;
            creep.MoveSpeed = 0;
            creep.MoveSpeed = 7;

            Console.WriteLine($"Creep: {creep.HP} HP {creep.Mana} Mana {creep.MoveSpeed} MoveSpeed");

        }
    }

    //Инкапсуляция
    //это скрытие реализации объекта от конечного пользователя, проще говоря public, private, protected
    //есть ещё internal и protected internal, но мы их не проходили

   public class Hero
    {
        //public – доступ к члену возможен из любого места одной сборки, либо из другой сборки, на которую есть ссылка
        public string Name;

        //private – доступ к члену возможен только внутри класса;
        private int Level;

        //protected – доступ к члену возможен только внутри класса, либо в классе-наследнике(при наследовании);
        protected int MoveSpeed;

        public Hero(string Name)
        {
            this.Name = Name;
            Level = 1;
            MoveSpeed = 50;
        }
    }

    public class Сourier : Hero
    {
        //Класс для лощади в нем мы можем обращаться только к Name и MoveSpeed из-за их уровня защиты
        //НО САМОЕ ВАЖНОЕ это не значит, что Mount не содержит в себе Level, он в нем есть, только мы до него не достучимся
        public Сourier(string Name) : base (Name)
        {
            MoveSpeed += MoveSpeed/2;
        }
    }

    //Часто бывает такое, что тебе нужно вывести private или protected переменную
    //Для этого есть get и set, первый дает возможность смотреть что внутри переменной, а второй передавать ей значение

    public class Creep
    {
        //Для public переменных get set бесполезен, так как они сами по себе доступны на любых уровнях
        public int HP;

        private int _mana;
        public int Mana
        {
            get
            {
                return _mana;    // возвращаем значение свойства
            }
            set
            {
                _mana = value;   // устанавливаем новое значение свойства
            }
        }

        protected int _moveSpeed;
        public int MoveSpeed
        {
            set
            {
                if (value <= 0)
                    Console.WriteLine($"Скорость передвижения не может быть меньше 0 \nВы присвоили скорость {value}");   //можно и условия в них задавать
                else
                    _moveSpeed = value;
            }
            get { return _moveSpeed; }
        }
    }

    //Типо защита данных приложения это очень важная часть и бла-бла-бла
}
