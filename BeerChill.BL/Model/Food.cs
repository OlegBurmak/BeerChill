using System;

namespace BeerChill.BL.Model
{
    /// <summary>
    /// Продукт.
    /// </summary>
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Название продукта.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Калорийость продукта за 100 грамм.
        /// </summary>
        public double Calories { get; }

        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }


        public Food(string name) : this(name, 0, 0, 0, 0){ }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            // TODO проверка

            this.Name = name;
            this.Calories = calories / 100.0;
            this.Proteins = proteins / 100.0;
            this.Fats = fats / 100.0;
            this.Carbohydrates = carbohydrates / 100.0;
        }


        public override string ToString()
        {
            return Name;
        }

    }
}
