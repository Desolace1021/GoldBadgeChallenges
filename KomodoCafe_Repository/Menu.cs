using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class Menu
    {
        public string MealName { get; set; }

        public string ListIngredients { get; set; }
        public string MealDescription { get; set; }
        public double MealPrice { get; set; }
        public double MealNumber { get; set; }

        




        public Menu() { }

        public Menu(string mealName, string listIngredients, string mealDescription, double mealPrice, double mealNumber)
        {
            MealName = mealName;
            ListIngredients = listIngredients;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
            MealNumber = mealNumber;
        }

    }

    public enum MealNumber
    {
        combo1=1,
        combo2,
        combo3,
        combo4,
        combo5,
        combo6,
        combo7

    }
}
