using BeerChill.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace BeerChill.BL.Controller
{
    public class EatingController : ControllerBase
    {

        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";
        private readonly User user;

        public List<Food> Foods { get; }
        public Eating UserEating { get; }


        public EatingController(User user)
        {

            if(user == null)
            {
                throw new ArgumentNullException("Пользователь не может быть пустым!", nameof(user));
            }

            this.user = user;
            this.Foods = GetFoodsData();
            this.UserEating = GetEatingData();
        }


        public void AddEating(Food food, double quantity)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if(product == null)
            {
                Foods.Add(food);
                UserEating.AddProduct(food, quantity);
                SaveFoodData();
            }
            else
            {
                UserEating.AddProduct(product, quantity);
                SaveFoodData();
            }
        }

        private List<Food> GetFoodsData()
        {
           return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        private Eating GetEatingData()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(this.user);
        }

        private void SaveFoodData()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, UserEating);
        }

    }
}
