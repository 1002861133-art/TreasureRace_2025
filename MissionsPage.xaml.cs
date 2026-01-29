
using TreasureRace_2025.Models;
namespace TreasureRace_2025;

public partial class MissionsPage : ContentPage
{
    public Mission? mission;
    public Helper helper;
    public int points;
    private bool isMissionShown = false;


    public MissionsPage()
    {
        InitializeComponent();
        this.helper = new Helper();
        this.btnCheckAnswer.IsEnabled = true;
        this.entAnswer.IsEnabled = true;
        this.mission = MainPage.myGame.GetCurrentMission();
        points = mission.GetPoint();
        lblMissionPlace.Text = mission.GetPlace() + " (" + mission.GetPoint() + " points)";
        lblMissionName.Text = mission.GetName();
    }

    private void BtnCheckAnswer_Clicked(object sender, EventArgs e)
    {
        int missionNumber = MainPage.myGame.GetIndex();

        if (MainPage.myGame.IsCompleted() == true)
        {
            Shell.Current.GoToAsync("//EndGamePage");
            return;
        }

        if (points <= 1)
        {
            CleanAllFields();
            btnCheckAnswer.Text = "No More tries";
            btnCheckAnswer.IsEnabled = false;
            ShowMsg("No more tries, Please go to the next question", false);
            return;
        }

        if (mission == null || helper.MissionNotDone(missionNumber) == false)
        {
            ShowMsg("Mission already done", false);
            return;
        }

        bool isGoodAnswer = entAnswer.Text == mission.GetGoodAnswer();
        if (!isGoodAnswer)
        {
            points /= 2;
            mission.SetPoint(points);
            lblMissionPlace.Text = mission.GetPlace() + " (" + points + " points)";
            btnCheckAnswer.Text = "Recheck Anwser for half the points (" + points.ToString() + ")";
            btnCheckAnswer.IsEnabled = true;
            ShowMsg("Wrong Answer", false);
            return;
        }

        MainPage.myGame.AddPoints(points);
        MainPage.myGame.missionsDone.Insert(missionNumber);
        lblPoints.Text = MainPage.myGame.GetTotalPoints().ToString();
        btnCheckAnswer.Text = "Very Good!, Go to next mission";
        btnCheckAnswer.IsEnabled = false;
        ShowMsg("Correct Answer, Click on Next", true);

    }


    private void BtnNextMission_Clicked(object sender, EventArgs e)
    {
        if (MainPage.myGame.IsCompleted() == true)
        {
            Shell.Current.GoToAsync("//EndGamePage");
            return;
        }

        CleanAllFields();
        MainPage.myGame.MoveToNextMissionIndex();
        this.mission = MainPage.myGame.GetCurrentMission();
        btnCheckAnswer.IsEnabled = true;
        ShowMsg("", true);

        points = mission.GetPoint();
        lblMissionPlace.Text = mission.GetPlace() + " (" + mission.GetPoint() + " points)";
        lblMissionName.Text = mission.GetName();
    }
    private void CleanAllFields()
    {
        lblMissionPlace.Text = "";
        lblMissionName.Text = "";
        entAnswer.Text = "";
        btnCheckAnswer.Text = "Check Answer";
    }
    private void BtnEndGame_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EndGamePage");
    }
    private void ShowMsg(String msg, bool isPositiveMessage)
    {
        if (msg.Length == 0)
        {
            lblMsg.IsVisible = false;
            lblMsg.Text = "";
        }
        else
        {
            lblMsg.IsVisible = true;
            if (isPositiveMessage)
            {
                lblMsg.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                lblMsg.Background = new SolidColorBrush(Colors.Red);
            }

            lblMsg.IsEnabled = true;
            lblMsg.Text = msg;
        }

    }
}