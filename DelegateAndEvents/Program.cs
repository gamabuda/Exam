//Делегаты - это полная ****, если в двух словах это просто перменная хранящая в себе метод
//Вот и совокупляйся с этим термином.
//Для дурилок* читать нотацию в конце
using System;

namespace DelegateAndEvents
{
    //Сам делегат может объявляться, как внутри любого класса, метода так и снаружи
    //Главное чтобы параметы делегата(то что в скобках) совпадали с теми методами, которые вы хотите ему присвоить
    //Ниже тип делегата
    delegate int MyDelegate(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            //Экземпляр делегата можно объявить:
            var method = new MyDelegate(Multiply); /*так*/
            MyDelegate method2 = Multiply; /*или так*/

            Account acc = new Account(100);
            acc.Notify += DisplayMessage;   // Добавляем обработчик для события Notify
            acc.Put(20);    // добавляем на счет 20
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            acc.Take(70);   // пытаемся снять со счета 70
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            acc.Take(180);  // пытаемся снять со счета 180
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            Console.Read();
        }

        static int Multiply(int x, int y)
        {
            return x * y;
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    //Оставлю ссылку на метанит, если что
    //https://metanit.com/sharp/tutorial/3.14.php

    public class Account
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;              // 1.Определение события
        public Account(int sum)
        {
            Sum = sum;
        }
        public int Sum { get; private set; }
        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke($"На счет поступило: {sum}");   // 2.Вызов события 
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke($"Со счета снято: {sum}");   // 2.Вызов события
            }
            else
            {
                Notify?.Invoke($"Недостаточно денег на счете. Текущий баланс: {Sum}"); ;
            }
        }
    }
}
//*Для дурилок.
//Привет, Марсель, я ждал тебя, сейчас все объясню.
//Если обычная переменная выглядит как-то так: int a = 1 или так string s = "hi"
//То она хранит в себе в первом случае численное значение, во втором строковое и только это
//Делегат это переменная которая хранит в себе метод или функцию, например функция:
//public void SayHello()
//{
//    Console.WriteLine("Hi");
//}
//Может хранится в какой-нибудь переменной с помощью делегата
//Так же полезно знать, что "=>" называют лямбдой часто используют с делегатами
//Честно, с лямбдой ничего не понятно, спасибо, что нас этому научили в техникуме
//Вот сухой термин с интернета: Лямбда-выражение используется для создания анонимной функции
//Думаю может это спросить