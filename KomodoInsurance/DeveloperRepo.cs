using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class DeveloperRepo
    {
        private List<Developer> _devList = new List<Developer>();

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

        public bool updateDev(int devId, Developer newDev)
        {
            //find the dev record
            Developer oldDev = GetDevByID(devId);
            //Update the content
            if(oldDev != null)
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
