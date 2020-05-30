using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Rez
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ColorF : Window
    {
        public ColorF(int height, string title)
        {
            InitializeComponent();
            this.Width = 246;
            this.Height = height;
            this.Title = title;
            this.Loaded += ColorF_Loaded;
        }

        // Начальный экран
        private void ColorF_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Title == "Первая цифра") OneLine("Первая цифра");
            if (this.Title == "Вторая цифра") TwoLine("Вторая цифра");
            if (this.Title == "Третья цифра") TwoLine("Третья цифра");
            if (this.Title == "Множитель") Factor("Множитель");
            if (this.Title == "Допуск") Dopusk("Допуск");
        }

        // Функция создания градиентной заливки
        private void Gradient_Color(int Namber, string ColorName)
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
            myGradient.GradientStops.Add(new GradientStop(Start_Color, 0));
            myGradient.GradientStops.Add(new GradientStop(Stop_Color, 0.6));

            // Выбор линии
            switch (Namber)
            {
                case 0:
                    Color_0.Fill = myGradient;
                    break;
                case 1:
                    Color_1.Fill = myGradient;
                    break;
                case 2:
                    Color_2.Fill = myGradient;
                    break;
                case 3:
                    Color_3.Fill = myGradient;
                    break;
                case 4:
                    Color_4.Fill = myGradient;
                    break;
                case 5:
                    Color_5.Fill = myGradient;
                    break;
                case 6:
                    Color_6.Fill = myGradient;
                    break;
                case 7:
                    Color_7.Fill = myGradient;
                    break;
                case 8:
                    Color_8.Fill = myGradient;
                    break;
                case 9:
                    Color_9.Fill = myGradient;
                    break;
                case 10:
                    Color_10.Fill = myGradient;
                    break;
                case 11:
                    Color_11.Fill = myGradient;
                    break;
            }
        }


        // Окно - Первая цифра
        private void OneLine(string Title)
        {
            PanelColor_9.Visibility = Visibility.Collapsed;
            PanelColor_10.Visibility = Visibility.Collapsed;
            PanelColor_11.Visibility = Visibility.Collapsed;

            // Коричневый
            ColorName_0.Text = "Коричневый";
            LabelColor_0.Text = Title + " - 1";
            Gradient_Color(0, "Коричневый");

            // Красный
            ColorName_1.Text = "Красный";
            LabelColor_1.Text = Title + " - 2";
            Gradient_Color(1, "Красный");

            // Оранжевый
            ColorName_2.Text = "Оранжевый";
            LabelColor_2.Text = Title + " - 3";
            Gradient_Color(2, "Оранжевый");

            // Желтый
            ColorName_3.Text = "Желтый";
            LabelColor_3.Text = Title + " - 4";
            Gradient_Color(3, "Желтый");

            // Зеленый
            ColorName_4.Text = "Зеленый";
            LabelColor_4.Text = Title + " - 5";
            Gradient_Color(4, "Зеленый");

            // Синий
            ColorName_5.Text = "Синий";
            LabelColor_5.Text = Title + " - 6";
            Gradient_Color(5, "Синий");

            // Фиолетовый
            ColorName_6.Text = "Фиолетовый";
            LabelColor_6.Text = Title + " - 7";
            Gradient_Color(6, "Фиолетовый");

            // Серый
            ColorName_7.Text = "Серый";
            LabelColor_7.Text = Title + " - 8";
            Gradient_Color(7, "Серый");

            // Белый
            ColorName_8.Text = "Белый";
            LabelColor_8.Text = Title + " - 9";
            Gradient_Color(8, "Белый");
        }

        // Окно - Вторая цифра или Третья цифра (при пятиполосном)
        private void TwoLine(string Title)
        {
            PanelColor_9.Visibility = Visibility.Visible;
            PanelColor_10.Visibility = Visibility.Collapsed;
            PanelColor_11.Visibility = Visibility.Collapsed;

            // Черный
            ColorName_0.Text = "Черный";
            LabelColor_0.Text = Title + " - 0";
            Gradient_Color(0, "Черный");

            // Коричневый
            ColorName_1.Text = "Коричневый";
            LabelColor_1.Text = Title + " - 1";
            Gradient_Color(1, "Коричневый");

            // Красный
            ColorName_2.Text = "Красный";
            LabelColor_2.Text = Title + " - 2";
            Gradient_Color(2, "Красный");

            // Оранжевый
            ColorName_3.Text = "Оранжевый";
            LabelColor_3.Text = Title + " - 3";
            Gradient_Color(3, "Оранжевый");

            // Желтый
            ColorName_4.Text = "Желтый";
            LabelColor_4.Text = Title + " - 4";
            Gradient_Color(4, "Желтый");

            // Зеленый
            ColorName_5.Text = "Зеленый";
            LabelColor_5.Text = Title + " - 5";
            Gradient_Color(5, "Зеленый");

            // Синий
            ColorName_6.Text = "Синий";
            LabelColor_6.Text = Title + " - 6";
            Gradient_Color(6, "Синий");

            // Фиолетовый
            ColorName_7.Text = "Фиолетовый";
            LabelColor_7.Text = Title + " - 7";
            Gradient_Color(7, "Фиолетовый");

            // Серый
            ColorName_8.Text = "Серый";
            LabelColor_8.Text = Title + " - 8";
            Gradient_Color(8, "Серый");

            // Белый
            ColorName_9.Text = "Белый";
            LabelColor_9.Text = Title + " - 9";
            Gradient_Color(9, "Белый");
        }

        // Окно - Множитель
        private void Factor(string Title)
        {
            PanelColor_9.Visibility = Visibility.Visible;
            PanelColor_10.Visibility = Visibility.Visible;
            PanelColor_11.Visibility = Visibility.Visible;

            // Серебряный
            ColorName_0.Text = "Серебряный";
            LabelColor_0.Text = Title + " - 0.01";
            Gradient_Color(0, "Серебряный");

            // Золотой
            ColorName_1.Text = "Золотой";
            LabelColor_1.Text = Title + " - 0.1";
            Gradient_Color(1, "Золотой");

            // Черный
            ColorName_2.Text = "Черный";
            LabelColor_2.Text = Title + " - 1";
            Gradient_Color(2, "Черный");

            // Коричневый
            ColorName_3.Text = "Коричневый";
            LabelColor_3.Text = Title + " - 10";
            Gradient_Color(3, "Коричневый");

            // Красный
            ColorName_4.Text = "Красный";
            LabelColor_4.Text = Title + " - 100";
            Gradient_Color(4, "Красный");

            // Оранжевый
            ColorName_5.Text = "Оранжевый";
            LabelColor_5.Text = Title + " - 1k";
            Gradient_Color(5, "Оранжевый");

            // Желтый
            ColorName_6.Text = "Желтый";
            LabelColor_6.Text = Title + " - 10k";
            Gradient_Color(6, "Желтый");

            // Зеленый
            ColorName_7.Text = "Зеленый";
            LabelColor_7.Text = Title + " - 100k";
            Gradient_Color(7, "Зеленый");

            // Синий
            ColorName_8.Text = "Синий";
            LabelColor_8.Text = Title + " - 1M";
            Gradient_Color(8, "Синий");

            // Фиолетовый
            ColorName_9.Text = "Фиолетовый";
            LabelColor_9.Text = Title + " - 10M";
            Gradient_Color(9, "Фиолетовый");

            // Серый
            ColorName_10.Text = "Серый";
            LabelColor_10.Text = Title + " - 100M";
            Gradient_Color(10, "Серый");

            // Белый
            ColorName_11.Text = "Белый";
            LabelColor_11.Text = Title + " - 1G";
            Gradient_Color(11, "Белый");
        }

        // Окно - Допуск
        private void Dopusk(string Title)
        {
            PanelColor_8.Visibility = Visibility.Collapsed;
            PanelColor_9.Visibility = Visibility.Collapsed;
            PanelColor_10.Visibility = Visibility.Collapsed;
            PanelColor_11.Visibility = Visibility.Collapsed;

            // Серый
            ColorName_0.Text = "Серый";
            LabelColor_0.Text = Title + " - ±0.05%";
            Gradient_Color(0, "Серый");

            // Фиолетовый
            ColorName_1.Text = "Фиолетовый";
            LabelColor_1.Text = Title + " - ±0.1%";
            Gradient_Color(1, "Фиолетовый");

            // Синий
            ColorName_2.Text = "Синий";
            LabelColor_2.Text = Title + " - ±0.25%";
            Gradient_Color(2, "Синий");

            // Зеленый
            ColorName_3.Text = "Зеленый";
            LabelColor_3.Text = Title + " - ±0.5%";
            Gradient_Color(3, "Зеленый");

            // Коричневый
            ColorName_4.Text = "Коричневый";
            LabelColor_4.Text = Title + " - ±1%";
            Gradient_Color(4, "Коричневый");

            // Красный
            ColorName_5.Text = "Красный";
            LabelColor_5.Text = Title + " - ±2%";
            Gradient_Color(5, "Красный");

            // Золотой
            ColorName_6.Text = "Золотой";
            LabelColor_6.Text = Title + " - ± 5%";
            Gradient_Color(6, "Золотой");

            // Серебряный
            ColorName_7.Text = "Серебряный";
            LabelColor_7.Text = Title + " - ± 10%";
            Gradient_Color(7, "Серебряный");
        }


        // Функция нажатия 0-й панели
        private void Color_0_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FormColor.Title == "Первая цифра") MainWindow.Number_1 = 1;
            else if (FormColor.Title == "Вторая цифра") MainWindow.Number_2 = 0;
            else if (FormColor.Title == "Третья цифра") MainWindow.Number_3 = 0;
            else if (FormColor.Title == "Множитель") MainWindow.FactorColor = -2;
            else if (FormColor.Title == "Допуск") MainWindow.Dopusk = " ±0.05%";

            MainWindow.ColorName = ColorName_0.Text;
            Close();
        }

        // Функция нажатия 1-й панели
        private void Color_1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FormColor.Title == "Первая цифра") MainWindow.Number_1 = 2;
            else if (FormColor.Title == "Вторая цифра") MainWindow.Number_2 = 1;
            else if (FormColor.Title == "Третья цифра") MainWindow.Number_3 = 1;
            else if (FormColor.Title == "Множитель") MainWindow.FactorColor = -1;
            else if (FormColor.Title == "Допуск") MainWindow.Dopusk = " ±0.1%";

            MainWindow.ColorName = ColorName_1.Text;
            Close();
        }

        // Функция нажатия 2-й панели
        private void Color_2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FormColor.Title == "Первая цифра") MainWindow.Number_1 = 3;
            else if (FormColor.Title == "Вторая цифра") MainWindow.Number_2 = 2;
            else if (FormColor.Title == "Третья цифра") MainWindow.Number_3 = 2;
            else if (FormColor.Title == "Множитель") MainWindow.FactorColor = 0;
            else if (FormColor.Title == "Допуск") MainWindow.Dopusk = " ±0.25%";

            MainWindow.ColorName = ColorName_2.Text;
            Close();
        }

        // Функция нажатия 3-й панели
        private void Color_3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FormColor.Title == "Первая цифра") MainWindow.Number_1 = 4;
            else if (FormColor.Title == "Вторая цифра") MainWindow.Number_2 = 3;
            else if (FormColor.Title == "Третья цифра") MainWindow.Number_3 = 3;
            else if (FormColor.Title == "Множитель") MainWindow.FactorColor = 1;
            else if (FormColor.Title == "Допуск") MainWindow.Dopusk = " ±0.5%";

            MainWindow.ColorName = ColorName_3.Text;
            Close();
        }

        // Функция нажатия 4-й панели
        private void Color_4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FormColor.Title == "Первая цифра") MainWindow.Number_1 = 5;
            else if (FormColor.Title == "Вторая цифра") MainWindow.Number_2 = 4;
            else if (FormColor.Title == "Третья цифра") MainWindow.Number_3 = 4;
            else if (FormColor.Title == "Множитель") MainWindow.FactorColor = 2;
            else if (FormColor.Title == "Допуск") MainWindow.Dopusk = " ±1%";

            MainWindow.ColorName = ColorName_4.Text;
            Close();
        }

        // Функция нажатия 5-й панели
        private void Color_5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FormColor.Title == "Первая цифра") MainWindow.Number_1 = 6;
            else if (FormColor.Title == "Вторая цифра") MainWindow.Number_2 = 5;
            else if (FormColor.Title == "Третья цифра") MainWindow.Number_3 = 5;
            else if (FormColor.Title == "Множитель") MainWindow.FactorColor = 3;
            else if (FormColor.Title == "Допуск") MainWindow.Dopusk = " ±2%";

            MainWindow.ColorName = ColorName_5.Text;
            Close();
        }

        // Функция нажатия 6-й панели
        private void Color_6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FormColor.Title == "Первая цифра") MainWindow.Number_1 = 7;
            else if (FormColor.Title == "Вторая цифра") MainWindow.Number_2 = 6;
            else if (FormColor.Title == "Третья цифра") MainWindow.Number_3 = 6;
            else if (FormColor.Title == "Множитель") MainWindow.FactorColor = 4;
            else if (FormColor.Title == "Допуск") MainWindow.Dopusk = " ±5%";

            MainWindow.ColorName = ColorName_6.Text;
            Close();
        }

        // Функция нажатия 7-й панели
        private void Color_7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FormColor.Title == "Первая цифра") MainWindow.Number_1 = 8;
            else if (FormColor.Title == "Вторая цифра") MainWindow.Number_2 = 7;
            else if (FormColor.Title == "Третья цифра") MainWindow.Number_3 = 7;
            else if (FormColor.Title == "Множитель") MainWindow.FactorColor = 5;
            else if (FormColor.Title == "Допуск") MainWindow.Dopusk = " ±10%";

            MainWindow.ColorName = ColorName_7.Text;
            Close();
        }

        // Функция нажатия 8-й панели
        private void Color_8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FormColor.Title == "Первая цифра") MainWindow.Number_1 = 9;
            else if (FormColor.Title == "Вторая цифра") MainWindow.Number_2 = 8;
            else if (FormColor.Title == "Третья цифра") MainWindow.Number_3 = 8;
            else if (FormColor.Title == "Множитель") MainWindow.FactorColor = 6;

            MainWindow.ColorName = ColorName_8.Text;
            Close();
        }

        // Функция нажатия 9-й панели
        private void Color_9_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FormColor.Title == "Вторая цифра") MainWindow.Number_2 = 9;
            else if (FormColor.Title == "Третья цифра") MainWindow.Number_3 = 9;
            else if (FormColor.Title == "Множитель") MainWindow.FactorColor = 7;

            MainWindow.ColorName = ColorName_9.Text;
            Close();
        }

        // Функция нажатия 10-й панели
        private void Color_10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FormColor.Title == "Множитель") MainWindow.FactorColor = 8;

            MainWindow.ColorName = ColorName_10.Text;
            Close();
        }

        // Функция нажатия 11-й панели
        private void Color_11_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FormColor.Title == "Множитель") MainWindow.FactorColor = 9;

            MainWindow.ColorName = ColorName_11.Text;
            Close();
        }
    }
}
