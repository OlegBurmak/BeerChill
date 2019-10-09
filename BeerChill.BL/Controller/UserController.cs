using BeerChill.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BeerChill.BL.Controller
{
    /// <summary>
    /// Конструктор пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, DateTime userBirth, string genderName, int weight, int height)
        {
            var gender = new Gender(genderName);
            this.User = new User(userName, userBirth, gender, weight, height);
        }
        /// <summary>
        /// Загрузить данные пользователя.
        /// </summary>
        /// <returns>Пользователь приложения.</returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                var user = formatter.Deserialize(fs) as User;
                if (user != null)
                {
                    this.User = user;
                }

                // TODO: Что-то сделать если пользователь не найден.
            }
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

    }
}
