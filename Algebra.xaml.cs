using System.Collections.ObjectModel;

namespace Calculator;

public partial class Algebra : ContentPage
{
    private CollectionView SelectionCollection { get; set; }

    //Динамический словарь формул и имён
    public ObservableCollection<Item> Formules { get; set; } = new ObservableCollection<Item>
    {
        new Item{Name="Линейное уравнение",  Value="ax + b = 0"},
        new Item{Name="2 корень квадратного уравнения",  Value="x = (-b - √(b^2 - 4ac))/(2a)"},
        new Item{Name="1 корень квадратного уравнения",  Value="x = (-b + √(b^2 - 4ac))/(2a)"},

        new Item{Name="Извлечение корня n-степени",  Value="t = n√a"},

        new Item{Name="Разность квадратов",  Value="t = (a - b) * (a + b) = a^2 - b^2"},
        new Item{Name="Квадрат разности",  Value="t = (a - b)^2 = a^2 - 2ab + b^2"},
        new Item{Name="Квадрат разности",  Value="t = (a - b)^2 = (b - a)^2"},
        new Item{Name="Квадрат суммы",  Value="t = (a + b)^2 = a^2 + 2ab + b^2"},
        new Item{Name="Сумма кубов",  Value="t = a^3 + b^3 = (a + b) * (a^2 - ab + b^2)"},
        new Item{Name="Разность кубов",  Value="t = a^3 - b^3 = (a - b) * (a^2 + ab + b^2)"},
         new Item{Name="Куб разности",  Value="t = (a - b)^3 = a^3 - 3a^2b + 3b^2 - b^3"},
         new Item{Name="Куб суммы",  Value="t = (a + b)^3 = a^3 + 3a^2b + 3b^2 + b^3"},

         new Item{Name="Арифметическая прогрессия. Формула n-го члена",  Value="an = a1 + (n - 1) * d"},
         new Item{Name="Арифметическая прогрессия. Рекуррентная формула",  Value="an+1 = an + d"},
         new Item{Name="Арифметическая прогрессия. Характеристическое свойство",  Value="an = (an+1 + an-1)/2"},
         new Item{Name="Арифметическая прогрессия. Формула суммы n первых членов",  Value="Sn = (a1 + an)/2 * n"},
         new Item{Name="Арифметическая прогрессия. Формула суммы n первых членов",  Value="Sn = (2a1 + (n-1) * d)/2 * n"},
         new Item{Name="Арифметическая прогрессия. Дополнительные формулы",  Value="d = (an - am) / (n - m)"},

         new Item{Name="Геометрическая прогрессия. Формула n-го члена",  Value="bn = b1 * q^n-1"},
         new Item{Name="Геометрическая прогрессия. Рекуррентная формула",  Value="bn+1 = bn * q"},
         new Item{Name="Геометрическая прогрессия. Характеристическое свойство",  Value="bn^2 = bn+1 * bn-1"},
         new Item{Name="Геометрическая прогрессия. Формула суммы n первых членов",  Value="Sn = (b1 - bn * q) / 1 - q"},
         new Item{Name="Геометрическая прогрессия. Формула суммы n первых членов",  Value="Sn = b1 * (1 - q^n) / 1 - q"},
         new Item{Name="Геометрическая прогрессия. Дополнительные формулы",  Value="q^(n-m) = bn / bm"},
         new Item{Name="Бесконечно убывающая геометрическая прогрессия. Формула суммы",  Value="S = b1 / (1 - q)"},

                  new Item{Name="Длина вектора",  Value="|a| = √(xa^2 - ya^2)"},
                  new Item{Name="Середина отрезка",  Value="t = (ta + tb) / 2"},
                  new Item{Name="Расстояние между точками А и В",  Value="AB = √((xb - xa)^2 + (yb - ya)^2)"},

                  new Item{Name="Сумма косинуа и синуса",  Value="t = cos^2(a) + sin^2(b)"},
                  new Item{Name="Сложение тангенса и котангенса",  Value="t = tg(a) + ctg(b)"},
                  new Item{Name="Тангенс",  Value="tg(a) = sin(b)/cos(c)"},
                  new Item{Name="Тангенс",  Value="tg(a) = 1 / ctg(a)"},
                  new Item{Name="Котангенс",  Value="сtg(a) = cos(b) / sin(c)"},
                  new Item{Name="Котангенс",  Value="ctg(a) = 1 / tg(a)"},
                  new Item{Name="Нахождение тангенса",  Value="1 + tg^2(a) = 1 / cos^2(a)"},
                  new Item{Name="Нахождение котангенса",  Value="1 + ctg^2(a) = 1 / sin^2(a)"},
                  new Item{Name="Синус двойного угла",  Value="sin2(a) = 2sin(a) * cos(a)"},
                  new Item{Name="Косинус двойного угла",  Value="cos2a = cos^2(a) - sin^2(a)"},
                  new Item{Name="Косинус двойного угла",  Value="cos2a = 2cos^2(a) - 1"},
                  new Item{Name="Косинус двойного угла",  Value="cos2a = 1 - 2sin^2(a)"},


        new Item{Name="Формула приведения. Синус",  Value="sin(π/2 ± t) = cos(t)"},
        new Item{Name="Формула приведения. Синус",  Value="sin(π + t) = -sin(t)"},
        new Item{Name="Формула приведения. Синус",  Value="sin(π - t) = sin(t)"},
        new Item{Name="Формула приведения. Синус",  Value="sin(3π/2 ± t) = -cos(t)"},
        new Item{Name="Формула приведения. Синус",  Value="sin(2π + t) = sin(t)"},
        new Item{Name="Формула приведения. Синус",  Value="sin(2π - t) = -sin(t)"},

        new Item{Name="Формула приведения. Косинус",  Value="cos(π/2 + t) = -sin(t)"},
        new Item{Name="Формула приведения. Косинус",  Value="cos(π/2 - t) = sin(t)"},
        new Item{Name="Формула приведения. Косинус",  Value="cos(π ± t) = -cos(t)"},
        new Item{Name="Формула приведения. Косинус",  Value="cos(3π/2 + t) = sin(t)"},
        new Item{Name="Формула приведения. Косинус",  Value="cos(3π/2 - t) = -sin(t)"},
        new Item{Name="Формула приведения. Косинус",  Value="cos(2π ± t) = cos(t)"},

        new Item{Name="Формула приведения. Тангенс",  Value="tg(π/2 + t) = -cos(t)"},
        new Item{Name="Формула приведения. Тангенс",  Value="tg(π/2 - t) = cos(t)"},
        new Item{Name="Формула приведения. Тангенс",  Value="tg(π + t) = tg(t)"},
        new Item{Name="Формула приведения. Тангенс",  Value="tg(π - t) = -tg(t)"},
        new Item{Name="Формула приведения. Тангенс",  Value="tg(3π/2 + t) = -ctg(t)"},
        new Item{Name="Формула приведения. Тангенс",  Value="tg(3π/2 - t) = ctg(t)"},
        new Item{Name="Формула приведения. Тангенс",  Value="tg(2π + t) = tg(t)"},
        new Item{Name="Формула приведения. Тангенс",  Value="tg(2π - t) = -tg(t)"},

        new Item{Name="Формула приведения. Котангенс",  Value="ctg(π/2 - t) = tg(t)"},
        new Item{Name="Формула приведения. Котангенс",  Value="ctg(π/2 + t) = -tg(t)"},
        new Item{Name="Формула приведения. Котангенс",  Value="ctg(π - t) = -ctg(t)"},
        new Item{Name="Формула приведения. Котангенс",  Value="ctg(π + t) = ctg(t)"},
        new Item{Name="Формула приведения. Котангенс",  Value="ctg(3π/2 - t) = -tg(t)"},
        new Item{Name="Формула приведения. Котангенс",  Value="ctg(3π/2 + t) = -tg(t)"},
        new Item{Name="Формула приведения. Котангенс",  Value="ctg(2π - t) = -ctg(t)"},
        new Item{Name="Формула приведения. Котангенс",  Value="ctg(2π + t) = ctg(t)"},
    };
    public Algebra()
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
            //Переход на страницу решений
            await Navigation.PushAsync(new DecisionPage((e.CurrentSelection[0] as Item).Value));
        }
        //Сбрасываем выбор для возможности выбора второй раз подряд
        SelectionCollection.SelectedItem = null;
    }
}