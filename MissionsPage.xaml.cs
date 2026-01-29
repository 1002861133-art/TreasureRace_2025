
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
        if (mission != null && helper.MissionNotDone(missionNumber))
        {
            if (entAnswer.Text == mission.GetGoodAnswer())
            {
                MainPage.myGame.missionsDone.Insert(missionNumber);
                MainPage.myGame.AddPoints(points);
                lblPoints.Text = MainPage.myGame.GetTotalPoints().ToString();
                btnCheckAnswer.Text = "Check Answer";
                ShowMsg("Correct Answer", true);
                CleanAllFields();
                if (MainPage.myGame.IsCompleted() == true)
                {
                    Shell.Current.GoToAsync("//EndGamePage");
                    return;
                }

                MainPage.myGame.MoveToNextMissionIndex();
                this.mission = MainPage.myGame.GetCurrentMission();
                points = mission.GetPoint();
                lblMissionPlace.Text = mission.GetPlace() + " (" + mission.GetPoint() + " points)";
                lblMissionName.Text = mission.GetName();
            }
            else
            {
                points /= 2;
                if (points == 0)
                {
                    if (MainPage.myGame.IsCompleted() == true)
                    {
                        Shell.Current.GoToAsync("//EndGamePage");
                        return;
                    }

                    MainPage.myGame.MoveToNextMissionIndex();
                    this.mission = MainPage.myGame.GetCurrentMission();
                    points = mission.GetPoint();
                    lblMissionPlace.Text = mission.GetPlace() + " (" + mission.GetPoint() + " points)";
                    lblMissionName.Text = mission.GetName();
                    btnCheckAnswer.IsEnabled = true;
                    entAnswer.IsEnabled = true;
                    btnCheckAnswer.Text = "Check Answer";

                    return;
                }

               
                mission.SetPoint(points);
                lblMissionPlace.Text = mission.GetPlace() + " (" + points + " points)";
                btnCheckAnswer.Text = "Recheck Anwser for half the points (" + points.ToString() + ")";
                ShowMsg("Wrong Answer", false);
                btnCheckAnswer.IsEnabled = true;
                entAnswer.IsEnabled = true;
            }
        }
        else
        {
            ShowMsg("Mission already done", false);
            btnCheckAnswer.IsEnabled = false;
            entAnswer.IsEnabled = false;
        }
    }
   
    /*
    private void BtnCheckMission_Clicked(object sender, EventArgs e)
    {
        ShowMsg("", true);
        entAnswer.Text = "";
        btnCheckAnswer.Text = "Check Answer";
        if (!helper.IsNumeric(entMissionNum.Text.ToString()))
        {
            entMissionNum.Text = "";
            ShowMsg("only numeric 1 - 20!", false);
        }
        else if (int.Parse(entMissionNum.Text.ToString()) < 1 || int.Parse(entMissionNum.Text.ToString()) > 20)
        {
            entMissionNum.Text = "";
            ShowMsg("only numeric 1 - 20!", false);
        }
        else
        {
            // צריך לבדוק האם המשימה לא בוצעה כבר
            if (helper.MissionNotDone(int.Parse(entMissionNum.Text.ToString())))
            {
                btnCheckAnswer.IsEnabled = true;
                entAnswer.IsEnabled = true;

                // bring the next mission
                if (MainPage.myGame.IsCompleted())
                {
                    ShowMsg("Game over.", false);
                    return;
                }

                MainPage.myGame.MoveToNextMissionIndex();
                mission = MainPage.myGame.GetCurrentMission();
                points = mission.GetPoint();
                lblMissionPlace.Text = mission.GetPlace() + " (" + mission.GetPoint() + " points)";
                lblMissionName.Text = mission.GetName();
            }
            else
            {
                entMissionNum.Text = "";
                ShowMsg("The mission number is already done.", false);
            }
        }
    }
    */

    private void BtnNextMission_Clicked(object sender, EventArgs e)
    {

        ShowMsg("", true);
        CleanAllFields();
        MainPage.myGame.MoveToNextMissionIndex();
        this.mission = MainPage.myGame.GetCurrentMission();
        points = mission.GetPoint();
        lblMissionPlace.Text = mission.GetPlace() + " (" + mission.GetPoint() + " points)";
        lblMissionName.Text = mission.GetName();
    }
    private void CleanAllFields()
    {
        lblMissionPlace.Text = "";
        lblMissionName.Text = "";
        entAnswer.Text = "";
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