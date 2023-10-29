namespace Calculator;

public partial class Algebra : ContentPage
{
    private CollectionView SelectionCollection { get; set; }
    public List<string> Formules { get; set; } = new List<string>
    {
        "ax + b = 0",
        "x = (-b - √(b^2 - 4ac))/(2a)",
        "x = (-b + √(b^2 - 4ac))/(2a)",
    };
    public Algebra()
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