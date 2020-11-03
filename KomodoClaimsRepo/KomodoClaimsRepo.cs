using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsRepo
{
    public class KomodoClaims_Repo
    {
        public Queue<ClaimsMenu> _claimDirectory = new Queue<ClaimsMenu>();

        public bool AddClaimToDirectory(ClaimsMenu  claims) 
        
        {
            
            int startingCount = _claimDirectory.Count;

                _claimDirectory.Enqueue(claims);

                bool wasAdded = (_claimDirectory.Count > startingCount +1) ? true : false;
                return wasAdded;
            
        }
        public Queue<ClaimsMenu> Getitems()
        {
            return _claimDirectory;
        }

        public ClaimsMenu GetItemName(string claimID)
        {
            foreach (ClaimsMenu claims in _claimDirectory)
            {
                if (claims.ClaimID.ToLower() == claimID.ToLower())
                {
                    return claims;
                }
            }
            return null;
        }


    }
}
