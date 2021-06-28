using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeamManagement
{
    public class DevelopTeamRepository
    {
        //private static readonly List<DeveloperTeams> _developerTeams = new List<DeveloperTeams>();

        //FakeDatabase
        protected readonly List<DeveloperTeams> _developerTeams = new List<DeveloperTeams>();

        //CRUD
        //Create
        public bool AddContentToDirectory(DeveloperTeams newContent)
        {
            int startingCount = _developerTeams.Count;
            _developerTeams.Add(newContent);
            bool wasAdded = (_developerTeams.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<DeveloperTeams> GetContents()
        {
            return _developerTeams;
        }
        public DeveloperTeams GetContentByDevTeamID(int devteamid)
        {
            //Get the directory
            //Sort through all the items using DevTeamID to find a match
            foreach (DeveloperTeams content in _developerTeams)
            {
                if (content.DevTeamID == devteamid)
                {
                    return content;
                }
            }
            return null;
            //I want to return streaming content that matches DevID.
        }
        //Update
        public bool UpdateExistingContent(int originalDevTeamID, DeveloperTeams newContent)
        {
            DeveloperTeams oldContent = GetContentByDevTeamID(originalDevTeamID);
            if (oldContent != null)
            {
                oldContent.DevTeamID = newContent.DevTeamID;
                oldContent.DevTeamName = newContent.DevTeamName;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool DeleteExistingContent(DeveloperTeams existingContent)
        {
            bool deleteResult = _developerTeams.Remove(existingContent);
            return deleteResult;
        }

    }

}
