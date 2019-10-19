using BeerChill.BL.Controller;
using BeerChill.BL.Model;
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
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                CreateNewUser(userController);
            }

            Console.WriteLine(userController.CurrentUser);


            Console.WriteLine("E - добавить прием пищи.");

            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.E :
                    EnterEating(eatingController);
                    foreach(var item in eatingController.UserEating.Foods)
                    {
                        Console.WriteLine($"{item.Key}, {item.Value}");
                    }
                    break;
            }

            Console.ReadKey();
        }


        private static void EnterEating(EatingController eatingController)
        {
            Console.Write("Введите название продукта: ");
            var foodName = Console.ReadLine() ?? "default";
            var calories = ParseValue<double>("Каллорийность за 100 грамм: ", "Неверный формат каллорийности!");
            var proteins = ParseValue<double>("Белки: ", "Неверный формат белков!");
            var fats = ParseValue<double>("Жиры: ", "Неверный формат жиров!");
            var carbohydrates = ParseValue<double>("Углеводы: ", "Неверный формат углеводов!");

            var product = new Food(foodName, calories, proteins, fats, carbohydrates);

            var quantity = ParseValue<double>("Введите размер порции в граммах: ", "Неверный формат размера порции!");

            eatingController.AddEating(product, quantity);
        }

        private static void CreateNewUser(UserController userController)
        {
            Console.Write("Введите пол: ");
            var gender = Console.ReadLine();

            var birthDate = ParseValue<DateTime>("Введите дату рождения (дд.мм.гг): ", "Неверный формат даты!");

            var weight = ParseValue<int>("Введите вес: ", "Неверный формат веса!");

            var height = ParseValue<int>("Введите рост: ", "Неверный формат роста!");


            userController.SetNewUserData(gender, birthDate, weight, height);
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
