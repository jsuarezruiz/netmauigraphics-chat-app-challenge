using GraphicsChatApp.Views;

namespace GraphicsChatApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new HomeView();
	}
}
