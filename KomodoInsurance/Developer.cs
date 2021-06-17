using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoRepo
{//POCO
    public class Developer
    {
        public int DevID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public bool HasPluralSight { get; set; }


      


        public Developer() { }

        public Developer(int devId, string firstName, string lastName, bool pluralSight)
        {
            DevID = devId;
            FirstName = firstName;
            LastName = lastName;
            HasPluralSight = pluralSight;
        }


    }
} 



    


