using System.Collections.ObjectModel;

namespace Calculator;

public partial class Phys : ContentPage
{
    private CollectionView SelectionCollection { get; set; }

    //Динамический словарь формул и имён
    public ObservableCollection<Item> Formules { get; set; } = new ObservableCollection<Item>
    {
        new Item{Name="Формула нахождение скорости в пути",  Value="V = S/t"},
        new Item{Name = "Формула нахождения времени в пути",Value= "t = S/V" },
        new Item { Name = "Формула нахождения расстояния", Value = "S = V*t" },
        new Item { Name = "Формула нахождения ускорения", Value = "a = (V2 - V1) / t" },
        new Item { Name = "Формула равноускоренного движения", Value = "S = V1*t + (1/2)at^2" },
        new Item { Name = "Закон всемирного тяготения", Value = "F = G*(m1*m2)/r^2" },
        new Item { Name = "Второй закон Ньютона", Value = "F = m*a" },
        new Item { Name = "Закон Архимеда", Value = "F_A = p * g * V" },
        new Item { Name = "Показатель преломления", Value = "n = c/V" },
        new Item { Name = "Формула расчета силы Ампера", Value = "F = B * I * L * sinα" },
         new Item { Name = "Формула расчета силы Лоренца", Value = "F = q * B * υ * sinα" },
          new Item { Name = "Формула радиуса движения частицы в магнитном поле", Value = "r = m * υ / q * B" },
          new Item { Name = "Формула для вычисления магнитного потока", Value = "r = m * υ / q * B" },
          new Item { Name = "Формула для вычисления величины заряда", Value = "q = I * t" },
          new Item { Name = "Закон Ома для участка цепи", Value = "I = U / R" },
          new Item { Name = "Формула для вычисления удельного сопротивления проводника", Value = "R = ρ * L / S" },
          new Item { Name = "Формула для вычисления удельного сопротивления проводника", Value = "ρ = R * S / L" },
          new Item { Name = "Законы последовательного соединения проводников", Value = "U = U1 + U2" },
          new Item { Name = "Законы последовательного соединения проводников", Value = "R = R1 + R2" },

          new Item { Name = "Законы параллельного соединения проводников", Value = "I = I1 + I2" },
          new Item { Name = "Законы параллельного соединения проводников", Value = "1/R = 1/R1 + 1/R2" },

          new Item { Name = "Формула для нахождения работы электрического тока", Value = "A = U * q" },
          new Item { Name = "Формула для нахождения работы электрического тока", Value = "A = U * I * t" },

          new Item { Name = "Формула электрической мощности", Value = "P = A / t" },
          new Item { Name = "Формула электрической мощности", Value = "P = U * I" },
          new Item { Name = "Формула электрической мощности", Value = "P = U^2 / R" },

          new Item { Name = "Формула закона Джоуля-Ленца", Value = "Q = I^2 * R * t" },

          new Item { Name = "Формула вычисления абсолютного показателя преломления вещества", Value = "n = c/v" },

          new Item { Name = "Показатель преломления среды", Value = "n = sinα / sinγ" },

          new Item { Name = "Преломляющий угол призмы", Value = "δ = α * (n – 1)" },
          new Item { Name = "Линейное увеличение оптической системы", Value = "Г = H / h" },
                      new Item { Name = "Формула оптической силы линзы", Value = "D = 1 / F" },
                                  new Item { Name = "Формула тонкой линзы", Value = "1/F = 1/d + 1/f" },
                                    new Item { Name = "Максимальная результирующая интенсивность", Value = "Δt = m * T" },
          new Item { Name = "Минимальная результирующая интенсивность", Value = "Δt = (2m + 1) * T / 2" },
            new Item { Name = "Геометрическая разность хода интерферирующих волн", Value = "Δ = m * λ" },
              new Item { Name = "Условие интерференционного минимума", Value = "Δ = (2m + 1) * λ / 2" },
                new Item { Name = "Условие дифракционного минимума на щели", Value = "A = (m * λ) / sinα" },
                  new Item { Name = "Условие главных максимумов при дифракции", Value = "d = (m * λ) / sinα" },

                    new Item { Name = "Энергия кванта излучения", Value = "E = h * ϑ" },
                      new Item { Name = "Закон смещения Вина", Value = "b = λ * T" },
                      new Item { Name = "Закон Стефана-Больцмана", Value = "R = ϭ * T^4" },
                      new Item { Name = "Массовое число", Value = "M = Z + N" },
                      new Item { Name = "Формула массы ядра", Value = "Мя = Мa – Z * me" },
                      new Item { Name = "Формула дефекта масс", Value = "∆m = Z*mp + N*mn – Mя" },
                      new Item { Name = "Формула энергии связи", Value = "Е = ∆m * c^2" },
                      new Item { Name = "Закон радиоактивного распада", Value = "N = N0 * 2^(–t/T*1/2)" },
                      new Item { Name = "Доза поглощенного излучения", Value = "D = E / m" },
                      new Item { Name = "Эквивалентная доза поглощенного излучения", Value = "H = D * k" },
    };

    public Phys()
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
//Класс структуры элемента формулы(имя и значение) в коллекции
public class Item
{
    public string Name { get; set; }
    public string Value { get; set; }
}