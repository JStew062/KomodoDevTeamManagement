using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeamManagement
{
    public class Developers
    {
        internal static int devid;

        //internal static object devid;

        public int DevID { get; set; }

        public string DevLN { get; set; }

        public string DevFN { get; set; }

        public bool Pluralsight { get; set; }

        public string TeamAssignment { get; set; }

        //Constructor Empty
        public Developers() { }

        //Constructor Full
        public Developers(int devid, string devln, string devfn, bool pluralsight, string teamassignment)
            
        {
            DevID = devid;
            DevLN = devln;
            DevFN = devfn;
            Pluralsight = pluralsight;
            TeamAssignment = teamassignment;
        }

    }    
}
