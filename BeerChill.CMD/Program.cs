using BeerChill.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerChill.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите имя пользователя: ");
            var userName = Console.ReadLine();

            Console.WriteLine("Введите дату рождения(дд.мм.гг): ");
            DateTime userBirthday;
            if (DateTime.TryParse(Console.ReadLine(), out userBirthday))
            {

            }
            else
            {
                Console.WriteLine("Неверный формат даты");
            }

            Console.WriteLine("Укажите ваш пол: ");
            var genderName = Console.ReadLine();

            Console.WriteLine("Укажите ваш рост: ");
            int userHeight;
            int.TryParse(Console.ReadLine(), out userHeight);

            Console.WriteLine("Укажите ваш вес: ");
            int userWeight;
            int.TryParse(Console.ReadLine(), out userWeight);

            var userController = new UserController(userName, userBirthday, genderName, userWeight, userHeight);
            userController.Save();

        }
    }
}
