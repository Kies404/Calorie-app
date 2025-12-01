namespace Calorie_app;

using System.Collections.ObjectModel;

public partial class MainPage : ContentPage
{
    public ObservableCollection<FoodItem> Foods { get; set; } = new();

    private int _totalCalories = 0;

    public MainPage()
    {
        InitializeComponent();
        FoodList.ItemsSource = Foods;
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        string foodName = FoodEntry.Text;
        string caloriesText = CalorieEntry.Text;

        if (string.IsNullOrWhiteSpace(foodName) || string.IsNullOrWhiteSpace(caloriesText))
        {
            DisplayAlert("Error", "Please enter food and calories.", "OK");
            return;
        }

        if (int.TryParse(caloriesText, out int calories))
        {
            Foods.Add(new FoodItem { Name = foodName, Calories = calories });

            _totalCalories += calories;
            TotalLabel.Text = _totalCalories.ToString();

            FoodEntry.Text = "";
            CalorieEntry.Text = "";
        }
        else
        {
            DisplayAlert("Error", "Calories must be a number.", "OK");
        }
    }
}

public class FoodItem
{
    public string Name { get; set; }
    public int Calories { get; set; }
}
