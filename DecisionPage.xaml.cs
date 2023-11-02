using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui;

namespace Calculator;

//Страница решения
public partial class DecisionPage : ContentPage
{
    //Словарь переменных и обозначений
    Dictionary<string, string> data = new Dictionary<string, string>();
    //Список полей для ввода
    private List<Entry> entries = new List<Entry>();
    //Список решений
    private Dictionary<string, Func<Dictionary<string, double>, double>> actions = new Dictionary<string, Func<Dictionary<string, double>, double>>();
    //Отобранный словарь переменных и отображений
    private Dictionary<string, double> variables = new Dictionary<string, double>();
    public DecisionPage(string formula)
	{
		InitializeComponent();

        //Отображаем формулу в Navigation Bar
		Toolbar.Title = formula;

        //Передаём формулу и ищем для неё решение. Также добавляем в списки данные чтобы потом отобразить их
        switch (formula)
        {
            #region Физика 
            case "V = S/t":
                {
                    data.Add("V", "- скорость тела (км/ч)");
                    data.Add("S", "- пройденное телом расстояние (км)");
                    data.Add("t", "- затраченное время (ч)");

                    actions.Add("V", (i) => i["S"] / i["t"]);
                }
                break;

            case "S = V*t":
                data.Add("v", "- скорость тела (км/ч)");
                data.Add("s", "- пройденное телом расстояние (км)");
                data.Add("t", "- затраченное время (ч)");
                actions.Add("s", (i) => i["v"] * i["t"]);
                break;

            case "t = S/V":
                data.Add("V", "- скорость тела (км/ч)");
                data.Add("S", "- пройденное телом расстояние (км)");
                data.Add("t", "- затраченное время (ч)");
                actions.Add("t", (i) => i["S"] / i["V"]);
                break;

            case "a = (V2 - V1) / t":
                data.Add("a", "- ускорение");
                data.Add("V1", "- скорость 1");
                data.Add("V2", "- скорость 2");
                data.Add("t", "- время");

                actions.Add("a", (i) => (i["V2"] - i["V1"]) / i["t"]);
                break;

            case "S = V1*t + (1/2)at^2":
                data.Add("a", "- ускорение");
                data.Add("S", "- перемещение");
                data.Add("V1", "- 1 скорость");
                data.Add("t", "- время");

                actions.Add("s", (i) =>
                {
                    double d = Math.Pow(i["t"], 2);
                    return (i["V1"] * i["t"] + (1d / 2d) * i["a"] * d);
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
                    return (i["G"] * (i["m1"] * i["m2"]) / r);
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

            //New
            case "F = B * I * L * sinα":
                data.Add("F", "- сила Ампера");
                data.Add("B", "– магнитная индукция, [Тл]");
                data.Add("I", "– сила тока, [А]");
                data.Add("L", "– длина проводника, [м]");
                data.Add("α", "– угол между вектором индукции магнитного поля и проводником");

                actions.Add("F", (i) =>
                {
                    double sin = Math.Sin(i["α"] * Math.PI / 180);
                    return (i["B"] * i["I"] * i["L"] * sin);
                });
                break;

            case "F = q * B * υ * sinα":
                data.Add("F", "– сила Лоренца, [Н]");
                data.Add("q", "– заряд, [Кл]");
                data.Add("B", "– магнитная индукция, [Тл]");
                data.Add("υ", "– скорость движения заряда, [м/с]");
                data.Add("α", "– угол между вектором магнитного поля и скоростью движения частицы");

                actions.Add("F", (i) =>
                {
                    double sin = Math.Sin(i["α"] * Math.PI / 180);
                    return (i["q"] * i["B"] * i["υ"] * sin);
                });
                break;

            case "r = m * υ / q * B":
                data.Add("r", "– радиус окружности, по которой движется частица в магнитном поле, [м]");
                data.Add("m", "– масса частицы, [кг]");
                data.Add("q", "– заряд, [Кл]");
                data.Add("υ", "– скорость движения заряда, [м/с]");
                data.Add("B", "– магнитная индукция, [Тл]");

                actions.Add("r", (i) =>
                {
                    return ((i["m"] * i["υ"]) / (i["B"] * i["q"]));
                });
                break;

            case "Ф = B * S * cosα":
                data.Add("Ф", "– магнитный поток, [Вб]");
                data.Add("B", "– магнитная индукция, [Тл]");
                data.Add("S", "– площадь контура, [м2]");
                data.Add("α", "– угол");

                actions.Add("Ф", (i) =>
                {
                    double cos = Math.Cos(i["α"] * Math.PI / 180);
                    return (i["S"] * i["B"] * cos);
                });
                break;

            case "q = I * t":
                data.Add("q", "– заряд, [Кл]");
                data.Add("I", "– сила тока, [А]");
                data.Add("t", "– время, [c]");

                actions.Add("q", (i) =>
                {
                    return i["I"] * i["t"];
                });
                break;

            case "I = U / R":
                data.Add("I", "– сила Лоренца, [Н]");
                data.Add("U", "– заряд, [Кл]");
                data.Add("R", "– магнитная индукция, [Тл]");

                actions.Add("I", (i) =>
                {
                    return (i["U"] / i["R"]);
                });
                break;

            case "R = ρ * L / S":
                data.Add("R", "– сила Лоренца, [Н]");
                data.Add("ρ", "– заряд, [Кл]");
                data.Add("L", "– магнитная индукция, [Тл]");
                data.Add("S", "– скорость движения заряда, [м/с]");

                actions.Add("R", (i) =>
                {
                    return (i["ρ"] * i["L"] / i["S"]);
                });
                break;

            case "ρ = R * S / L":
                data.Add("R", "– сила Лоренца, [Н]");
                data.Add("ρ", "– заряд, [Кл]");
                data.Add("L", "– магнитная индукция, [Тл]");
                data.Add("S", "– скорость движения заряда, [м/с]");

                actions.Add("ρ", (i) =>
                {
                    return (i["R"] * i["S"] / i["L"]);
                });
                break;

            case "U = U1 + U2":
                data.Add("U", "– общее напряжение, [В]");
                data.Add("U1", "– напряжение 1 элемента, [В]");
                data.Add("U2", "– напряжение 2 элемента, [В]");

                actions.Add("U", (i) =>
                {
                    return (i["U1"] + i["U2"]);
                });
                break;

            case "R = R1 + R2":
                data.Add("R", "– общее сопротивление, [Ом]");
                data.Add("R1", "– сопротивление 1 элемента, [Ом]");
                data.Add("R2", "– сопротивление 2 элемента, [Ом]");

                actions.Add("R", (i) =>
                {
                    return (i["R1"] + i["R2"]);
                });
                break;

            case "1/R = 1/R1 + 1/R2":
                data.Add("R", "– общее сопротивление, [Ом]");
                data.Add("R1", "– сопротивление 1 элемента, [Ом]");
                data.Add("R2", "– сопротивление 2 элемента, [Ом]");

                actions.Add("R", (i) =>
                {
                    return 1 / ((1 / i["R1"]) + (1 / i["R2"]));
                });
                break;

            case "I = I1 + I2":
                data.Add("I", "– общая сила тока, [А]");
                data.Add("I1", "– сила тока 1 элемента, [А]");
                data.Add("I2", "– сила тока 2 элемента, [А]");

                actions.Add("I", (i) =>
                {
                    return i["I1"] + i["I2"];
                });
                break;

            case "A = U * I * t":
                data.Add("A", "– работа электрического тока, [Дж]");
                data.Add("U", "– напряжение на концах участка, [В]]");
                data.Add("I", "– сила тока, [А]");
                data.Add("t", "– время, [c]");

                actions.Add("A", (i) =>
                {
                    return i["U"] * i["I"] * i["t"];
                });
                break;

            case "A = U * q":
                data.Add("A", "– работа электрического тока, [Дж]");
                data.Add("U", "– напряжение на концах участка, [В]]");
                data.Add("q", "– заряд, [Кл]");

                actions.Add("A", (i) =>
                {
                    return i["U"] * i["q"];
                });
                break;

            case "P = A / t":
                data.Add("P", "– электрическая мощность, [Вт]");
                data.Add("A", "– работа электрического тока, [Дж]");
                data.Add("t", "– время, [c]");

                actions.Add("P", (i) =>
                {
                    return i["A"] / i["t"];
                });
                break;

            case "P = U * I":
                data.Add("P", "– электрическая мощность, [Вт]");
                data.Add("U", "– напряжение на концах участка, [В]");
                data.Add("I", "– сила тока, [А]");

                actions.Add("P", (i) =>
                {
                    return i["U"] * i["I"];
                });
                break;

            case "P = U^2 / R":
                data.Add("P", "– электрическая мощность, [Вт]");
                data.Add("U", "– напряжение на концах участка, [В]");
                data.Add("R", "– сопротивление, [Ом]");

                actions.Add("P", (i) =>
                {
                    double u = Math.Pow(i["U"], 2);
                    return u / i["R"];
                });
                break;

            case "Q = I^2 * R * t":
                data.Add("Q", "– количество теплоты, [Дж]");
                data.Add("I", "– сила тока, [А]");
                data.Add("R", "– сопротивление, [Ом]");
                data.Add("t", "– время, [с]");

                actions.Add("Q", (i) =>
                {
                    double i_ = Math.Pow(i["I"], 2);
                    return i_ * i["R"] * i["t"];
                });
                break;

            case "n = c/V":
                data.Add("n", "– абсолютный показатель преломления вещества");
                data.Add("c", "- скорость света в вакууме, [м/с]");
                data.Add("v", "– скорость света в данной среде, [м/с]");

                actions.Add("n", (i) =>
                {
                    return i["c"] / i["v"];
                });
                break;

            case "n = sinα / sinγ":
                data.Add("n", "– показатель преломления среды");
                data.Add("α", "– углол падения ");
                data.Add("γ", "– угол преломления");

                actions.Add("n", (i) =>
                {
                    double a = Math.Sin(i["α"] * Math.PI / 180);
                    double y = Math.Sin(i["γ"] * Math.PI / 180);
                    return a / y;
                });
                break;

            case "δ = α * (n – 1)":
                data.Add("δ", "– угол отклонения");
                data.Add("α", "– угол падения ");
                data.Add("n", "– показатель преломления среды");

                actions.Add("δ", (i) =>
                {
                    return i["α"] * (i["n"] - 1);
                });
                break;

            case "Г = H / h":
                data.Add("Г", "– линейное увеличени");
                data.Add("H", "– размер изображения, [м]");
                data.Add("h", "– размер предмета, [м]");

                actions.Add("Г", (i) =>
                {
                    return i["H"] / i["h"];
                });
                break;

            case "D = 1 / F":
                data.Add("D", "– оптическая сила линзы, [дптр]");
                data.Add("F", "– фокусное расстояние линзы, [м]");

                actions.Add("D", (i) =>
                {
                    return 1 / i["F"];
                });
                break;

            case "1/F = 1/d + 1/f":
                data.Add("F", "– фокусное расстояние линзы, [м]");
                data.Add("d", "– расстояние от предмета до линзы, [м]");
                data.Add("f", "– расстояние от линзы до изображения, [м]");

                actions.Add("F", (i) =>
                {
                    return 1 / ((1 / i["d"]) + (1 / i["f"]));
                });
                break;

            case "Δt = m * T":
                data.Add("t", "– максимальная результирующая интенсивность");
                data.Add("m", "– переменная");
                data.Add("T", "– период колебании, [с]");

                actions.Add("t", (i) =>
                {
                    return i["m"] * i["T"];
                });
                break;

            case "Δt = (2m + 1) * T / 2":
                data.Add("t", "– максимальная результирующая интенсивность");
                data.Add("m", "– переменная");
                data.Add("T", "– период колебании, [с]");

                actions.Add("t", (i) =>
                {
                    return (2 * i["m"] + 1) * i["T"] / 2;
                });
                break;

            case "Δ = m * λ":
                data.Add("Δ", "– геометрическая разность хода интерферирующих волн");
                data.Add("m", "– переменная");
                data.Add("λ", "– длина волны, [м]");

                actions.Add("Δ", (i) =>
                {
                    return i["m"] * i["λ"];
                });
                break;

            case "Δ = (2m + 1) * λ / 2":
                data.Add("Δ", "– геометрическая разность хода интерферирующих волн");
                data.Add("m", "– переменная");
                data.Add("λ", "– длина волны, [м]");

                actions.Add("Δ", (i) =>
                {
                    return (2 * i["m"] + 1) * i["λ"] / 2;
                });
                break;

            case "A = (m * λ) / sinα":
                data.Add("A", "– ширина щели, [м]");
                data.Add("m", "– переменная");
                data.Add("λ", "– длина волны, [м]");
                data.Add("α", "– угол");

                actions.Add("A", (i) =>
                {
                    double a = Math.Sin(i["α"] * Math.PI / 180);
                    return (i["m"] * i["λ"]) / a;
                });
                break;

            case "d = (m * λ) / sinα":
                data.Add("d", "– геометрическая разность хода интерферирующих волн");
                data.Add("m", "– переменная");
                data.Add("λ", "– длина волны, [м]");
                data.Add("α", "– угол");

                actions.Add("d", (i) =>
                {
                    double a = Math.Sin(i["α"] * Math.PI / 180);
                    return (i["m"] * i["λ"]) / a;
                });
                break;

            case "E = h * ϑ":
                data.Add("E", "– энергия кванта излучения, [Дж]");
                data.Add("h", "– постоянная Планка");
                data.Add("ϑ", "– частота излучения");

                actions.Add("E", (i) =>
                {
                    return i["h"] * i["ϑ"];
                });
                break;

            case "b = λ * T":
                data.Add("b", "– постоянная Вина");
                data.Add("λ", "– длина волны, [м]");
                data.Add("T", "– температура черного тела");

                actions.Add("b", (i) =>
                {
                    return i["λ"] * i["T"];
                });
                break;

            case "R = ϭ * T^4":
                data.Add("ϭ", "– постоянная Стефана-Больцмана");
                data.Add("T", "– абсолютная температура черного тела");
                data.Add("R", "– интегральная светимость абсолютно черного тела");

                actions.Add("R", (i) =>
                {
                    double t = Math.Pow(i["T"], 4);
                    return i["ϭ"] * t;
                });
                break;

            case "M = Z + N":
                data.Add("M", "– массовое число");
                data.Add("Z", "– число протонов");
                data.Add("N", "– число нейтронов");

                actions.Add("M", (i) =>
                {
                    return i["N"] + i["Z"];
                });
                break;

            case "Мя = Мa – Z * me":
                data.Add("Mя", "– масса ядра, [кг]");
                data.Add("Мa", "– масса изотопа, [кг]");
                data.Add("Z", "– зарядовое число");
                data.Add("me", "– масса электрона, [кг]");

                actions.Add("Mя", (i) =>
                {
                    return i["Мa"] - i["Z"] * i["me"];
                });
                break;

            case "∆m = Z*mp + N*mn – Mя":
                data.Add("∆m", "– дефект масс, [кг]");
                data.Add("Z", "– число протонов в ядре");
                data.Add("mp", "– масса протона, [кг]");
                data.Add("mn", "– масса нейтрона, [кг]");
                data.Add("N", "– число нейтронов в ядре");
                data.Add("Mя", "– масса изотопа, [кг]");

                actions.Add("∆m", (i) =>
                {
                    return i["Z"] * i["mp"] + i["N"] * i["mn"] - i["Mя"];
                });
                break;

            case "Е = ∆m * c^2":
                data.Add("Е", "– масса ядра, [кг]");
                data.Add("∆m", "– масса изотопа, [кг]");
                data.Add("c", "– зарядовое число");

                actions.Add("Е", (i) =>
                {
                    double c = Math.Pow(i["c"], 2);
                    return i["∆m"] * c;
                });
                break;

            case "N = N0 * 2^(–t/T*1/2)":
                data.Add("N", "– конечное количество ядер");
                data.Add("N0", " – первоначальное количество ядер");
                data.Add("t", " – время, [c]");
                data.Add("T", " – период полураспада, [c]");

                actions.Add("N", (i) =>
                {
                    double pow = Math.Pow(2, -i["t"] / i["T"] * 0.5);
                    return i["N0"] * pow;
                });
                break;

            case "D = E / m":
                data.Add("D", "– доза поглощенного излучения, [Гр]");
                data.Add("E", "– энергия излучения, [Дж]");
                data.Add("m", "– масса тела, [кг]");

                actions.Add("D", (i) =>
                {
                    return i["E"] / i["m"];
                });
                break;

            case "H = D * k":
                data.Add("H", "– эквивалентная доза поглощенного излучения, [Зв]");
                data.Add("D", "– доза поглощенного излучения, [Гр]");
                data.Add("k", "– коэффициент качества");

                actions.Add("H", (i) =>
                {
                    return i["D"] * i["k"];
                });
                break;
            #endregion

            #region Алгебра
            case "a = b^n":
                data.Add("a", "– результат");
                data.Add("b", "– возводимое число]");
                data.Add("n", "– степень");

                actions.Add("a", (i) =>
                {
                    return Math.Pow(i["b"], i["n"]);
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
                    return ((-i["b"] - b) / (2 * i["a"]));
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

            case "t = n√a":
                data.Add("a", "- число из которого будут излекать корень");
                data.Add("n", "- число степени корня");
                data.Add("t", "- результат");

                actions.Add("t", (i) =>
                {
                    return Math.Pow(i["a"], 1 / i["n"]);
                });
                break;

            case "t = (a - b) * (a + b) = a^2 - b^2":
                data.Add("a", "- 1 переменная");
                data.Add("b", "- 2 переменная");
                data.Add("t", "- результат");

                actions.Add("t", (i) =>
                {
                    return Math.Pow(i["a"], 2) - Math.Pow(i["b"], 2);
                });
                break;

            case "t = (a - b)^2 = a^2 - 2ab + b^2":
                data.Add("a", "- 1 переменная");
                data.Add("b", "- 2 переменная");
                data.Add("t", "- результат");

                actions.Add("t", (i) =>
                {
                    return Math.Pow(i["a"] - i["b"], 2);
                });
                break;

            case "t = (a - b)^2 = (b - a)^2":
                data.Add("a", "- 1 переменная");
                data.Add("b", "- 2 переменная");
                data.Add("t", "- результат");

                actions.Add("t", (i) =>
                {
                    return Math.Pow(i["a"] - i["b"], 2);
                });
                break;

            case "t = (a + b)^2 = a^2 + 2ab + b^2":
                data.Add("a", "- 1 переменная");
                data.Add("b", "- 2 переменная");
                data.Add("t", "- результат");

                actions.Add("t", (i) =>
                {
                    return Math.Pow(i["a"] + i["b"], 2);
                });
                break;

            case "t = a^3 - b^3 = (a - b) * (a^2 + ab + b^2)":
                data.Add("a", "- 1 переменная");
                data.Add("b", "- 2 переменная");
                data.Add("t", "- результат");

                actions.Add("t", (i) =>
                {
                    return Math.Pow(i["a"], 3) - Math.Pow(i["b"], 3);
                });
                break;

            case "t = a^3 + b^3 = (a + b) * (a^2 - ab + b^2)":
                data.Add("a", "- 1 переменная");
                data.Add("b", "- 2 переменная");
                data.Add("t", "- результат");

                actions.Add("t", (i) =>
                {
                    return Math.Pow(i["a"], 3) + Math.Pow(i["b"], 3);
                });
                break;

            case "t = (a - b)^3 = a^3 - 3a^2b + 3b^2 - b^3":
                data.Add("a", "- 1 переменная");
                data.Add("b", "- 2 переменная");
                data.Add("t", "- результат");

                actions.Add("t", (i) =>
                {
                    return Math.Pow(i["a"] - i["b"], 3);
                });
                break;

            case "t = (a + b)^3 = a^3 + 3a^2b + 3b^2 + b^3":
                data.Add("a", "- 1 переменная");
                data.Add("b", "- 2 переменная");
                data.Add("t", "- результат");

                actions.Add("t", (i) =>
                {
                    return Math.Pow(i["a"] + i["b"], 3);
                });
                break;

            case "an = a1 + (n - 1) * d":
                data.Add("an", "- результат");
                data.Add("a1", "- первое число в последовательности");
                data.Add("n", "- число");
                data.Add("d", "- разность арифметической прогрессии");

                actions.Add("an", (i) =>
                {
                    return i["a1"] + (i["n"] - 1) * i["d"];
                });
                break;

            case "an+1 = an + d":
                data.Add("an+1", "- результат");
                data.Add("an", "- любое число арифметической последовательности");
                data.Add("d", "- разность арифметической прогрессии");

                actions.Add("an+1", (i) =>
                {
                    return i["an"] + i["d"];
                });
                break;

            case "an = (an+1 + an-1)/2":
                data.Add("an+1", "- число арифметической последовательности, стоящее после выбранного числом");
                data.Add("an-1", "- число арифметической последовательности, стоящее перед выбранным числом");
                data.Add("an", "- число арифметической последовательности");

                actions.Add("an", (i) =>
                {
                    return (i["an+1"] + i["an-1"]) / 2;
                });
                break;

            case "Sn = (a1 + an)/2 * n":
                data.Add("Sn", "- сумма");
                data.Add("a1", "- первое число в последовательности");
                data.Add("n", "- число");
                data.Add("an", "- любое число арифметической прогрессии");

                actions.Add("Sn", (i) =>
                {
                    return (i["a1"] + i["an"]) / 2 * i["n"];
                });
                break;

            case "Sn = (2a1 + (n-1) * d)/2 * n":
                data.Add("Sn", "- сумма");
                data.Add("a1", "- первое число в последовательности");
                data.Add("n", "- число");
                data.Add("d", "- разность арифметической прогрессии");

                actions.Add("Sn", (i) =>
                {
                    return (2 * i["a1"] + (i["n"]-1) * i["d"]) / 2 * i["n"];
                });
                break;

            case "d = (an - am) / (n - m)":
                data.Add("n", "- 1 число");
                data.Add("m", "- 2 число");
                data.Add("an", "- 1 любое число арифметической прогрессии");
                data.Add("am", "- 2 любое число арифметической прогрессии");
                data.Add("d", "- разность арифметической прогрессии");

                actions.Add("d", (i) =>
                {
                    return (i["an"] - i["am"]) / (i["n"] - i["m"]);
                });
                break;

            case "bn = b1 * q^n-1":
                data.Add("bn", "- результат");
                data.Add("b1", "- любое число геометрической прогрессии");
                data.Add("q", "- знаменатель прогрессии");
                data.Add("n", "- число");

                actions.Add("bn", (i) =>
                {
                    return (i["b1"] * Math.Pow(i["q"], i["n"] - 1));
                });
                break;

            case "bn+1 = bn * q":
                data.Add("bn+1", "- результат");
                data.Add("bn", "- число");
                data.Add("q", "- знаменатель прогрессии");

                actions.Add("bn+1", (i) =>
                {
                    return (i["bn"] * i["q"]);
                });
                break;

            case "bn^2 = bn+1 * bn-1":
                data.Add("bn^2", "- результат");
                data.Add("bn+1", "- 1 число");
                data.Add("bn-1", "- 2 число");

                actions.Add("bn^2", (i) =>
                {
                    return Math.Sqrt( i["bn+1"] * i["bn-1"]);
                });
                break;

            case "Sn = (b1 - bn * q) / 1 - q":
                data.Add("Sn", "- сумма");
                data.Add("b1", "- первое число в последовательности");
                data.Add("bn", "- число");
                data.Add("q", "- знаменатель прогрессии");

                actions.Add("Sn", (i) =>
                {
                    return (i["b1"] - i["bn"] * i["q"]) / 1 - i["q"];
                });
                break;

            case "Sn = b1 * (1 - q^n) / 1 - q":
                data.Add("Sn", "- сумма");
                data.Add("b1", "- первое число в последовательности");
                data.Add("n", "- число");
                data.Add("q", "- знаменатель прогрессии");

                actions.Add("Sn", (i) =>
                {
                    return i["b1"] * (1 - Math.Pow(i["q"], i["n"])) / (1 - i["q"]);
                });
                break;

            case "q^(n-m) = bn / bm":
                data.Add("n", "- 1 число");
                data.Add("m", "- 2 число");
                data.Add("bn", "- число последовательности");
                data.Add("bm", "- число последовательности");
                data.Add("q", "- знаменатель прогрессии");

                actions.Add("q", (i) =>
                {
                    return Math.Pow( i["bn"] / i["bm"], 1/(i["n"] - i["m"]));
                });
                break;

            case "S = b1 / (1 - q)":
                data.Add("S", "- сумма");
                data.Add("b1", "- первое число в последовательности");
                data.Add("q", "- число");

                actions.Add("S", (i) =>
                {
                    return i["b1"] / (1 - i["q"]);
                });
                break;

            case "|a| = √(xa^2 - ya^2)":
                data.Add("|a|", "- модуль");
                data.Add("xa", "- начальная координата прямой x");
                data.Add("ya", "- начальная координата прямой y");

                actions.Add("|a|", (i) =>
                {
                    return Math.Abs(Math.Sqrt(Math.Pow(i["xa"],2) - Math.Pow(i["ya"], 2)));
                });
                break;

            case "t = (ta + tb) / 2":
                data.Add("t", "- результат");
                data.Add("ta", "- начальная координата прямой");
                data.Add("tb", "- конечная координата прямой");

                actions.Add("t", (i) =>
                {
                    return (i["ta"] + i["tb"]) / 2;
                });
                break;

            case "AB = √((xb - xa)^2 + (yb - ya)^2)":
                data.Add("AB", "- результат");
                data.Add("xa", "- начальная координата прямой x");
                data.Add("xb", "- конечная координата прямой x");
                data.Add("ya", "- начальная координата прямой y");
                data.Add("yb", "- конечная координата прямой y");

                actions.Add("AB", (i) =>
                {
                    return Math.Sqrt(Math.Pow(i["xb"] - i["xa"], 2) + Math.Pow(i["yb"] - i["ya"], 2));
                });
                break;

            case "t = cos^2(a) + sin^2(b)":
                data.Add("t", "- результат");
                data.Add("a", "- угол косинуса");
                data.Add("b", "- угол синуса");

                actions.Add("t", (i) =>
                {
                    return Math.Pow(Math.Cos(i["a"]), 2) + Math.Pow(Math.Sin(i["b"]), 2);
                });
                break;

            case "t = tg(a) + ctg(b)":
                data.Add("t", "- результат");
                data.Add("a", "- угол тангенса");
                data.Add("b", "- угол котангенса");

                actions.Add("t", (i) =>
                {
                    return Math.Tan(i["a"] * Math.PI / 180) + (1 / Math.Tan(i["b"] * Math.PI / 180));
                });
                break;

            case "tg(a) = sin(b)/cos(c)":
                data.Add("tg(a)", "- результат");
                data.Add("b", "- угол синуса");
                data.Add("c", "- угол косинуса");

                actions.Add("tg(a)", (i) =>
                {
                    return Math.Sin(i["b"] * Math.PI / 180) / Math.Cos(i["c"] * Math.PI / 180);
                });
                break;

            case "tg(a) = 1 / ctg(a)":
                data.Add("tg(a)", "- результат");
                data.Add("a", "- угол котангенса");

                actions.Add("tg(a)", (i) =>
                {
                    return 1 / (1/Math.Tan(i["a"] * Math.PI / 180));
                });
                break;

            case "сtg(a) = cos(b) / sin(c)":
                data.Add("сtg(a)", "- результат");
                data.Add("b", "- угол косинуса");
                data.Add("c", "- угол синуса");

                actions.Add("сtg(a)", (i) =>
                {
                    return Math.Cos(i["b"] * Math.PI / 180) / Math.Sin(i["c"] * Math.PI / 180);
                });
                break;

            case "ctg(a) = 1 / tg(a)":
                data.Add("ctg(a)", "- результат");
                data.Add("a", "- угол котангенса");

                actions.Add("ctg(a)", (i) =>
                {
                    return 1 / Math.Tan(i["a"] * Math.PI / 180);
                });
                break;

            case "1 + tg^2(a) = 1 / cos^2(a)":
                data.Add("tg(a)", "- результат");
                data.Add("a", "- угол косинуса");

                actions.Add("tg(a)", (i) =>
                {
                    return Math.Sqrt(  ((1 / Math.Pow(Math.Cos(i["a"] * Math.PI / 180), 2)) - 1) );
                });
                break;

            case "1 + ctg^2(a) = 1 / sin^2(a)":
                data.Add("ctg(a)", "- результат");
                data.Add("a", "- угол синуса");

                actions.Add("ctg(a)", (i) =>
                {
                    return Math.Sqrt(((1 / Math.Pow(Math.Sin(i["a"] * Math.PI / 180), 2)) - 1));
                });
                break;

            case "sin2(a) = 2sin(a) * cos(a)":
                data.Add("sin2(a)", "- результат");
                data.Add("a", "- угол");

                actions.Add("sin2(a)", (i) =>
                {
                    return 2 * Math.Sin(i["a"] * Math.PI / 180) * Math.Cos(i["a"] * Math.PI / 180);
                });
                break;

            case "cos2a = cos^2(a) - sin^2(a)":
                data.Add("cos2(a)", "- результат");
                data.Add("a", "- угол косинуса");

                actions.Add("cos2(a)", (i) =>
                {
                    return Math.Cos(2 * i["a"] * Math.PI / 180);
                });
                break;

            case "cos2a = 2cos^2(a) - 1":
                data.Add("cos2(a)", "- результат");
                data.Add("a", "- угол косинуса");

                actions.Add("cos2(a)", (i) =>
                {
                    return Math.Cos(2 * i["a"] * Math.PI / 180);
                });
                break;

            case "cos2a = 1 - 2sin^2(a)":
                data.Add("cos2(a)", "- результат");
                data.Add("a", "- угол косинуса");

                actions.Add("cos2(a)", (i) =>
                {
                    return Math.Cos(2 * i["a"] * Math.PI / 180);
                });
                break;

            case "sin(π/2 ± t) = cos(t)":
                data.Add("cos(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("cos(t)", (i) =>
                {
                    return Math.Cos(i["t"] * Math.PI / 180);
                });
                break;

            case "sin(π + t) = -sin(t)":
                data.Add("-sin(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("-sin(t)", (i) =>
                {
                    return -Math.Sin(i["t"] * Math.PI / 180);
                });
                break;

            case "sin(π - t) = sin(t)":
                data.Add("sin(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("sin(t)", (i) =>
                {
                    return Math.Sin(i["t"] * Math.PI / 180);
                });
                break;

            case "sin(3π/2 ± t) = -cos(t)":
                data.Add("-cos(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("-cos(t)", (i) =>
                {
                    return -Math.Cos(i["t"] * Math.PI / 180);
                });
                break;

            case "sin(2π + t) = sin(t)":
                data.Add("sin(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("sin(t)", (i) =>
                {
                    return Math.Sin(i["t"] * Math.PI / 180);
                });
                break;

            case "sin(2π - t) = -sin(t)":
                data.Add("-sin(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("-sin(t)", (i) =>
                {
                    return -Math.Sin(i["t"] * Math.PI / 180);
                });
                break;

            case "cos(π/2 + t) = -sin(t)":
                data.Add("-sin(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("-sin(t)", (i) =>
                {
                    return -Math.Sin(i["t"] * Math.PI / 180);
                });
                break;

            case "cos(π/2 - t) = sin(t)":
                data.Add("sin(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("sin(t)", (i) =>
                {
                    return Math.Sin(i["t"] * Math.PI / 180);
                });
                break;

            case "cos(3π/2 + t) = sin(t)":
                data.Add("sin(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("sin(t)", (i) =>
                {
                    return Math.Sin(i["t"] * Math.PI / 180);
                });
                break;

            case "cos(3π/2 - t) = -sin(t)":
                data.Add("-sin(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("-sin(t)", (i) =>
                {
                    return -Math.Sin(i["t"] * Math.PI / 180);
                });
                break;

            case "cos(π ± t) = -cos(t)":
                data.Add("-cos(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("-cos(t)", (i) =>
                {
                    return -Math.Cos(i["t"] * Math.PI / 180);
                });
                break;

            case "cos(2π ± t) = cos(t)":
                data.Add("cos(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("cos(t)", (i) =>
                {
                    return Math.Cos(i["t"] * Math.PI / 180);
                });
                break;

            case "tg(π/2 + t) = -cos(t)":
                data.Add("-cos(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("-cos(t)", (i) =>
                {
                    return -Math.Cos(i["t"] * Math.PI / 180);
                });
                break;

            case "tg(π/2 - t) = cos(t)":
                data.Add("cos(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("cos(t)", (i) =>
                {
                    return Math.Cos(i["t"] * Math.PI / 180);
                });
                break;

            case "tg(π + t) = tg(t)":
                data.Add("tg(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("tg(t)", (i) =>
                {
                    return Math.Tan(i["t"] * Math.PI / 180);
                });
                break;

            case "tg(π - t) = -tg(t)":
                data.Add("-tg(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("-tg(t)", (i) =>
                {
                    return -Math.Tan(i["t"] * Math.PI / 180);
                });
                break;

            case "tg(3π/2 + t) = -ctg(t)":
                data.Add("-ctg(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("-ctg(t)", (i) =>
                {
                    return -1/Math.Tan(i["t"] * Math.PI / 180);
                });
                break;

            case "tg(3π/2 - t) = ctg(t)":
                data.Add("ctg(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("ctg(t)", (i) =>
                {
                    return 1 / Math.Tan(i["t"] * Math.PI / 180);
                });
                break;

            case "tg(2π + t) = tg(t)":
                data.Add("tg(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("tg(t)", (i) =>
                {
                    return Math.Tan(i["t"] * Math.PI / 180);
                });
                break;

            case "tg(2π - t) = -tg(t)":
                data.Add("-tg(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("-tg(t)", (i) =>
                {
                    return -Math.Tan(i["t"] * Math.PI / 180);
                });
                break;

            case "ctg(π/2 - t) = tg(t)":
                data.Add("tg(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("tg(t)", (i) =>
                {
                    return Math.Tan(i["t"] * Math.PI / 180);
                });
                break;

            case "ctg(π/2 + t) = -tg(t)":
                data.Add("-tg(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("-tg(t)", (i) =>
                {
                    return -Math.Tan(i["t"] * Math.PI / 180);
                });
                break;

            case "ctg(π - t) = -ctg(t)":
                data.Add("-ctg(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("-ctg(t)", (i) =>
                {
                    return -1/Math.Tan(i["t"] * Math.PI / 180);
                });
                break;

            case "ctg(π + t) = ctg(t)":
                data.Add("ctg(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("ctg(t)", (i) =>
                {
                    return 1/Math.Tan(i["t"] * Math.PI / 180);
                });
                break;

            case "ctg(3π/2 - t) = -tg(t)":
                data.Add("-tg(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("-tg(t)", (i) =>
                {
                    return -Math.Tan(i["t"] * Math.PI / 180);
                });
                break;

            case "ctg(3π/2 + t) = -tg(t)":
                data.Add("-tg(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("-tg(t)", (i) =>
                {
                    return -Math.Tan(i["t"] * Math.PI / 180);
                });
                break;

            case "ctg(2π - t) = -ctg(t)":
                data.Add("-ctg(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("-ctg(t)", (i) =>
                {
                    return -1/Math.Tan(i["t"] * Math.PI / 180);
                });
                break;

            case "ctg(2π + t) = ctg(t)":
                data.Add("ctg(t)", "- результат");
                data.Add("t", "- угол");

                actions.Add("ctg(t)", (i) =>
                {
                    return 1/Math.Tan(i["t"] * Math.PI / 180);
                });
                break;

            #endregion

            #region Геометрия
            case "S = π * r^2":
                data.Add("s", "- площадь круга");
                data.Add("π", " ≈ 3.14");
                data.Add("r", "- радиус круга");

                actions.Add("s", (i) =>
                {
                    double r = Math.Pow(i["r"], 2);
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
                    return Math.Sqrt(a + b);
                });
                break;

            case "S=1/2 * h * a":
                data.Add("S", "- площадь");
                data.Add("h", "- - высота, проведенная из вершины A)");
                data.Add("a", "- сторона");

                actions.Add("S", (i) =>
                {
                    return 0.5 * i["h"] * i["a"];
                });
                break;

            case "S=1/2 * b * c * sina":
                data.Add("S", "- Площадь");
                data.Add("c", "- сторона");
                data.Add("b", "- сторона");
                data.Add("a", "- угол");

                actions.Add("S", (i) =>
                {
                    double sin = Math.Sin(i["a"] * Math.PI / 180);
                    return 0.5 * i["b"] * i["c"] * sin;
                });
                break;

            case "S=√(p * (p-a) * (p-b) * (p-c))":
                data.Add("S", "- Площадь");
                data.Add("p", "- полупериметр");
                data.Add("a", "- 1 стоорона");
                data.Add("b", "- 2 сторона");
                data.Add("с", "- 3 сторона");

                actions.Add("S", (i) =>
                {
                    return Math.Sqrt(i["p"] * (i["p"] - i["a"]) * (i["p"] - i["b"]) * (i["p"] - i["c"]));
                });
                break;

            case "r = S / p":
                data.Add("r", "- радиус вписанной окружности");
                data.Add("S", "- Площадь");
                data.Add("p", "- полупериметр");

                actions.Add("r", (i) =>
                {
                    return i["S"] / i["p"];
                });
                break;

            case "R = a * b * c / 4S":
                data.Add("R", "- радиус описанной окружности");
                data.Add("a", "-1 сторона");
                data.Add("b", "- 2 сторона");
                data.Add("c", "- 3 сторона");
                data.Add("S", "- Площадь");

                actions.Add("R", (i) =>
                {
                    double a = Math.Pow(i["a"], 2);
                    double b = Math.Pow(i["b"], 2);
                    return (i["a"] * i["b"] * i["c"]) / 4 * i["S"];
                });
                break;

            case "a = √(b^2 + c^2 - 2 * b * Cosα)":
                data.Add("a", "- 1 стоорона");
                data.Add("b", "- 2 сторона");
                data.Add("с", "- 3 сторона");
                data.Add("α", "- угол");

                actions.Add("a", (i) =>
                {
                    double cos = Math.Cos(i["α"] * Math.PI / 180);
                    return Math.Sqrt(Math.Pow(i["b"], 2) + Math.Pow(i["c"], 2) - 2 * cos * i["b"]);
                });
                break;

            case "2R = a / sinα":
                data.Add("a", "-сторона, противоляжащая углу α");
                data.Add("R", "- радиус описанной окружности");
                data.Add("α", "- угол");

                actions.Add("R", (i) =>
                {
                    return (i["a"] / Math.Sin(i["a"] * Math.PI / 180)) / 2;
                });
                break;

            case "S = 1/2 * a * b":
                data.Add("S", "- площадь");
                data.Add("a", "- 1 сторона");
                data.Add("b", "- 2 сторона");

                actions.Add("S", (i) =>
                {
                    return 0.5 * i["a"] * i["b"];
                });
                break;

            case "S = 1/2 * c * h":
                data.Add("S", "- Площадь");
                data.Add("c", "- сторона");
                data.Add("h", "- высота");

                actions.Add("S", (i) =>
                {
                    return 0.5 * i["h"] * i["c"];
                });
                break;

            case "r = (a + b - c) / 2":
                data.Add("r", "- радиус вписанной окружности");
                data.Add("a", "- 1 стоорона");
                data.Add("b", "- 2 сторона");
                data.Add("с", "- 3 сторона");

                actions.Add("r", (i) =>
                {
                    return (i["a"] + i["b"] - i["c"]) / 2;
                });
                break;

            case "R = c / 2":
                data.Add("R", "- радиус вписанной окружности");
                data.Add("c", "- Площадь");

                actions.Add("R", (i) =>
                {
                    return i["c"] / 2;
                });
                break;

            case "a = c * sinα":
                data.Add("α", "- угол");
                data.Add("a", "- 1 сторона");
                data.Add("c", "- 3 сторона");

                actions.Add("a", (i) =>
                {
                    return (i["c"] * Math.Sin(i["α"] * Math.PI / 180));
                });
                break;

            case "a = b * tgα":
                data.Add("a", "- 1 стоорона");
                data.Add("b", "- 2 сторона");
                data.Add("α", "- угол");

                actions.Add("a", (i) =>
                {
                    return i["b"] * Math.Tan(i["α"] * Math.PI / 180);
                });
                break;

            case "a = b / tgβ":
                data.Add("a", "-сторона, противоляжащая углу α");
                data.Add("b", "- радиус описанной окружности");
                data.Add("β", "- угол");

                actions.Add("a", (i) =>
                {
                    return i["b"] / Math.Tan(i["β"] * Math.PI / 180);
                });
                break;

            case "S = (a^2 * √3) / 4":
                data.Add("S", "- Площадь");
                data.Add("a", "- 1 сторона");

                actions.Add("S", (i) =>
                {
                    return (Math.Pow(i["a"], 2) * Math.Sqrt(3)) / 4;
                });
                break;

            case "r = (a * √3) / 6":
                data.Add("a", "-сторона, противоляжащая углу α");
                data.Add("r", "- радиус описанной окружности");

                actions.Add("r", (i) =>
                {
                    return (i["a"] * Math.Sqrt(3)) / 6;
                });
                break;

            case "R = (a * √3) / 3":
                data.Add("R", "- радиус вписанной окружности");
                data.Add("a", "- 1 сторона");

                actions.Add("R", (i) =>
                {
                    return (i["a"] * Math.Sqrt(3)) / 3;
                });
                break;

            case "S = 1/2 * d1 * d2 * sinφ":
                data.Add("S", "- Площадь");
                data.Add("d1", "- сторона");
                data.Add("d2", "- высота");
                data.Add("φ", "- высота");

                actions.Add("S", (i) =>
                {
                    return 0.5 * i["d1"] * i["d2"] * Math.Sin(i["φ"] * Math.PI / 180);
                });
                break;

            case "S = a * h":
                data.Add("S", "- радиус вписанной окружности");
                data.Add("a", "- 1 сторона");
                data.Add("h", "- высота");

                actions.Add("S", (i) =>
                {
                    return i["a"] * i["h"];
                });
                break;

            case "S = a * b * sinα":
                data.Add("S", "- Площадь");
                data.Add("a", "- 1 сторона");
                data.Add("b", "- 2 сторона");
                data.Add("α", "- угол");

                actions.Add("S", (i) =>
                {
                    return i["a"] * i["b"] * Math.Sin(i["α"] * Math.PI / 180);
                });
                break;

            case "S = a^2 * sinA":
                data.Add("S", "- Площадь");
                data.Add("a", "- 1 сторона");
                data.Add("α", "- угол");

                actions.Add("S", (i) =>
                {
                    return Math.Pow(i["a"], 2) * Math.Sin(i["α"] * Math.PI / 180);
                });
                break;

            case "S = 1/2 * d1 * d2":
                data.Add("S", "- Площадь");
                data.Add("d1", "- 1 диагональ");
                data.Add("d2", "- 2 диагональ");

                actions.Add("S", (i) =>
                {
                    return 0.5 * i["d1"] * i["d2"];
                });
                break;

            case "S = a * b":
                data.Add("S", "- Площадь");
                data.Add("a", "- 1 сторона");
                data.Add("b", "- 2 сторона");

                actions.Add("S", (i) =>
                {
                    return i["a"] * i["b"];
                });
                break;


            case "S = a^2":
                data.Add("S", "- Площадь квадрата");
                data.Add("a", "- 1 сторона");

                actions.Add("S", (i) =>
                {
                    return Math.Pow(i["a"], 2);
                });
                break;

            case "S = (d^2) / 2":
                data.Add("S", "- площадь");
                data.Add("d", "- диагональ");

                actions.Add("S", (i) =>
                {
                    return Math.Pow(i["d"], 2) / 2;
                });
                break;

            case "l = a + b / 2":
                data.Add("l", "- средняя линия");
                data.Add("a", "- 1 основание");
                data.Add("b", "- 2 основание");

                actions.Add("l", (i) =>
                {
                    return (i["a"] + i["b"]) / 2;
                });
                break;

            case "S = ((a + b) / 2) * h":
                data.Add("S", "- площадь");
                data.Add("a", "- 1 основание");
                data.Add("b", "- 2 основание");
                data.Add("h", "- высота");

                actions.Add("S", (i) =>
                {
                    return ((i["a"] + i["b"]) / 2) * i["h"];
                });
                break;

            case "S = l * h":
                data.Add("S", "- площадь");
                data.Add("l", "- средняя линия");
                data.Add("h", "- высота");

                actions.Add("S", (i) =>
                {
                    return i["l"] * i["h"];
                });
                break;

            case "S = p * r":
                data.Add("S", "- Площадь");
                data.Add("p", "- периметр");
                data.Add("r", "- радиус вписанной окружности");

                actions.Add("S", (i) =>
                {
                    return i["p"] * i["r"];
                });
                break;

            case "a = 2 * R * sin(180/n)":
                data.Add("a", "- сторона");
                data.Add("R", "- радиус вписанной окружности");
                data.Add("n", "- кол-во углов");

                actions.Add("a", (i) =>
                {
                    return 2 * i["R"] * Math.Sin((180 / i["n"]) * Math.PI / 180);
                });
                break;

            case "S = n * a * r / 2":
                data.Add("S", "- радиус вписанной окружности");
                data.Add("a", "- 1 сторона");
                data.Add("r", "- радиус вписанной окружности");
                data.Add("n", "- кол-во углов");

                actions.Add("S", (i) =>
                {
                    return i["n"] * i["a"] * i["r"] / 2;
                });
                break;

            case "c = 2 * π * r":
                data.Add("c", "- длина");
                data.Add("r", "- радиус вписанной окружности");
                data.Add("π", "- константа ~ 3,14");

                actions.Add("c", (i) =>
                {
                    return 2 * i["r"] * i["π"];
                });
                break;

            case "l = π * r * (n/180)":
                data.Add("l", "- длина дуги");
                data.Add("r", "- радиус вписанной окружности");
                data.Add("π", "- константа ~ 3,14");
                data.Add("n", "- гралусная мера угла");

                actions.Add("l", (i) =>
                {
                    return i["π"] * i["r"] * (i["n"] / 180);
                });
                break;

            case "l = r * a":
                data.Add("l", "- длина дуги");
                data.Add("r", "- радиус вписанной окружности");
                data.Add("a", "- радианная мера центрального угла");

                actions.Add("l", (i) =>
                {
                    return i["r"] * i["a"];
                });
                break;

            case "S = π * r^2 * (n/360)":
                data.Add("S", "- Площадь");
                data.Add("r", "- радиус окружности");
                data.Add("π", "- константа ~ 3,14");
                data.Add("n", "- градусная мера");

                actions.Add("S", (i) =>
                {
                    return i["π"] * Math.Pow(i["r"], 2) * (i["n"] / 360);
                });
                break;

            case "S = 1/2 * r^2 * a":
                data.Add("S", "- Площадь");
                data.Add("r", "- радиус окружности");
                data.Add("a", "- радианная мера центрального угла");

                actions.Add("S", (i) =>
                {
                    return 0.5 * i["a"] * Math.Pow(i["r"], 2);
                });
                break;
                #endregion
        }

        //Создаём и добавляем элементы управления
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
                //Если результирующая переменная - выключаем 
                IsEnabled = actions.First().Key == pair.Key ? false : true,
            };
            entries.Add(entry);

            Grid grid = new Grid();
            grid.Children.Add(lbl);
            grid.Children.Add(entry);

            stack.Children.Add(grid);
        }

        //Очищаем перед использованием
        data.Clear();
    }

    private async void button_Clicked(object sender, EventArgs e)
    {
        //Выбираем пустые вводы
        List<Entry> newlist = entries.Where(x => x.Text == null || x.Text == string.Empty).ToList();

        //Действуем в зависимости от кол-ва пустых вводов
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
            //Очищаем вспомогательный список и добавляем введённые данные
            variables.Clear();
            foreach(Entry entry in entries.Except(newlist))
            {
                variables.Add(entry.Placeholder, Convert.ToDouble(entry.Text));
            }
            //Создаём функцию типа списка и выбираем нужное решение
            Func<Dictionary<string, double>,double> t = actions.Where(x => x.Key == newlist[0].Placeholder).First().Value;
            await DisplayAlert("Ваш ответ", $"{newlist[0].Placeholder} = {t(variables).ToString()}", "Выйти");
        }
    }
}