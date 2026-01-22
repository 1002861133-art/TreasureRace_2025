
using TreasureRace_2025.Models;


namespace TreasureRace_2025;

public partial class MissionsPage : ContentPage
{
    public AllMissions allMissions;
    public Mission[] missionsArr;
    public Mission? mission;
    public Helper helper;
    public int points;
    private bool isMissionShown = false;

    public MissionsPage()
    {
        InitializeComponent();
        allMissions = new AllMissions();
        missionsArr = allMissions.GetMissions();
        helper = new Helper();
        btnCheckAnswer.IsEnabled = false;
        entAnswer.IsEnabled = false;
    }

    private void BtnCheckAnswer_Clicked(object sender, EventArgs e)
    {
        if (mission != null && helper.MissionNotDone(int.Parse(entMissionNum.Text.ToString())))
        {
            if (entAnswer.Text == mission.GetGoodAnswer())
            {
                MainPage.myGame.missionsDone.Insert(int.Parse(entMissionNum.Text.ToString()));
                MainPage.myGame.AddPoints(points);
                lblPoints.Text = MainPage.myGame.GetTotalPoints().ToString();
                btnCheckAnswer.Text = "Check Answer";
                ShowMsg("Correct Answer", true);
                CleanAllFields();
                btnCheckAnswer.IsEnabled = false;
                entAnswer.IsEnabled = false;
            } else
            {
                points /= 2;
                mission.SetPoint(points);
                lblMissionPlace.Text = mission.GetPlace() + " (" + points + " points)";
                btnCheckAnswer.Text = "Recheck Anwser for half the points ("+ points.ToString()+")";
                ShowMsg("Wrong Answer", false);
                btnCheckAnswer.IsEnabled = true;
                entAnswer.IsEnabled = true;
            }
                

           
        } else
        {
            ShowMsg("Mission already done", false);
            btnCheckAnswer.IsEnabled = false;
            entAnswer.IsEnabled = false;
        }

    }
    //  clear   להוסיף כפתור 
    //entMissionNum.Text="";  : לשדה

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
                // bring the chosen mission
                mission = missionsArr[int.Parse(entMissionNum.Text.ToString()) - 1];
                points = mission.GetPoint();
                //MainPage.myGame.missionsDone.Insert(int.Parse(entMissionNum.Text.ToString()));
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
    //  clear   להוסיף כפתור 
    //entMissionNum.Text="";  : לשדה
    // או להוסיף שדה להודעת שגיאה

    private void BtnNextMission_Clicked(object sender, EventArgs e)
    {

        ShowMsg("", true);
        CleanAllFields();
        btnCheckAnswer.IsEnabled = false;
        entAnswer.IsEnabled = false;
    }
    private void CleanAllFields()
    {
       
        entMissionNum.Text = "";
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
        if (msg.Length==0)
        {
            lblMsg.IsVisible = false;
            lblMsg.Text = "";
        } else
        {
            if (isPositiveMessage) {
                lblMsg.Background = new SolidColorBrush(Colors.Green);
            } else
            {
                lblMsg.Background = new SolidColorBrush(Colors.Red);
            }
            
            lblMsg.IsEnabled = true;
            lblMsg.Text = msg;
        }
       
    }

}