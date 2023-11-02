namespace Calculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Preferences.ContainsKey("isDark"))
            {
                App.Current.UserAppTheme = Preferences.Get("isDark", false) == true ? AppTheme.Dark : AppTheme.Light ;
            }
            else
            {
                App.Current.UserAppTheme = AppTheme.Light;
                Preferences.Set("isDark", false);
            }

            if (Preferences.ContainsKey("FirstTime"))
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new WelocmeScreen();
            }
            
        }
    }
}