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
            for (int i = 0; i < 10; i++)
            {
                if (players[i] != "")
                    numOfPlayers++;
            }
            group = new Group(entGroupName.Text, entGroupNumber.Text.ToString(), players, numOfPlayers);
            myGame = new Game(group);

            Shell.Current.GoToAsync("//MissionsPage");

            //GoToMission();
        }

        private async void GoToMission()
        {
            await Shell.Current.GoToAsync("//MissionsPage");

        }

     }

}

