namespace Calculator;

public partial class Geometry : ContentPage
{
    private CollectionView SelectionCollection { get; set; }
    public List<string> Formules { get; set; } = new List<string>
    {
        "S = π * r^2",
        "S = (1/2) * a * h",
        "V = a * b * h",
        "c = √(a^2 + b^2)"
    };
    public Geometry()
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