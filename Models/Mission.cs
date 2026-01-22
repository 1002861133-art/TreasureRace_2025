using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureRace_2025.Models
{
    public class Mission
    {
        private int missionCode; // קוד משימה  )
        private string missionName;//	שם/תיאור המשימה  מטיפוס מחרוזת.
        private string missionPlace;//	מיקום מטיפוס מחרוזת.
        private string goodAnswer;//	תשובה נכונה
        private int missionPoint;//	ניקוד

        public Mission(int missionCode, string missionName, string missionPlace, string goodAnswer, int missionPoint)
        {
            this.missionCode = missionCode;
            this.missionName = missionName;
            this.missionPlace = missionPlace;
            this.goodAnswer = goodAnswer;
            this.missionPoint = missionPoint;
        }
        public int GetCode() { return missionCode; }
        public string GetName() { return missionName; }
        public string GetPlace() { return missionPlace; }
        public string GetGoodAnswer() { return goodAnswer; }
        public int GetPoint() { return missionPoint; }
        public void SetPoint(int newPoint) { this.missionPoint = newPoint; }


        public override string ToString()
        {
            return $"missionCode: {missionCode}, missionName: {missionName}, missionPlace:{missionPlace}, goodAnswer:{goodAnswer}, missionPoint:{missionPoint}";
        }
    }
}

