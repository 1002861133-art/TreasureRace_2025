using TreasureRace_2025.Models;

namespace TreasureRace_2025
{
    public partial class MainPage : ContentPage
    {
        public static Game myGame;
        public static Group? group = null;
        public static int points = 0;
        public string[] players = new string[10];
        public Mission[] missions = new Mission[20];

        public MainPage()
        {
            InitializeComponent();
        }
        private void BtnStartGame_Clicked(object sender, EventArgs e)
        {
            if (entGroupName.Text == "" || entGroupNumber.Text == "")
            {
                DisplayAlert("שגיאה", "אנא הזן את שם הקבוצה ומספרה.", "סגור");
                return;
            }

            if (!int.TryParse(entGroupNumber.Text, out int groupNum))
            {
                DisplayAlert("שגיאה", "מספר הקבוצה חייב להיות מספר.", "סגור");
                return;
            }

            if (groupNum <= 0 || groupNum > 20)
            {
                DisplayAlert("שגיאה", "מספר הקבוצה חייב להיות בין 1 ל‑20.", "סגור");
                return;
            }

            int numOfPlayers = 0;
            players[0] = entPlayer1.Text;
            players[1] = entPlayer2.Text;
            players[2] = entPlayer3.Text;
            players[3] = entPlayer4.Text;
            players[4] = entPlayer5.Text;
            players[5] = entPlayer6.Text;
            players[6] = entPlayer7.Text;
            players[7] = entPlayer8.Text;
            players[8] = entPlayer9.Text;
            players[9] = entPlayer10.Text;

            if (players.Count(p=> !string.IsNullOrEmpty(p)) < 2)
            {
                DisplayAlert("Error", "אנא בחר לפחות שני שחקנים.", "סגור");
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                if (players[i] != "")
                    numOfPlayers++;
            }
            group = new Group(entGroupName.Text, entGroupNumber.Text.ToString(), players, numOfPlayers);
            myGame = new Game(group);

            Shell.Current.GoToAsync("//MissionsPage");
        }
     }
}

