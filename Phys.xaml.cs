namespace Calculator;

public partial class Phys : ContentPage
{
    private CollectionView SelectionCollection { get; set; }
    public List<string> Formules { get; set; } = new List<string>
	{
        "v = s/t",
        "t = s/v",
        "s = v*t",
        "a = (v2 - v1) / t",
		"s = v1*t + (1/2)at^2",
        "F = G*(m1*m2)/r^2",
        "F = m*a",
        "F_A = p * g * V",
        "n = c/v"
    };
	public Phys()
	{
		InitializeComponent();
		BindingContext = this;
	}

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        SelectionCollection ??= (CollectionView)sender;

        if (SelectionCollection.SelectedItem != null)
        {
            await Navigation.PushAsync(new DecisionPage((e.CurrentSelection.First().ToString())));
        }
        SelectionCollection.SelectedItem = null;
    }
}