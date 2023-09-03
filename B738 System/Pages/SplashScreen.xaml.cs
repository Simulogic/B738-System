namespace B738_System;

public partial class SplashScreen : ContentPage
{
	public SplashScreen()
	{
		InitializeComponent();

        Dispatcher.StartTimer(TimeSpan.FromMilliseconds(2000), () =>
		{
			App.Instance.MainPage = App.Instance.mainPage;

			return false;
        });
	}
}