using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoRepo
{
    public class TeamRepo
    {
        private List<Team> _teamList = new List<Team>();

        //create
        public void AddTeamToList(Team content)
        {
            _teamList.Add(content);
        }
        //read
        public List<Team> GetTeamList()
        {
            return _teamList;
        }

        public string GetTeamByDevID(int devID)
        {
            foreach(Team item in _teamList)
                if (item.DevId.Contains(devID))
                {
                    return (item.TeamName + " ID: " + item.TeamId);

                }
            return null;
           
        }
        //update
        public bool UpdtTeamName(int teamId, Team newContent)
        {
            //find the team

            Team oldContent = GetTeamById(teamId);

            if (oldContent != null)
            {
                oldContent.TeamName = newContent.TeamName;
                return true;
            }
            return false;


        }

        public bool AddDevToTeam(int devID, int teamID)
        {
            Team content = GetTeamById(teamID);

            if (content == null)
            {
                return false;
            }

            int initCount = content.DevId.Count;
            content.DevId.Add(devID);
            if(initCount < content.DevId.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //delete methods
        public bool DeleteTeam(int teamid)
        {
            //find the team
            Team content = GetTeamById(teamid);

            if (content == null)
            {
                return false;
            }
            int initCount = _teamList.Count;
            _teamList.Remove(content);

            if (initCount > _teamList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveDevFromTeam(int devID, int teamID)
        {
            Team content = GetTeamById(teamID);

            
            if (content == null)
            {
                return false;
            }
            int initCount = content.DevId.Count;
            content.DevId.Remove(devID);
            if(initCount > content.DevId.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //helper method

        public Team GetTeamById(int id)
        {
            foreach (Team content in _teamList)
            {
                if (content.TeamId == id)
                {
                    return content;
                }

            }
            return null;
        }

    }
}
