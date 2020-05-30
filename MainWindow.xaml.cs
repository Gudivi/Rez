using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Rez
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Начальные значения цветовой маркировки
        static public int Number_1 = 2;              // 1-е кольцо  
        static public int Number_2 = 2;              // 2-е кольцо
        static public int Number_3 = 2;              // 3-е кольцо
        static public int FactorColor = 2;           // 4-е кольцо
        static public string Dopusk = " ±2%";        // 5-е кольцо
        static public string ColorName = "Красный";  // Начальный цвет

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;

        }

        // Функция блокировка кнопок с буквами
        private void BtnChar_Enabled(bool Flag)
        {
            Btn_A.IsEnabled = Flag;
            Btn_B.IsEnabled = Flag;
            Btn_C.IsEnabled = Flag;
            Btn_D.IsEnabled = Flag;
            Btn_E.IsEnabled = Flag;
            Btn_F.IsEnabled = Flag;
            Btn_Z.IsEnabled = Flag;
            Btn_X.IsEnabled = Flag;
        }

        // Функция блокировка кнопок с цифрами
        private void BtnNumber_Enabled(bool Flag)
        {
            Btn_0.IsEnabled = Flag;
            Btn_1.IsEnabled = Flag;
            Btn_2.IsEnabled = Flag;
            Btn_3.IsEnabled = Flag;
            Btn_4.IsEnabled = Flag;
            Btn_5.IsEnabled = Flag;
            Btn_6.IsEnabled = Flag;
            Btn_7.IsEnabled = Flag;
            Btn_8.IsEnabled = Flag;
            Btn_9.IsEnabled = Flag;
        }

        // Функция перевода числовой маркировки
        private void Res_Number(string Kod)
        {
            // начальные значения переменных
            string Kod_znach = "0";
            string Kod_mnoj = "0";
            string Text = "";

            // если Kod содержит 2 числа
            if (Kod.Length == 2)
            {
                BtnChar_Enabled(true);              // разблокировать буквы
                Btn_R.IsEnabled = true;             // разблокировать букву R
            }

            // если Kod содержит 3 числа
            if (Kod.Length == 3)
            {
                BtnChar_Enabled(false);             // блокировать буквы
                Btn_R.IsEnabled = false;            // блокировать букву R
                BtnNumber_Enabled(true);            // разблокировать цифры

                Kod_znach = Kod.Substring(0, 2);    // извлекаем 2 первых символа - Значение резистора
                Kod_mnoj = Kod.Substring(2, 1);     // извлекаем 3-й символ - Множитель 
                Text = " ± 5%";
            }

            // если Kod содержит 4 числа
            if (Kod.Length == 4)
            {
                BtnChar_Enabled(false);             // блокировать буквы
                Btn_R.IsEnabled = false;            // блокировать букву R
                BtnNumber_Enabled(false);           // блокировать цифры

                Kod_znach = Kod.Substring(0, 3);    // извлекаем 3 первых символа - Значение резистора
                Kod_mnoj = Kod.Substring(3, 1);     // извлекаем 4-й символ - Множитель 
                Text = " ± 1%";
            }

            int Znach = int.Parse(Kod_znach);           // переводи Значение резистора из строки в число
            int Mnoj = int.Parse(Kod_mnoj);             // переводи Множитель резистора из строки в число

            float Rez = Znach * VozvStep(10, Mnoj);     // вычисление значения сопротивления резистора

            Label_Out.Text = $"{Transl(Rez.ToString())}{Text}";            // вывод значения в окно
        }

        // Функция перевода буквенной маркировки
        private void Res_Char(string Kod)
        {
            int[] Znach = {100, 102, 105, 107, 110, 113, 115, 118, 121, 124, 127, 130, 133, 137, 140, 143, 147, 150, 154, 158, 162, 165, 169, 174,
                           178, 182, 187, 191, 196, 200, 205, 210, 215, 221, 226, 232, 237, 243, 249, 255, 261, 267, 274, 280, 287, 294, 301, 309,
                           316, 324, 332, 340, 348, 357, 365, 374, 383, 392, 402, 412, 422, 432, 442, 453, 464, 475, 487, 499, 511, 523, 536, 549,
                           562, 576, 590, 604, 619, 634, 649, 665, 681, 698, 715, 732, 750, 768, 787, 806, 825, 845, 866, 887, 909, 931, 953, 976};

            string Text = " ± 1%";

            BtnChar_Enabled(false);                    // блокируем кнопки с Буквами
            BtnNumber_Enabled(false);                  // блокируем кнопки с Цифрами
            Btn_R.IsEnabled = false;                   // блокируем кнопку R

            string Kod_znach = Kod.Substring(0, 2);    // извлекаем 2 первых символа - Код значения резистора
            string Kod_mnoj = Kod.Substring(2, 1);     // извлекаем 3-й символ - Код множителя

            // преобразование кода множителя
            float Mnoj = 0;

            if (Kod_mnoj == "Z") Mnoj = 0.001F;
            if (Kod_mnoj == "R") Mnoj = 0.01F;
            if (Kod_mnoj == "X") Mnoj = 0.1F;
            if (Kod_mnoj == "A") Mnoj = 1;
            if (Kod_mnoj == "B") Mnoj = 10;
            if (Kod_mnoj == "C") Mnoj = 100;
            if (Kod_mnoj == "D") Mnoj = 1000;
            if (Kod_mnoj == "E") Mnoj = 10000;
            if (Kod_mnoj == "F") Mnoj = 100000;

            int IndexZnach = int.Parse(Kod_znach) - 1;
            float Rez = Znach[IndexZnach] * Mnoj;

            Label_Out.Text = $"{Transl(Rez.ToString())}{Text}";            // вывод значения в окно
        }

        // Функция перевода единиц измерения
        private string Transl(string Kod)
        {
            float Chislo = float.Parse(Kod);
            string Result = "";

            // если число меньше 1000
            if (Chislo < 1000)
            {
                Result = Kod + " Ом";
            }

            // число меньше миллиона и больше тысячи
            else if (Chislo >= 1000 && Chislo < 1000000)
            {
                Chislo /= 1000;
                Result = Chislo.ToString() + " кОм";
            }

            // если число больше миллиона
            else if (Chislo >= 1000000 && Chislo < 1000000000)
            {
                Chislo /= 1000000;
                Result = Chislo.ToString() + " МОм";
            }

            // если число больше миллиона
            else if (Chislo >= 1000000000)
            {
                Chislo /= 1000000000;
                Result = Chislo.ToString() + " ГОм";
            }

            return Result;
        }

        // Функция возведения в степень
        private float VozvStep(int i, int x)
        {
            float Chislo = 1f;

            // если степень положительная
            if (x >= 0)
            {
                for (int b = 0; b < x; b++)
                {
                    Chislo *= i;
                }
            }
            // если степень отрицательная
            else
            {
                for (int b = 0; b < x * (-1); b++)
                {
                    Chislo *= i;
                }
                Chislo = 1 / Chislo;
            }

            return Chislo;
        }

        // Начальный экран
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // ----- для буквенно-числовой маркировки
            Label_In.Text = "";              // Начальный текст в поле Ввода
            Label_Out.Text = "0 Ом";         // Начальный текст в поле Вывода
            Btn_Del.IsEnabled = false;       // Кнопка Удалить символ не активна
            BtnChar_Enabled(false);          // Кнопок с буквами - не активны
            BtnNumber_Enabled(true);         // Кнопки с цифрами - активна
            Btn_R.IsEnabled = true;          // Кнопка R - активна

            // ----- для цветовой маркировки
            Label_Out2.Text = "0 Ом";                   // Начальный текст в поле Вывода
            Line_3.Visibility = Visibility.Hidden;      // Скрываем третье кольцо
            FourLine.IsChecked = true;

            Gradient_Line(1, ColorName);    // Закрашиваем 1-е кольцо
            Gradient_Line(2, ColorName);    // Закрашиваем 2-е кольцо
            Gradient_Line(3, ColorName);    // Закрашиваем 3-е кольцо
            Gradient_Line(4, ColorName);    // Закрашиваем 4-е кольцо
            Gradient_Line(5, ColorName);    // Закрашиваем 5-е кольцо

            Res_Color();                    // Выводим значение
        }

        // Функция нажатия на кнопку
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            // Читаем надпись с кнопки
            object content = ((Button)sender).Content;
            string ch = content.ToString();

            // пока не введено 4 символа
            if (Label_In.Text.Length < 4)
            {
                // выводим результат
                Label_In.Text += ch;

                // если первый символ R
                if (Label_In.Text[0] == 'R')
                {
                    Btn_R.IsEnabled = false;
                    string Nomin = Label_In.Text.Substring(1, Label_In.Text.Length - 1);
                    Label_Out.Text = $"0,{Nomin} Ом";
                }

                // введено более 2 символов
                if (Label_In.Text.Length >= 2)
                {
                    // если второй символ R
                    if (Label_In.Text[1] == 'R')
                    {
                        Btn_R.IsEnabled = false;
                        string Nomin = Label_In.Text.Substring(2, Label_In.Text.Length - 2);
                        Label_Out.Text = $"{Label_In.Text[0]},{Nomin} Ом";
                    }

                    // проверка на наличие буквы в строке
                    bool result = int.TryParse(Label_In.Text, out int number);

                    // если 3-й символ БУКВА
                    if (result == false && Label_In.Text[0] != 'R' && Label_In.Text[1] != 'R') Res_Char(Label_In.Text);

                    // если 3-й символ ЧИСЛО
                    if (result == true) Res_Number(Label_In.Text);
                }
            }

            Btn_Del.IsEnabled = true;               // разблокируем кнопку Del
        }

        // Функция удалить один символ
        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {
            // определяем сколько символов введено - 1
            int Dlin = Label_In.Text.Length - 1;

            // выводим новый текст
            Label_In.Text = Label_In.Text.Remove(Dlin);

            int IndexR = Label_In.Text.IndexOf("R");

            if (IndexR == 1)
            {
                Label_Out.Text = Label_In.Text.Replace("R", ",") + " Ом";
            }
            else if (IndexR == 0)
            {
                Label_Out.Text = Label_In.Text.Replace("R", "0,") + " Ом";
            }
            else
            {
                if (Dlin == 3) Res_Number(Label_In.Text);      // выводим новый результат
                else if (Dlin == 2)
                {
                    BtnChar_Enabled(true);                     // разблокируем кнопки с буквами
                    Btn_R.IsEnabled = true;                   // разблокируем кнопку R
                    Label_Out.Text = "0 Ом";
                }
                else if (Dlin == 1)
                {
                    BtnChar_Enabled(false);                    // блокируем кнопки с буквами
                    Btn_R.IsEnabled = true;                   // разблокируем кнопку R
                    Label_Out.Text = "0 Ом";
                }
                else MainWindow_Loaded(sender, e);
            }

            BtnNumber_Enabled(true);           // разблокировать кнопки с цифрами
        }

        // --------------------------- Цветовая маркировка

        // Функция создания градиентной заливки
        public void Gradient_Line(int Namber, string ColorName)
        {
            Color Start_Color = Colors.Red; 
            Color Stop_Color = Colors.Red;
                  
            // Выбор цвета
            switch (ColorName)
            {
                case "Красный":
                    Start_Color = Colors.Red;
                    Stop_Color = Colors.DarkRed;
                    break;
                case "Зеленый":
                    Start_Color = Colors.SeaGreen;
                    Stop_Color = Colors.DarkGreen;
                    break;
                case "Коричневый":
                    Start_Color = Color.FromRgb(194, 105, 16);
                    Stop_Color = Color.FromRgb(139, 69, 19);
                    break;
                case "Оранжевый":
                    Start_Color = Colors.Orange;
                    Stop_Color = Color.FromRgb(153, 99, 0);
                    break;
                case "Желтый":
                    Start_Color = Colors.Yellow;
                    Stop_Color = Color.FromRgb(194, 175, 10);
                    break;
                case "Синий":
                    Start_Color = Colors.Blue;
                    Stop_Color = Colors.DarkBlue;
                    break;
                case "Фиолетовый":
                    Start_Color = Color.FromRgb(139, 0, 255);
                    Stop_Color = Color.FromRgb(84, 0, 153);
                    break;
                case "Серый":
                    Start_Color = Colors.DarkGray;
                    Stop_Color = Colors.Gray;
                    break;
                case "Белый":
                    Start_Color = Colors.White;
                    Stop_Color = Color.FromRgb(220, 220, 220);
                    break;
                case "Черный":
                    Start_Color = Color.FromRgb(77, 77, 77);
                    Stop_Color = Colors.Black;
                    break;
                case "Серебряный":
                    Start_Color = Color.FromRgb(192, 192, 192);
                    Stop_Color = Color.FromRgb(115, 115, 115);
                    break;
                case "Золотой":
                    Start_Color = Color.FromRgb(255, 215, 0);
                    Stop_Color = Color.FromRgb(153, 130, 0);
                    break;
            }

            LinearGradientBrush myGradient = new LinearGradientBrush();
            myGradient.StartPoint = new Point(0.5, 0);
            myGradient.EndPoint = new Point(1, 1);
            myGradient.GradientStops.Add(new GradientStop(Start_Color, 0.3));
            myGradient.GradientStops.Add(new GradientStop(Stop_Color, 0.8));

            // Выбор линии
            switch (Namber)
            {
                case 1:
                    Line_1.Fill = myGradient;
                    break;
                case 2:
                    Line_2.Fill = myGradient;
                    break;
                case 3:
                    Line_3.Fill = myGradient;
                    break;
                case 4:
                    Line_4.Fill = myGradient;
                    break;
                case 5:
                    Line_5.Fill = myGradient;
                    break;
            }
        }

        // Функция первода цветовой маркировки
        private void Res_Color()
        {
            int Nominal;        // Номинал резистора
            float Rezultat;     // Результат

            if (FourLine.IsChecked == true)
            {
                Nominal = (Number_1 * 10) + Number_2;
            }
            else
            {
                Nominal = (Number_1 * 100) + (Number_2 * 10) + Number_3;
            }

            Rezultat = Nominal * VozvStep(10, FactorColor);           

            Label_Out2.Text = Transl(Rezultat.ToString()) + Dopusk;
        }


        // Функция нажатия на первую полоску
        private void Line_1_Click(object sender, RoutedEventArgs e)
        {
            // Вызов окна выбора цвета
            ColorF ColorF = new ColorF(458, "Первая цифра");     
            ColorF.Owner = this;
            ColorF.ShowDialog();

            Gradient_Line(1, ColorName);    // Изменяем цвет линии
            Res_Color();                    // Запускае пересчет значения
        }

        // Функция нажатия на вторую полоску
        private void Line_2_Click(object sender, RoutedEventArgs e)
        {
            // Вызов окна выбора цвета
            ColorF ColorF = new ColorF(504, "Вторая цифра");
            ColorF.Owner = this;
            ColorF.ShowDialog();

            Gradient_Line(2, ColorName);    // Изменяем цвет линии
            Res_Color();                    // Запускае пересчет значения
        }

        // Функция нажатия на третью полоску
        private void Line_3_Click(object sender, RoutedEventArgs e)
        {
            ColorF ColorF = new ColorF(504, "Третья цифра");
            ColorF.Owner = this;
            ColorF.ShowDialog();

            Gradient_Line(3, ColorName);    // Изменяем цвет линии
            Res_Color();                    // Запускае пересчет значения
        }

        // Функция нажатия на четвертую полоску
        private void Line_4_Click(object sender, RoutedEventArgs e)
        {
            ColorF ColorF = new ColorF(595, "Множитель");
            ColorF.Owner = this;
            ColorF.ShowDialog();

            Gradient_Line(4, ColorName);    // Изменяем цвет линии
            Res_Color();                    // Запускае пересчет значения
        }

        // Функция нажатия на четвертую полоску
        private void Line_5_Click(object sender, RoutedEventArgs e)
        {
            ColorF ColorF = new ColorF(413, "Допуск");
            ColorF.Owner = this;
            ColorF.ShowDialog();

            Gradient_Line(5, ColorName);    // Изменяем цвет линии
            Res_Color();                    // Запускае пересчет значения
        }

        // Функция 5-ти полосный резистор
        private void FiveLine_Checked(object sender, RoutedEventArgs e)
        {
            Line_3.Visibility = Visibility.Visible;
            Res_Color();
        }

        // Функция 4-х полосный резистор
        private void FourLine_Checked(object sender, RoutedEventArgs e)
        {
            Line_3.Visibility = Visibility.Hidden;
            Res_Color();
        }
    }
}
