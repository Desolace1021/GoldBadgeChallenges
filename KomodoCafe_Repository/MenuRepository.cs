using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class MenuRepository
    {
        
        private List<Menu> _menuDirectory = new List<Menu>();

        public bool AdditemToDirectory(Menu items)
        {
            int startingCount = _menuDirectory.Count;

            _menuDirectory.Add(items);

            bool wasAdded = ( _menuDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Menu> Getitems()
        {
            return _menuDirectory;
        }

        public Menu GetItemName(string mealName)
        {
            foreach (Menu items in _menuDirectory)
            {
                if (items.MealName.ToLower() == mealName.ToLower())
                {
                    return items;
                }
            }
            return null;
        }
        public bool UpdateItems(string originalItem, Menu newItem)
        {
            Menu oldItems = GetItemName(originalItem);

            if (oldItems != null)
            {
                oldItems.MealName = newItem.MealName;
                oldItems.ListIngredients = newItem.ListIngredients;
                oldItems.MealDescription = newItem.MealDescription;
                oldItems.MealPrice = newItem.MealPrice;
                oldItems.MealNumber = newItem.MealNumber;
                
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteExistingItem(Menu existingItem)
        {
            bool deleteResult = _menuDirectory.Remove(existingItem);
            return deleteResult;
        }
    }
}
