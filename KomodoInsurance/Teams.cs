using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public List<int> DevId { get; set; }

        public Team() { }

        public Team(int teamID, string teamName, List<int>devID )
        {
            TeamId = teamID;
            TeamName = teamName;
            DevId = devID;
        }





        
     }
}
