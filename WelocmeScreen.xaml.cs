namespace Calculator;

public partial class WelocmeScreen : ContentPage
{
	public WelocmeScreen()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		//Сохранение данных о просмотре приветсвенного экрана
		Preferences.Set("FirstTime", true);

		//Изменение главной страницы отображения
		App.Current.MainPage = new AppShell();
    }
}