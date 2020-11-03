using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repo
{
    public class KomodoBadgeRepo
    {
        private Dictionary<int, List<String>> _badgeDirectory = new Dictionary<int, List<string>>();

        public bool MakeBadge(int badge, List<string> door)
        {
            int startingcount = _badgeDirectory.Count;

            _badgeDirectory.Add(badge, door);

            bool wasAdded = _badgeDirectory.Count == startingcount;

            return wasAdded;




        }

        public void UpdateDoor(int idBadge, string accessDoor)
        {
            List<string> current = GetDoor(idBadge);
            current.Add(accessDoor);
        }

        public List<string> GetDoor(int idBadge)
        {
            List<string> accessDoor = new List<String>();

            if (_badgeDirectory.TryGetValue(idBadge, out accessDoor))
            {
                return accessDoor;
            }
            else
            {
                return null;
            }
        }

        public void DeleteDoorsOnBadge(int idBadge, string accessDoor)
        {
            List<string> current = GetDoor(idBadge);
            current.Remove(accessDoor);
        }

        public Dictionary<int, List<string>> ShowBadgeAndDoors()
        {
            return _badgeDirectory;
        }
    }
}
