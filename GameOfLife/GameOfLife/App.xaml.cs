using System.Windows;

namespace GameOfLife
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			var gameWindow = new Views.GameWindow();
			Application.Current.MainWindow = gameWindow;
			gameWindow.Show();
		}
	}
}
