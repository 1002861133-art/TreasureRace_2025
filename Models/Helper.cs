using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureRace_2025.Models
{
    public class Helper
    {
        public Helper() { }

        // פעולה המקבלת מחרוזת ובודקת האם היא נומרית
        // is the string numeric-Only ("0123456789") - true/false
        public bool IsNumeric(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            else
            {
                string options = "0123456789";
                for (int i = 0; i < str.Length; i++)
                {
                    if (options.IndexOf(str[i]) == -1) return false;
                    //if character isn’t equal to one of the options return false
                }
            }
            return true;
        }
        public bool IsInQueue(Queue<int> qu, int num)
        {
            Queue<int> ez = new Queue<int>();
            while (!qu.IsEmpty())
            {
                if (num == qu.Head())
                {
                    while (!ez.IsEmpty())
                        qu.Insert(ez.Remove());
                    return true;
                }
                else
                {
                    ez.Insert(qu.Remove());
                }
            }
            while (!ez.IsEmpty())
                qu.Insert(ez.Remove());
            return false;
        }

        public bool MissionNotDone(int missionNum)
        {
            Queue<int> ez = new Queue<int>();
            // check MainPage.myGame.missionsDone; - qu
            Queue<int> qu = MainPage.myGame.missionsDone;
            if (!IsInQueue(qu, missionNum)) // אם המספר לא בתור המשימות שבוצעו
                return true;
            else return false;
        }

        // Method: gets a number - טענת כניסה
        // returns: the reverse number - טענת יציאה
        public int ReverseNumber(int num)
        {
            int revNum = 0;
            // the loop to reverse the number
            return revNum;

        }

        // Method: gets a number - טענת כניסה
        // returns: the Complet To 9 number - טענת יציאה
        // for 1234 returns 8765 , for 3752 returns 6247 ...

        public int CompletTo9(int num)
        {
            int revNum = 0;
            // the loop to calculate the number
            return revNum;
        }

        // Method: gets 2 numbers - טענת כניסה
        // returns: num1 in power num2 - טענת יציאה
        // מקבלת שני מספרים שלמים ומחזירה את המספר הראשון בחזקת המספר השני

        public int Num1PowNum2(int num1, int num2)
        {
            int result = 0;
            // the loop to calculate the result
            return result;
        }

        // Method: gets a number - טענת כניסה
        // returns: the number after moving the unit(last) digit to the leftdigit(firstDigit) - טענת יציאה
        // for 1234 returns 4123 , for 3752 returns 2375 ...
        public int LastDigToFirst(int num)
        {
            int result = 0;
            // the loop to calculate the result
            return result;
        }
    }
}

