using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoRepo
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _devList = new List<Developer>();

        //create

        public void AddDevToList(Developer content)
        {
            _devList.Add(content);
        }

        //Read

        public List<Developer> GetDevList()
        {
            return _devList;
        }

        //Update method

        public bool UpdateDev(int devId, Developer newDev)
        {
            //find the dev record
            Developer oldDev = GetDevByID(devId);
            //Update the content

            
            if(oldDev != null) //if a DevID is updated there needs to be a method in Program UI to update the Team objects.
            {
                oldDev.DevID = newDev.DevID;
                oldDev.LastName = newDev.LastName;
                oldDev.FirstName = newDev.FirstName;
                return true;
             }
            return false;
        }

           //helper method

        public Developer GetDevByID(int id)
        {
            foreach(Developer content in _devList)
            {
                if (content.DevID == id)
                    return content;
            }

            return null;
        }
    }
}
