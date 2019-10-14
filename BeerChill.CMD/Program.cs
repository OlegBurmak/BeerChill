using BeerChill.BL.Controller;
using System;

namespace BeerChill.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите имя пользователя: ");
            var userName = Console.ReadLine();

            var userController = new UserController(userName);
            if (userController.IsNewUser)
            {

                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();

                var birthDate = ParseValue<DateTime>("Введите дату рождения (дд.мм.гг): ","Неверный формат даты!");

                var weight = ParseValue<int>("Введите вес: ", "Неверный формат веса!");

                var height = ParseValue<int>("Введите рост: ", "Неверный формат роста!");


                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadKey();
        }

        private static T ParseValue<T>(string writeStr, string errorStr)
        {

            while (true)
            {
                Console.Write(writeStr);
                try
                {
                    var parsedValue = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    return parsedValue;
                }
                catch
                {
                    Console.WriteLine(errorStr);
                }
            }
        }
    }
}
