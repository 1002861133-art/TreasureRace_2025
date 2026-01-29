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
            missions[0] = new Mission(1, "3 Chemestry Missions", "Chemestry lavoratory", "123", 30);
            missions[1] = new Mission(2, "What is the Code?", "Kitchen room (computer room)", "613", 16); missions[2] = new Mission(3, "Biotechnologia - Atom", "biotechnologia lavoratory", "3", 20);
            missions[2] = new Mission(3, "Result for num=5183", "Mission_3", "3518", 20);
            missions[3] = new Mission(4, "Biotechnologia - lemon", "biotechnologia lavoratory", "19", 20);
            missions[4] = new Mission(5, "Biology_1", "Go to Photosynthesis room", "ביולוגיה", 30);
            missions[5] = new Mission(6, "98% Mistake", "Mission_6", "15", 12);
            missions[6] = new Mission(7, "Genious only", "Mission_7", "26", 10);
            missions[7] = new Mission(8, "Result with num=8", "Mission_8", "40320", 20);
            missions[8] = new Mission(9, "Training", "Mission_9", "11", 14);
            missions[9] = new Mission(10, "1_true/0_false", "Mission_10", "0", 15);

            missions[10] = new Mission(11, "num=6791", "Mission_11", "1976", 20);
            missions[11] = new Mission(12, "Weight", "Mission_12", "27", 12);
            missions[12] = new Mission(13, "Hats A/B/C/D", "Mission_13", "C", 20);
            missions[13] = new Mission(14, "Worms", "Mission_14", "15", 10);
            missions[14] = new Mission(15, "Height", "Mission_15", "150", 14);
            missions[15] = new Mission(16, "I lied yesterday", "Computer Room", "Wednesday", 10);
            missions[16] = new Mission(17, "Spider", "Mission_17", "97", 10);
            missions[17] = new Mission(18, "Pishpeshouk", "Mission_18", "15", 10);
            missions[18] = new Mission(19, "3 Doors", "Mission_19", "2", 10);
            missions[19] = new Mission(20, "num=3528", "Mission_20", "6471", 20);
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
