using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    class TeamRepo
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

        //Delete  Delete the Team -- this will require a method in the Progam UI to remove the team ID from the dev list

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
