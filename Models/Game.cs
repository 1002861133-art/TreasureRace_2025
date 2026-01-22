using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureRace_2025.Models
{
    public class Game
    {
        private Group groupName;
        private DateTime gameDate; // dd/mm/yyyy
        public Queue<int> missionsDone;
        private int numOfMissions;
        private int totalPoints;
        static public Game instance;

        //private int gameCode;
        // private int minutesLeft;

        public Game(Group groupName)
        {
            instance = this;
            this.groupName = groupName;
            this.gameDate = DateTime.Today;
            this.missionsDone = new Queue<int>();
            this.numOfMissions = 0;
            this.totalPoints = 0;

        }
        public int GetTotalPoints()
        {
            return totalPoints;
        }
        public void AddPoints(int points)
        {
            this.totalPoints += points;
        }



    }
}

