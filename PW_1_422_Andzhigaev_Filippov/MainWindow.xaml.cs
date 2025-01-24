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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PW_1_422_Andzhigaev_Filippov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_calculate_Click(object sender, RoutedEventArgs e)
        {
            double answer = 0;
            double x = 0;
            double y = 0;
            double funcX = 0;

            try
            {
                x = Convert.ToDouble(textBox_x.Text);
                y = Convert.ToDouble(textBox_y.Text);
            }
            catch
            {
                MessageBox.Show("Неправильно введён x или y");
                return;
            }


            if (RB1.IsChecked ?? false)
            {
                funcX = (Math.Pow(Math.E, x) - Math.Pow(Math.E, -x)) / 2;
            }
            else if (RB2.IsChecked ?? false)
            {
                funcX = Math.Pow(x, 2);
            }
            else if (RB3.IsChecked ?? false)
            {
                funcX = Math.Pow(Math.E, x);
            }
            else
            {
                MessageBox.Show("Не выбрана функция от x");
                return;
            }


            if (x * y > 0)
            {
                if (funcX * y < 0)
                {
                    MessageBoxResult error = MessageBox.Show(
                        "Невозможно извлечь корень из отрицательного числа",
                        "Арифметическая ошмбка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Question);
                }
                else
                {
                    answer = Math.Pow(funcX + y, 2) - Math.Sqrt(funcX * y);
                }
            }
            else if (x * y < 0)
            {
                answer = Math.Pow(funcX + y, 2) - Math.Sqrt(Math.Abs(funcX * y));
            }
            else if (x * y == 0)
            {
                answer = Math.Pow(funcX + y, 2) + 1;
            }
            else
            {
                MessageBox.Show("Ошибка нахождения диапазона");
                return;
            }


            TextBox_answer.Text = answer.ToString();

        }

        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            textBox_y.Text = null; ;
            textBox_x.Text = null;
            TextBox_answer.Text = null;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Подтвердите выход из приложения",
                "Выход",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }

            base.OnClosing(e);
        }
    }
}
