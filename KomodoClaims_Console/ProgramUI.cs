using KomodoClaimsRepo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Console
{
    class ProgramUI
    {
        private KomodoClaims_Repo _repo = new KomodoClaims_Repo();

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
                    "1. Show Claims\n" +
                    "2. Next Claim\n" +
                    "3. Add new Claim\n" +
                    "4.Exit\n");


                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        ShowAllClaims();
                        break;
                    case "2":

                        ShowNextClaim();
                        break;
                    case "3":

                        CreateNewClaim();
                        break;

                    case "4":

                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }


            }
            void ShowAllClaims()
            {
                Console.Clear();

                Queue<ClaimsMenu> listOfContent = _repo.Getitems();

                foreach (ClaimsMenu content in listOfContent)
                {
                    DisplayItems(content);
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
        private void DisplayItems(ClaimsMenu content)

        {
            Console.WriteLine($"ClaimID: {content.ClaimID}");
            Console.WriteLine($"Type: {content.Type}");
            Console.WriteLine($"Description: {content.Description}");
            Console.WriteLine($"Amount: {content.Amount}");
            Console.WriteLine($"DateOfAccident: {content.DateOfAccident}");
            Console.WriteLine($"DateOfClaim: {content.DateOfCLaim}");
            Console.WriteLine($"IsValid: {content.IsValid}");

        }
        private void ShowNextClaim()
        {
            Queue<ClaimsMenu> listOfContent = _repo.Getitems(); // Queue to work from

            Console.WriteLine($"ClaimID: {listOfContent.Peek().ClaimID}");
            Console.WriteLine($"Type: {listOfContent.Peek().Type}");
            Console.WriteLine($"Description: {listOfContent.Peek().Description}");
            Console.WriteLine($"Amount: {listOfContent.Peek().Amount}");
            Console.WriteLine($"DateOfAccident: {listOfContent.Peek().DateOfAccident}");
            Console.WriteLine($"DateOfClaim: {listOfContent.Peek().DateOfCLaim}");
            Console.WriteLine($"IsValid: {listOfContent.Peek().IsValid}");
            bool isrunning = true;
            while(isrunning)
            {
                Console.Write("Do you want to deal with this claim now..(y/n)? ");
                string yesOrNo = Console.ReadLine();
                if (yesOrNo == "y")
                {
                    
                    listOfContent.Dequeue();
                }
                else if (yesOrNo == "n")
                {
                    listOfContent.Dequeue();
                }

            }


        }



        private void CreateNewClaim()
        {
            Console.Clear();

            ClaimsMenu newItem = new ClaimsMenu();

            Console.WriteLine("Please enter a ClaimID..");
            newItem.ClaimID = Console.ReadLine();

            Console.WriteLine("Please Enter Claim Type..");
            newItem.Type = Console.ReadLine();

            Console.WriteLine("Please Enter a Description..");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("Please Enter Amount");
            string amountAsString = Console.ReadLine();
            decimal amountDecimal = decimal.Parse(amountAsString);
            newItem.Amount = amountDecimal;

            Console.WriteLine("Please Enter the Date of Accident number.");
            newItem.DateOfAccident = Console.ReadLine();

            Console.WriteLine("Please Enter Date Of Claim.");
            newItem.DateOfCLaim = Console.ReadLine();

            Console.WriteLine("Please verify Claim is Valid.");
            newItem.IsValid = Console.ReadLine();
            Console.WriteLine("Press Any key to continue..");
            Console.ReadKey();


            ////bool stopRunning = false;
            ////while (!stopRunning)
            ////{


            ////   // string  = Console.ReadLine();







            ////}
            bool wasAdded = _repo.AddClaimToDirectory(newItem);
            if (wasAdded == true)
            {
                Console.WriteLine("Your changes were successful!...");
            }
            else
            {
                Console.WriteLine("Uhoh something went wrong...");
            }
        }
    }
}



