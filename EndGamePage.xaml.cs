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
}