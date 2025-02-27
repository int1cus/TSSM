using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace TSSM_PW_3_422_Andzhigaev_Filippov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateInputFields();
        }

        private void FigureChanged(object sender, RoutedEventArgs e)
        {
            UpdateInputFields();
        }

        private void UpdateInputFields()
        {
            txtParam1.Visibility = Visibility.Collapsed;
            txtParam2.Visibility = Visibility.Collapsed;
            lblParam1.Visibility = Visibility.Collapsed;
            lblParam2.Visibility = Visibility.Collapsed;

            txtParam1.Text = "";
            txtParam2.Text = "";

            if (rbRectangle.IsChecked == true)
            {
                lblParam1.Content = "Длина";
                lblParam2.Content = "Ширина";
                lblParam1.Visibility = Visibility.Visible;
                lblParam2.Visibility = Visibility.Visible;
                txtParam1.Visibility = Visibility.Visible;
                txtParam2.Visibility = Visibility.Visible;
            }
            else if (rbCircle.IsChecked == true)
            {
                lblParam1.Content = "Радиус";
                lblParam1.Visibility = Visibility.Visible;
                txtParam1.Visibility = Visibility.Visible;
            }
            else if (rbTriangle.IsChecked == true)
            {
                lblParam1.Content = "Основание";
                lblParam2.Content = "Высота";
                lblParam1.Visibility = Visibility.Visible;
                lblParam2.Visibility = Visibility.Visible;
                txtParam1.Visibility = Visibility.Visible;
                txtParam2.Visibility = Visibility.Visible;
            }
        }

        private void CalculateArea(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "";

            try
            {
                double area = 0;

                if (rbRectangle.IsChecked == true)
                {
                    double length = ValidateInput(txtParam1.Text);
                    double width = ValidateInput(txtParam2.Text);
                    area = length * width;
                }
                else if (rbCircle.IsChecked == true)
                {
                    double radius = ValidateInput(txtParam1.Text);
                    area = Math.PI * radius * radius;
                }
                else if (rbTriangle.IsChecked == true)
                {
                    double triangleBase = ValidateInput(txtParam1.Text);
                    double triangleHeight = ValidateInput(txtParam2.Text);
                    area = 0.5 * triangleBase * triangleHeight;
                }
                else
                {
                    MessageBox.Show("Выберите фигуру!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                lblResult.Content = area.ToString("F2", CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка: введите корректные положительные числа!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double ValidateInput(string input)
        {
            if (!double.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out double result))
            {
                throw new FormatException();
            }
            return result;
        }
    }
}
