using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeamManagement
{
    public class DeveloperTeams
    {
        internal static object devteamid;

        public int DevTeamID { get; set; }

        public string DevTeamName { get; set; }




        //Constructor Empty
        public DeveloperTeams() { }

        //Constructor Full
        public DeveloperTeams(int devteamid, string devteamname)
        {
            DevTeamID = devteamid;
            DevTeamName = devteamname;

        }
    }
}
