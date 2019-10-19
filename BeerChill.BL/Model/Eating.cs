using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerChill.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {

        public DateTime Moment { get; }

        public Dictionary<Food, double> Foods { get; }

        public User User { get; }


        public Eating(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            }

            this.User = user;
            this.Foods = new Dictionary<Food, double>();
            this.Moment = DateTime.UtcNow;
        }


        public void AddProduct(Food food, double quantity)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if(product == null)
            {
                Foods.Add(food, quantity);
            }
            else
            {
                Foods[product] += quantity;
            }
        }

    }
}
