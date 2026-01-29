namespace TreasureRace_2025.Models
{
    public class Group
    {
        private string groupName;
        private string groupNum;
        private string[] players;
        private int numPlayers;
        private int points;

        public Group(string groupName, string groupNum, string[] players, int numPlayers)
        {
            this.groupName = groupName;
            this.groupNum = groupNum;
            this.players = players;
            this.numPlayers = numPlayers;
            this.points = 0;
        }
        public string GroupName() { return groupName; }
        public string GroupNum() { return groupNum; }


    }
}