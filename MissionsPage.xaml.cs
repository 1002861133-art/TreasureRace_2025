
using TreasureRace_2025.Models;
namespace TreasureRace_2025;

public partial class MissionsPage : ContentPage
{
    public Mission? mission;
    public Helper helper;
    public int points;
    private bool isMissionShown = false;

    private TimeSpan _timeLeft = TimeSpan.FromMinutes(20);
    private IDispatcherTimer _timer;

    private void OnTimerTick(object? sender, EventArgs e)
    {
        if (_timeLeft.TotalSeconds <= 0)
        {
            _timer.Stop();
            lblTimeLeft.Text = "00:00";
            btnCheckAnswer.IsEnabled = false;
            return;
        }

        _timeLeft = _timeLeft.Subtract(TimeSpan.FromSeconds(1));
        lblTimeLeft.Text = _timeLeft.ToString(@"mm\:ss");
    }

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
        _timeLeft = TimeSpan.FromMinutes(mission.GetTimeMinutes());

        lblTimeLeft.Text = _timeLeft.ToString(@"mm\:ss");

        _timer = Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += OnTimerTick;
        _timer.Start();
    }

    private void BtnCheckAnswer_Clicked(object sender, EventArgs e)
    {
        if (entAnswer.Text == "")
        {
            DisplayAlert("Mission Page", "Please enter an answer","close");
            return;
        }

        int missionNumber = MainPage.myGame.GetIndex();

        if (MainPage.myGame.IsCompleted() == true)
        {
            Shell.Current.GoToAsync("//EndGamePage");
            return;
        }

        if (points < 1)
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
        _timer?.Stop();
        ShowMsg("Correct Answer, Click on Next", true);
    }


    private async void BtnNextMission_Clicked(object sender, EventArgs e)
    {
        bool next = await DisplayAlert("Next task", "Are you sure?", "Yes", "No");

        if (!next)
            return;

        _timer?.Stop();
        CleanAllFields();
        MainPage.myGame.MoveToNextMissionIndex();
        this.mission = MainPage.myGame.GetCurrentMission();
        btnCheckAnswer.IsEnabled = true;
        ShowMsg("", true);
        _timeLeft = TimeSpan.FromMinutes(mission.GetTimeMinutes());
        _timer?.Start();

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

    // Change 'Task' to 'void'
    private async void BtnEndGame_Clicked(object sender, EventArgs e)
    {
        bool exitApp = await DisplayAlert("End Game", "Are you sure?", "Yes", "No");

        if (exitApp)
        {
            // Use await here to ensure navigation happens smoothly
            await Shell.Current.GoToAsync("//EndGamePage");
        }
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