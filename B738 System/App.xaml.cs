namespace B738_System;

public partial class App : Application
{
	public SplashScreen splashScreen;
	public MainPage mainPage;

	public static App Instance { get; private set; }

	public WebServer server;

	public App()
	{
		Instance = this;

		InitializeComponent();

        splashScreen = new SplashScreen();
		mainPage = new MainPage();

		MainPage = splashScreen;
	}
}
