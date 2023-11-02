using System.Collections.ObjectModel;

namespace Calculator;

public partial class Geometry : ContentPage
{
    private CollectionView SelectionCollection { get; set; }

    //Динамический словарь формул и имён
    public ObservableCollection<Item> Formules { get; set; } = new ObservableCollection<Item>
    {
        new Item{Name="Площадь круга",  Value="S = π * r^2"},
        new Item{Name="Площадь треугольника",  Value="S = (1/2) * a * h"},
          new Item{Name="Объём прямоугольного параллелепипеда",  Value="V = a * b * h"},
        new Item{Name="Теорема пифагора",  Value="c = √(a^2 + b^2)"},

        new Item{Name = "Площадь произвольного треугольника", Value = "S=1/2 * h * a"},
         new Item{Name="Площадь произвольного треугольника",  Value="S=1/2 * b * c * sina"},
        new Item{Name="Площадь произвольного треугольника",  Value="S=√(p * (p-a) * (p-b) * (p-c))"},
          new Item{Name="Радиус вписанной окружности",  Value="r = S / p"},
        new Item{Name="Радиус описанной окружности",  Value="R = a * b * c / 4S"},
        new Item{Name = "Радиус описанной окружности по теореме синусов", Value = "2R = a / sinα"},
        new Item{Name = "Сторона треугольника по теореме косиинусов", Value = "a = √(b^2 + c^2 - 2 * b * Cosα)"},
        new Item{Name = "Площадь  прямоугольного треугольника", Value = "S = 1/2 * a * b"},
         new Item{Name="Площадь  прямоугольного треугольника",  Value="S = 1/2 * c * h"},
        new Item{Name="Радиус вписанной окружности внутри прямоугольного треугольника",  Value="r = (a + b - c) / 2"},
          new Item{Name="Радиус описанной окружности вокруг прямоугольного треугольника",  Value="R = c / 2"},
        new Item{Name="Сторона прямоугольного треугольника",  Value="a = c * sinα"},
        new Item{Name = "Сторона прямоугольного треугольника", Value = "a = b * tgα"},
        new Item{Name = "Сторона прямоугольного треугольника", Value = "a = b / tgβ"},
        new Item{Name = "Площадь равностороннего треугольника", Value = "S = (a^2 * √3) / 4"},
        new Item{Name = "Радиус вписанной окружности внутри равностороннего треугольника", Value = "r = (a * √3) / 6"},
        new Item{Name = "Радиус описанной окружности вокруг равностороннего треугольник", Value = "R = (a * √3) / 3"},
         new Item{Name="Площадь произвольного четырехугольника",  Value="S = 1/2 * d1 * d2 * sinφ"},
        new Item{Name="Площадь параллелограмма",  Value="S = a * h"},
          new Item{Name="Площадь параллелограмма",  Value="S = a * b * sinα"},
          new Item{Name="Площадь параллелограмма",  Value="S = 1/2 * d1 * d2"},
           new Item{Name="Площадь ромба",  Value="S = a * h"},
        new Item{Name="Площадь ромба",  Value="S = a^2 * sinA"},
        new Item{Name = "Площадь ромба", Value = "S = 1/2 * d1 * d2"},
        new Item{Name = "Площадь прямоугольника", Value = "S = a * b"},
        new Item{Name="Площадь прямоугольника",  Value="S = 1/2 * d1 * d2 * sinφ"},

          new Item{Name = "Площадь квадрата", Value = "S = a^2"},
        new Item{Name = "Площадь квадрата", Value = "S = (d^2) / 2"},
        new Item{Name = "Средняя линия трапеции", Value = "l = a + b / 2"},
        new Item{Name = "Площадь трапеции", Value = "S = ((a + b) / 2) * h"},
        new Item{Name = "Площадь трапеции", Value = "S = l * h"},
         new Item{Name="Площадь описанного многоугольника",  Value="S = p * r"},
        new Item{Name="Сторона правильного многоугольника",  Value="a = 2 * R * sin(180/n)"},
          new Item{Name="Площадь правильный многоугольника",  Value="S = n * a * r / 2"},
          new Item{Name="Длина окружности",  Value="c = 2 * π * r"},
        new Item{Name="Длина сектора",  Value="l = π * r * (n/180)"},
        new Item{Name = "Длина сектора", Value = "l = r * a"},
        new Item{Name = "Площадь сектора", Value = "S = π * r^2 * (n/360)"},
        new Item{Name="Площадь сектора",  Value="S = 1/2 * r^2 * a"},
    };
    public Geometry()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //Если переменная пустая - присваиваем используемую коллекцию
        SelectionCollection ??= (CollectionView)sender;

        if (SelectionCollection.SelectedItem != null)
        {
            await Navigation.PushAsync(new DecisionPage((e.CurrentSelection[0] as Item).Value));
        }
        //Сбрасываем выбор для возможности выбора второй раз подряд
        SelectionCollection.SelectedItem = null;
    }
}