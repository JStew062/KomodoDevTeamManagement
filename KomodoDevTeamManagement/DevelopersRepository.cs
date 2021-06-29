using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeamManagement
{
    public class DevelopersRepository
    {
        //FakeDatabase
        protected readonly List<Developers> _developersContentDirectory = new List<Developers>();

        //CRUD
        //Create
        public bool AddContentToDirectory(Developers newContent)
        {
            int startingCount = _developersContentDirectory.Count;
            _developersContentDirectory.Add(newContent);
            bool wasAdded = (_developersContentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<Developers> GetContents()
        {
            return _developersContentDirectory;
        }
        public Developers GetContentByDevID(int devid)
        {
            //Get the directory
            //Sort through all the items using DevID to find a match
            foreach (Developers content in _developersContentDirectory)
            {
                if (content.DevID == Developers.devid) 
                {
                    return content;
                }
            }
            return null;
            //I want to return streaming content that matches DevID.
        }
        //Update
        public bool UpdateExistingContent(int originalDevID, Developers newContent)
        {
            Developers oldContent = GetContentByDevID(originalDevID);
            if (oldContent != null)
            {
                oldContent.DevID = newContent.DevID;
                oldContent.DevLN = newContent.DevLN;
                oldContent.DevFN = newContent.DevFN;
                oldContent.Pluralsight = newContent.Pluralsight;
                oldContent.TeamAssignment = newContent.TeamAssignment;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool DeleteExistingContent(Developers existingContent)
        {
            bool deleteResult = _developersContentDirectory.Remove(existingContent);
            return deleteResult;
        }

    }

}

