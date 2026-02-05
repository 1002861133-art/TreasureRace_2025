
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

    private async void BtnCheckAnswer_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (entAnswer.Text == "")
            {
                await DisplayAlert("דף משימות", "אנא הקלד תשובה בבקשה", "סגור חלון");
                return;
            }

            int missionNumber = MainPage.myGame.GetIndex();

            if (MainPage.myGame.IsCompleted() == true)
            {
                await Shell.Current.GoToAsync("//EndGamePage");
                return;
            }

            if (points == 0)
            {
                CleanAllFields();
                btnCheckAnswer.Text = "אין יותר ניסיונות";
                btnCheckAnswer.IsEnabled = false;
                ShowMsg("אין יותר ניסיונות, אנא עבור לשאלה הבאה.", false);
                return;
            }

            if (mission == null || helper.MissionNotDone(missionNumber) == false)
            {
                ShowMsg("המשימה כבר הושלמה.", false);
                return;
            }

            bool isGoodAnswer = entAnswer.Text.ToUpper() == mission.GetGoodAnswer().ToUpper();
            if (!isGoodAnswer)
            {
                points /= 2;
                if (points == 0)
                {
                    CleanAllFields();
                    btnCheckAnswer.Text = "אין יותר ניסיונות";
                    btnCheckAnswer.IsEnabled = false;
                    ShowMsg("אין יותר ניסיונות, אנא עבור לשאלה הבאה.", false);
                    return;
                }

                mission.SetPoint(points);
                lblMissionPlace.Text = mission.GetPlace() + " (" + points + " נקודות)";
                btnCheckAnswer.Text = "בדוק שוב את התשובה עבור חצי מהנקודות (" + points.ToString() + ")";
                btnCheckAnswer.IsEnabled = true;
                ShowMsg("תשובה שגויה.", false);
                return;
            }

            MainPage.myGame.AddPoints(points);
            MainPage.myGame.missionsDone.Insert(missionNumber);
            lblPoints.Text = MainPage.myGame.GetTotalPoints().ToString();
            btnCheckAnswer.Text = "מצוין! עבור למשימה הבאה.";
            btnCheckAnswer.IsEnabled = false;
            _timer?.Stop();
            ShowMsg("תשובה נכונה לחץ על כפתור הבא", true);

        }
        catch (Exception ex)
        {
            await DisplayAlert("דף משימות", "שגיאה בלתי צפויה " + ex.Message, "סגור חלון");
        }
    }

    private async void BtnNextMission_Clicked(object sender, EventArgs e)
    {
        try
        {
            bool next = await DisplayAlert("משימה חדשה", "אתה בטוח?", "כן", "לא");

            if (!next)
                return;

            if (MainPage.myGame.IsCompleted())
            {
                await DisplayAlert("משחק הסתיים", "אנא לח בבקשה על כפתור סיום משחק?", "סגור");
                return;
            }

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
        catch (Exception ex)
        {
            await DisplayAlert("דף משימות", "שגיאה בלתי צפויה " + ex.Message, "סגור חלון");
        }
    }

    private void CleanAllFields()
    {
        lblMissionPlace.Text = "";
        lblMissionName.Text = "";
        entAnswer.Text = "";
        btnCheckAnswer.Text = "בדוק את התשובה";
    }

    // Change 'Task' to 'void'
    private async void BtnEndGame_Clicked(object sender, EventArgs e)
    {
        try
        {
            bool exitApp = await DisplayAlert("סיום משחק", "האם אתה בטוח?", "כן", "לא");
            if (exitApp)
            {
                // Use await here to ensure navigation happens smoothly
                await Shell.Current.GoToAsync("//EndGamePage");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("דף משימות", "שגיאה בלתי צפויה " + ex.Message, "סגור חלון");
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