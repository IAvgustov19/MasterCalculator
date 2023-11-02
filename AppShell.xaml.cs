namespace Calculator
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if(e.Value == true)
            {
                App.Current.UserAppTheme = AppTheme.Dark;
                Preferences.Set("isDark", true);
            }
            else
            {
                App.Current.UserAppTheme = AppTheme.Light;
                Preferences.Set("isDark", false);
            }
        }

        private void toggle_Loaded(object sender, EventArgs e)
        {
            switch (App.Current.UserAppTheme)
            {
                case AppTheme.Dark: (sender as Switch).IsToggled = true; break;
                case AppTheme.Light: (sender as Switch).IsToggled = false; break;
            }
        }
    }
}