using KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Console
{
    class ProgramUI
    {
        private MenuRepository _repo = new MenuRepository();
        public void Run()
        {
            Menu();


        }
        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. Show Menu Items\n" +
                    "2. List ingredients\n" +
                    "3. Add new Menu item\n" +
                    "4. Update existing Menu itemn\n" +
                    "5. Remove Menu item\n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        ShowAllMenu();
                        break;
                    case "2":

                        ShowIngredients();
                        break;
                    case "3":

                        CreateNewItems();
                        break;
                    case "4":

                        UpdateItems();
                        break;
                    case "5":

                        DeleteItems();
                        break;
                    case "6":

                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
                 void UpdateItems()
                {

                    Console.Clear();
                    Console.WriteLine("Enter the name of the item you'd like to update.");
                    string item = Console.ReadLine();

                    Menu oldItem = _repo.GetItemName(item);

                    if (oldItem == null)
                    {
                        Console.WriteLine("item not found, press any key to continue...");
                        Console.ReadKey();
                        return;
                    }

                    Menu newItem = new Menu(
                        oldItem.MealName,
                        oldItem.ListIngredients,
                        oldItem.MealDescription,
                        oldItem.MealPrice,
                        oldItem.MealNumber
                    );

                    Console.WriteLine("Which item would you like to update:\n" +
                            "1. MealName\n" +
                            "2. ListIngredients\n" +
                            "3. MealDescription\n" +
                            "4. MealPrice\n" +
                            "5. MealNumber\n" +
                            "6. Nevermind");

                    string selection = Console.ReadLine();
                    switch (selection)
                    {
                        case "1":
                            Console.WriteLine("Enter a new MealName");
                            string newItems = Console.ReadLine();
                            newItem.MealName = newItems;

                            bool wasSuccessful = _repo.UpdateItems(item, newItem);

                            if (wasSuccessful)
                            {
                                Console.WriteLine("Item successfully updated");
                            }
                            else
                            {
                                Console.WriteLine($"Error: Could not update {item}");
                            }
                            break;
                        default:
                            break;
                    }
                }

            }
             void ShowAllMenu()
            {
                Console.Clear();

                List<Menu> listOfContent = _repo.Getitems();

                foreach (Menu content in listOfContent)
                {
                    DisplayItems(content);
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
        private void DisplayItems(Menu content)
        {
            Console.WriteLine($"MealName: {content.MealName}");
            Console.WriteLine($"ListIngredients: {content.ListIngredients}");
            Console.WriteLine($"MealDescription: {content.MealDescription}");
            Console.WriteLine($"MealPrice: {content.MealPrice}");
            Console.WriteLine($"MealNumber: {content.MealNumber}");

        }
        private void CreateNewItems()
        {
            Console.Clear();

            Menu newItem = new Menu();

            Console.WriteLine("Please enter a MealName.");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Please Enter Ingredients.");
            newItem.ListIngredients = Console.ReadLine();

            Console.WriteLine("Please Enter a Description");
            newItem.MealDescription = Console.ReadLine();

            Console.WriteLine("Please Enter a Meal Price.");
            string mealPriceAsString = Console.ReadLine();
            double mealPriceDouble = double.Parse(mealPriceAsString);
            newItem.MealPrice = mealPriceDouble;

            Console.WriteLine("Please Enter the combo number.");
            string mealNumberAsString = Console.ReadLine();
            double mealNumberDouble = double.Parse(mealNumberAsString);
            newItem.MealNumber = mealNumberDouble;

            //String priceInput = Console.ReadLine();
            //int priceAsInt = int.Parse(priceInput);
            //newItem.MealNumber = (double)(MealNumber)priceAsInt;

            bool stopRunning = false;
            while (!stopRunning)
            {
                Console.WriteLine("Select Combo Number.");
                Console.WriteLine("Combo1");
                Console.WriteLine("combo2");
                Console.WriteLine("combo3");
                Console.WriteLine("combo4");
                Console.WriteLine("combo5");
                Console.WriteLine("combo6");
                Console.WriteLine("combo7");

                string mealNumber = Console.ReadLine();


                switch (mealNumber)
                {
                    case "1":
                        newItem.MealNumber = (double)MealNumber.combo1;
                        stopRunning = true;
                        break;
                    case "2":
                        newItem.MealNumber = (double)MealNumber.combo2;
                        stopRunning = true;
                        break;
                    case "3":
                        newItem.MealNumber = (double)MealNumber.combo3;
                        stopRunning = true;
                        break;
                    case "4":
                        newItem.MealNumber = (double)MealNumber.combo4;
                        stopRunning = true;
                        break;
                    case "5":
                        newItem.MealNumber = (double)MealNumber.combo5;
                        stopRunning = true;
                        break;
                    case "6":
                        newItem.MealNumber = (double)MealNumber.combo6;
                        stopRunning = true;
                        break;
                    case "7":
                        newItem.MealNumber = (double)MealNumber.combo7;
                        stopRunning = true;
                        break;
                    default:
                        Console.WriteLine("Please Enter Valid Option...");
                        stopRunning = false;
                        break;

                }


            }
            bool wasAdded = _repo.AdditemToDirectory(newItem);
            if (wasAdded == true)
            {
                Console.WriteLine("Your changes were successful!...");
            }
            else
            {
                Console.WriteLine("Uhoh something went wrong...");
            }


        }
        private void ShowIngredients()
        {
            //Console.Clear;

            Console.WriteLine("Enter Name of the Combo youd like...");
            string getItem = Console.ReadLine();

            Menu Item = _repo.GetItemName(getItem);

            if (getItem != null)
            {
                DisplayItems(Item);
            }
            else
            {
                Console.WriteLine("That does not exist..");
            }
            Console.ReadLine();


        }

        private void DeleteItems()
        {
            Console.WriteLine("Enter Item you would like to remove..");
            string itemToDelete = Console.ReadLine();

            Menu existingItem = _repo.GetItemName(itemToDelete);
            bool wasDeleted = _repo.DeleteExistingItem(existingItem);

            if (wasDeleted)
            {
                Console.WriteLine("Removed succesfully..");
            }
            else
            {
                Console.WriteLine("Oops Something went Wrong...");
            }
        }
    }


}
