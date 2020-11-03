using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsRepo
{
    public class ClaimsMenu
    {
        public string ClaimID { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public string DateOfAccident { get; set; }

        public string DateOfCLaim { get; set; }

        public string IsValid { get; set; }



        public ClaimsMenu() { }

        public ClaimsMenu(string claimID, string type, string description, decimal amount, string dateOfAccident, string dateOfClaim, string isValid)
        {
            ClaimID = claimID;
            Type = type;
            Description = description;
            Amount = amount;
            DateOfAccident = dateOfAccident;
            DateOfCLaim = dateOfClaim;
            IsValid = isValid;
        }
        



    }
}

