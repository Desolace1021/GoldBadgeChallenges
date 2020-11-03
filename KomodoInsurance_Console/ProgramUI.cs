using KomodoInsurance_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Console
{
    public class ProgramUI
    {


        private readonly KomodoBadgeRepo _badgeRepo = new KomodoBadgeRepo();




        public void RunMenu()
        {
            Console.Clear();

            Console.Write("1. Add a badge\n");
            Console.Write("2. Edit a badge\n");
            Console.Write("3. List all badges\n");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();
                List<string> newDoorName = new List<string>();
                Console.Write("What is the number on the badge: ");
                string idBadge = Console.ReadLine();
                Console.Write("List a door that it needs access to: ");
                string doorName = Console.ReadLine();
                newDoorName.Add(doorName);
                bool isTrue = true;
                while (isTrue)
                {
                    Console.Write("Any other doors(y/n)? ");
                    string yesOrNo = Console.ReadLine();
                    if (yesOrNo == "y")
                    {
                        Console.Write("List a door that needs access : ");
                        string anotherDoorName = Console.ReadLine();
                        newDoorName.Add(anotherDoorName);
                    }
                    else if (yesOrNo == "n")
                    {
                        _badgeRepo.MakeBadge(Convert.ToInt32(idBadge), newDoorName);
                        isTrue = false;
                    }
                    else
                    {
                        Console.WriteLine("This is not a valid selection.");
                        Console.ReadKey();
                    }
                }

            }
            else if (input == "2")
            {
                Console.Clear();
                Console.Write("What is the badge number to update? ");
                string idBadge = Console.ReadLine();
                List<string> accessDoor = _badgeRepo.GetDoor(Convert.ToInt32(idBadge));
                Console.WriteLine(idBadge + " has access to doors ");
                foreach (string door in accessDoor)
                {
                    Console.WriteLine(door);
                }
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Remove a door");
                Console.WriteLine("2. Add a door");
                input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Write("Which door would you like to remove? ");
                    string doorName = Console.ReadLine();
                    _badgeRepo.DeleteDoorsOnBadge(Convert.ToInt32(idBadge), doorName);
                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter the new door: ");
                    string newDoorName = Console.ReadLine();
                    _badgeRepo.UpdateDoor(Convert.ToInt32(idBadge), newDoorName);
                    bool isTrue = true;
                    while (isTrue)
                    {
                        Console.Write("Any other doors(y/n)? ");
                        string yesOrNo = Console.ReadLine();
                        if (yesOrNo == "y")
                        {
                            Console.Write("List a door that needs access : ");
                            string anotherDoorName = Console.ReadLine();
                            _badgeRepo.UpdateDoor(Convert.ToInt32(idBadge), anotherDoorName);
                        }
                        else if (yesOrNo == "n")
                        {
                            isTrue = false;
                        }
                        else
                        {
                            Console.WriteLine("This is not a valid selection.");
                            Console.ReadKey();
                        }
                    }

                }
                else
                {
                    Console.WriteLine("This is not a valid selection.");
                    Console.ReadKey();
                }
            }
        }
    }
}


