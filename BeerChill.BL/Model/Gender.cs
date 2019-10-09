using System;

namespace BeerChill.BL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Новый пол.
        /// </summary>
        /// <param name="name"> Имя пола.</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Значение этого поля не может быть пустым!",nameof(name));
            }

            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
