using TreasureRace_2025.Models;

namespace TreasureRace_2025;

public partial class EndGamePage : ContentPage
{
	public EndGamePage()
	{
		InitializeComponent();
		lblFinalSAcore.Text = GetTotalPoints();

    }
	public string GetTotalPoints()
	{
		return Game.instance.GetTotalPoints().ToString();
	}

    private void BtnExitApp_Clicked(object sender, EventArgs e)
    {
	#if ANDROID || WINDOWS || MACCATALYST
			Application.Current.Quit(); // MAUI 7+ cross-platform exit
	#elif IOS
		// iOS does not allow exiting programmatically, show alert instead
		DisplayAlert("Notice", "You cannot exit the app on iOS.", "OK");
	#endif
    }
}