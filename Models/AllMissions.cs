using System;
using System.Collections.Generic;

namespace TreasureRace_2025.Models
{
    public class AllMissions
    {
        private Mission[] missions;

        public AllMissions()
        {
            this.missions = new Mission[20];

            //-- שאלות כמיה
            missions[0] = new Mission(1, "משימות 1-3 כימיה", "מעבדת כימיה", "123", 30 , 15);

            //-- שאלות מדעי המחשב
            missions[1] = new Mission(2, "מדעי המחשב", "יש להגיע לחדר שמתחתיו יש רעש של תופים ולספור 3 דלתות כניסה עד הכניסה לחדר", "הנדסת תוכנה", 20 , 15);
            missions[2] = new Mission(2, "מדעי המחשב", "תגיעו למטבחון שנמצא ליד חדר מחשבים", "מחכים לכם", 10, 8 );

            //-- שאלות ביולוגיה
            missions[3] = new Mission(4, "ביו-טכנולוגיה -אטום", "תגיעו למעבדת ביוטכולוגיה", "3", 15, 8);
            missions[4] = new Mission(3, "ביו-טכנולוגיה-PH", "תגיעו למעבדת ביוטכולוגיה", "19", 15, 8);

            //-- שאלות פיזיקה - ממתינים

            //-- שאלות אחרת מדעי המחשב של VIVI
            missions[5] = new Mission(3, "Result for num=5183", "Mission_3", "3518", 20, 10);
            missions[6] = new Mission(6, "98% Mistake", "Mission_6", "15", 12,10);
            missions[7] = new Mission(7, "Genious only", "Mission_7", "26", 10, 10);
            missions[8] = new Mission(8, "Result with num=8", "Mission_8", "40320", 20, 10);
            missions[9] = new Mission(9, "Training", "Mission_9", "11", 14, 10);
            missions[10] = new Mission(10, "1_true/0_false", "Mission_10", "0", 15, 10);

            missions[11] = new Mission(11, "num=6791", "Mission_11", "1976", 20, 10);
            missions[12] = new Mission(12, "Weight", "Mission_12", "27", 12, 10);
            missions[13] = new Mission(13, "Hats A/B/C/D", "Mission_13", "C", 20, 10);
            missions[14] = new Mission(14, "Worms", "Mission_14", "15", 10, 10);
            missions[15] = new Mission(15, "Height", "Mission_15", "150", 14, 10);
            missions[16] = new Mission(16, "I lied yesterday", "Computer Room", "Wednesday", 10, 10);
            missions[17] = new Mission(17, "Spider", "Mission_17", "97", 10, 10);
            missions[18] = new Mission(18, "Pishpeshouk", "Mission_18", "15", 10, 10);
            missions[19] = new Mission(19, "3 Doors", "Mission_19", "2", 10, 10);
            
            //-- משימות אקסטרא
            //-- missions[19] = new Mission(20, "num=3528", "Mission_20", "6471", 20, 10);
        }

        public Mission[] Shuffle(Mission[] missions, int n)
        {
            n -= 1;
            for (int i = 0; i < n; i++)
            {
                Mission first = missions[0];
                for (int j = 0; j < missions.Length - 1; j++)
                {
                    missions[j] = missions[j + 1];
                }
                missions[missions.Length - 1] = first;
            }
            return missions;

        }
        public Mission[] GetMissions()
        {
            return this.missions;
        }

    }
}
