namespace TreasureRace_2025.Models
{
    public class Game
    {
        private Group group;
        private DateTime gameDate; // dd/mm/yyyy
        public Queue<int> missionsDone;
        private int numOfMissions;
        private int totalPoints;
        static public Game instance;
        public Mission[] missions;
        private int index = 0;

        public Game(Group group)
        {
            AllMissions allMissions = new AllMissions();
            instance = this;
            this.group = group;
            this.gameDate = DateTime.Today;
            this.missionsDone = new Queue<int>();
            this.numOfMissions = 0;
            this.totalPoints = 0;
            int groupNum = int.Parse(this.group.GroupNum());
            
            this.missions = allMissions.Shuffle(new AllMissions().GetMissions(),groupNum);

        }
        public int GetTotalPoints()
        {
            return totalPoints;
        }
        public void AddPoints(int points)
        {
            this.totalPoints += points;
        }

        public void MoveToNextMissionIndex()
        {
            if (IsCompleted()) 
                return;
            if (index < GetMissionCount() - 1)
                index = index + 1;
        }

        public int GetIndex()
        {
            return index;
        }


        public int GetMissionCount()
        {
            return this.missions.Length;
        }

        public bool IsCompleted()
        {
            return GetIndex() == GetMissionCount();
        }

        public Mission GetCurrentMission()
        {
            return missions[index];
        }
    }
}

