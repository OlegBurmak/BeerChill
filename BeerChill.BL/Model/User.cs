using System;

namespace BeerChill.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime Birthday { get; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Вес.
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public int Height { get; set; }


        public User(string name, DateTime birthDate, Gender gender): this(name,birthDate,gender,0,0)
        {
        }
        /// <summary>
        /// Создать нового пользователя 
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public User(string name, DateTime birthDate, Gender gender, int weight, int height)
        {
            #region Проверка на валидность данных
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Поле имя пользователя не должно быть пустым!", nameof(name));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Недопустимая дата рождения!", nameof(birthDate));
            }
            if(gender == null)
            {
                throw new ArgumentNullException("Пол не может быть равен null!", nameof(gender));
            }
            if(weight < 0)
            {
                throw new ArgumentException("Вес не может быть меньше 0!", nameof(weight));
            }
            if(height < 0)
            {
                throw new ArgumentException("Рост не может быть меньше 0!", nameof(height));
            }
            #endregion

            this.Name = name;
            this.Birthday = birthDate;
            this.Gender = gender;
            this.Weight = weight;
            this.Height = height;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
