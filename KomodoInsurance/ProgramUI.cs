using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    class ProgramUI
    {
        seedContent();
        bool isRunning = true;

        private readonly DeveloperRepo _devRepo = new DeveloperRepo();
        private readonly TeamRepo _teamRepo = new TeamRepo();
















        private void SeedTeamList()
        {
            List<int> DevIDs = new List<int>();
            int[] devIds = { 2001, 2002, 2003, 2004, 2005 };
            DevIDs.AddRange(devIds);
            Team Dev1 = new Team(1001, "Dev1", DevIDs); //All Ids
            DevIDs.Remove(2001);
            DevIDs.Remove(2002);
            Team Dev2 = new Team(1002, "Dev2", DevIDs);//2003, 2004, 2005
            DevIDs.Remove(2003);
            DevIDs.Remove(2004);
            DevIDs.Remove(2005);
            DevIDs.Add(2001);
            DevIDs.Add(2002);
            Team Dev3 = new Team(1003, "Dev3", DevIDs); // 2001, 2002
        }

        private void SeedDevList



    }


}
