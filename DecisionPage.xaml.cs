using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui;

namespace Calculator;

public partial class DecisionPage : ContentPage
{
    Dictionary<string, string> data = new Dictionary<string, string>();
    private List<Entry> entries = new List<Entry>();
    private Dictionary<string, Func<Dictionary<string, double>, double>> actions = new Dictionary<string, Func<Dictionary<string, double>, double>>();
    private Dictionary<string, double> variables = new Dictionary<string, double>();
    public DecisionPage(string formula)
	{
		InitializeComponent();
		Toolbar.Title = formula;

        switch (formula)
        {
            case "v = s/t":
                {
                    data.Add("v", "- скорость тела (км/ч)");
                    data.Add("s", "- пройденное телом расстояние (км)");
                    data.Add("t", "- затраченное время (ч)");

                    actions.Add("v", (i) => i["s"] / i["t"]);
                }
                break;

            case "s = v*t":
                data.Add("v", "- скорость тела (км/ч)");
                data.Add("s", "- пройденное телом расстояние (км)");
                data.Add("t", "- затраченное время (ч)");
                actions.Add("s", (i) => i["v"] * i["t"]);
                break;

            case "t = s/v":
                data.Add("v", "- скорость тела (км/ч)");
                data.Add("s", "- пройденное телом расстояние (км)");
                data.Add("t", "- затраченное время (ч)");
                actions.Add("t", (i) => i["s"] / i["v"]);
                break;

            case "a = (v2 - v1) / t":
                data.Add("a", "- ускорение");
                data.Add("v1", "- скорость 1");
                data.Add("v2", "- скорость 2");
                data.Add("t", "- время");

                actions.Add("a", (i) => (i["v2"] - i["v1"]) / i["t"]);
                break;

            case "s = v1*t + (1/2)at^2":
                data.Add("a", "- ускорение");
                data.Add("s", "- перемещение");
                data.Add("v1", "- 1 скорость");
                data.Add("t", "- время");

                actions.Add("s", (i) => 
                {
                    double d = Math.Pow(i["t"],2);
                    return (i["v1"] * i["t"] + (1d / 2d) * i["a"] * d); 
                });
                break;

            case "F = G*(m1*m2)/r^2":
                data.Add("F", "- ускорение");
                data.Add("G", "- гравитационная постоянная");
                data.Add("m1", "- масса 1 тела");
                data.Add("m2", "- масса 2 тела");
                data.Add("r", "- расстояние между ними");

                actions.Add("F", (i) =>
                {
                    double r = Math.Pow(i["r"], 2);
                    return (i["G"] * (i["m1"] * i["m2"])/r);
                });
                break;

            case "F = m*a":
                data.Add("F", "- сила");
                data.Add("m", "- масса");
                data.Add("a", "- ускорение");

                actions.Add("F", (i) =>
                {
                    return (i["m"] * i["a"]);
                });
                break;

            case "F_A = p * g * V":
                data.Add("F_A", "- сила Архимеда");
                data.Add("p", "- плотность жидкости");
                data.Add("g", "- ускорение свободного падения");
                data.Add("V", "- объём");

                actions.Add("F", (i) =>
                {
                    return (i["p"] * i["g"] * i["V"]);
                });
                break;



            case "ax + b = 0":
                data.Add("a", "- 1 коэффициент");
                data.Add("x", "- неизвестная");
                data.Add("b", "- 2 коэффициенты ");

                actions.Add("x", (i) =>
                {
                    return (-i["b"] / i["a"]);
                });
                break;

            case "x = (-b - √(b^2 - 4ac))/(2a)":
                data.Add("a", "- 1 коэффициент");
                data.Add("x", "- неизвестная");
                data.Add("b", "- 2 коэффициент");
                data.Add("c", "- 3 коэффициент");

                actions.Add("x", (i) =>
                {
                    double b = Math.Sqrt(Math.Pow(i["b"], 2) - 4 * i["a"] * i["c"]);
                    return ((-i["b"] - b)/(2* i["a"]));
                });
                break;

            case "x = (-b + √(b^2 - 4ac))/(2a)":
                data.Add("a", "- 1 коэффициент");
                data.Add("x", "- неизвестная");
                data.Add("b", "- 2 коэффициент");
                data.Add("c", "- 3 коэффициент");

                actions.Add("x", (i) =>
                {
                    double b = Math.Sqrt(Math.Pow(i["b"], 2) - 4 * i["a"] * i["c"]);
                    return ((-i["b"] + b) / (2 * i["a"]));
                });
                break;



            case "S = π * r^2":
                data.Add("s", "- площадь круга");
                data.Add("π", " ≈ 3.14");
                data.Add("r", "- радиус круга");

                actions.Add("s", (i) =>
                {
                    double r = Math.Pow(i["r"],2);
                    return (i["π"] * r);
                });
                break;

            case "S = (1/2) * a * h":
                data.Add("s", "- площадь треугольника");
                data.Add("h", "- высота");
                data.Add("a", "- основание треугольника");

                actions.Add("s", (i) =>
                {
                   // double r = Math.Pow(i["r"], 2);
                    return (0.5 * i["a"] * i["h"]);
                });
                break;

            case "V = a * b * h":
                data.Add("v", "- объем прямоугольного параллелепипеда");
                data.Add("b", "- ширина");
                data.Add("a", "- длина");
                data.Add("h", "- высота");

                actions.Add("v", (i) =>
                {
                    // double r = Math.Pow(i["r"], 2);
                    return (i["a"] * i["h"] * i["b"]);
                });
                break;

            case "c = √(a^2 + b^2)":
                data.Add("c", "- гипотенуза прямоугольного треугольника");
                data.Add("b", "- 1 катет");
                data.Add("a", "- 2 катет");

                actions.Add("c", (i) =>
                {
                     double a = Math.Pow(i["a"], 2);
                    double b = Math.Pow(i["b"], 2);
                    return Math.Sqrt(a+b);
                });
                break;

            case "n = c/v":
                data.Add("c", "абсолютный показатель преломления вещества");
                data.Add("v", "скорость света в данной среде, [м/с]");

                actions.Add("c", (i) =>
                {
                    double a = Math.Pow(i["a"], 2);
                    double b = Math.Pow(i["b"], 2);
                    return i["n"] / i["v"];
                });
                break;
        }

        foreach (KeyValuePair<string, string> pair in data)
        {
            Label lbl = new Label
            {
                Text = pair.Value,
                Margin = new Thickness(90,0,15,0),
                FontSize = 16,
                VerticalOptions = LayoutOptions.Center
            };

            Entry entry = new Entry
            {
                Placeholder = pair.Key,
                HeightRequest = 40,
                WidthRequest = 80,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Start,
                Keyboard = Keyboard.Numeric,
                IsEnabled = actions.First().Key == pair.Key ? false : true,
            };
            entries.Add(entry);

            Grid grid = new Grid();
            grid.Children.Add(lbl);
            grid.Children.Add(entry);

            stack.Children.Add(grid);
        }
    }

    private async void button_Clicked(object sender, EventArgs e)
    {
        List<Entry> newlist = entries.Where(x => x.Text == null || x.Text == string.Empty).ToList();

        if(newlist.Count > 1)
        {
            await Toast.Make("Для получения ответа введите значения", CommunityToolkit.Maui.Core.ToastDuration.Long, 14).Show();
        }
        else if(newlist.Count == 0)
        {
            await Toast.Make("Переменную, которую хотите получить, оставьте незаполненную", CommunityToolkit.Maui.Core.ToastDuration.Long, 14).Show();
        }
        else if(newlist.Count == 1)
        {
            variables.Clear();
            foreach(Entry entry in entries.Except(newlist))
            {
                variables.Add(entry.Placeholder, Convert.ToDouble(entry.Text));
            }
            Func<Dictionary<string, double>,double> t = actions.Where(x => x.Key == newlist[0].Placeholder).First().Value;
            await DisplayAlert("Ваш ответ", $"{newlist[0].Placeholder} = {t(variables).ToString()}", "Выйти");   
           
        }
    }
}