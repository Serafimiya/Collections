using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Collections
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> numbers;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInfoProgrammist_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Студентка группы ИСП-31 Лосева Анастасия", "О разработчике:");
        }

        private void btnInfoProga_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дан массив в диапазоне [-100;100].\r\nНайти количество положительных и отрицательных. ", "О программе:");
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            tbRange.Clear();
            tbGen.Clear();
            tbPositiv.Clear();
            tbNegative.Clear();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string inputArray = tbRange.Text;
                numbers = inputArray.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(num => int.Parse(num.Trim()))
                    .ToList();
                if (numbers.All(num => num >= -100 && num <= 100))
                {
                    int positive = numbers.Count(n => n > 0);
                    int cnegative = numbers.Count(n => n < 0);

                    // Обновляем результаты
                    tbPositiv.Text = positive.ToString();
                    tbNegative.Text = cnegative.ToString();

                    // Обновляем TextBox с массивом
                    tbGen.Text = string.Join(", ", numbers);
                }
                else
                {
                    MessageBox.Show("Значения должны быть в интервале от -100 до 100", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числовые значения.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (string.IsNullOrEmpty(tbRange.Text))
            {
                Random random = new Random();
                numbers = new List<int>();// Создаем пустой динамический массив

                for (int i = 0; i < 100; i++) // например, 100 случайных чисел
                {
                    numbers.Add(random.Next(-100, 101)); // Числа от -100 до 100 включительно
                }

                // Подсчитываем количество положительных и отрицательных чисел
                int positive = numbers.Count(n => n > 0);
                int cnegative = numbers.Count(n => n < 0);

                // Обновляем результаты
                tbPositiv.Text = positive.ToString();
                tbNegative.Text = cnegative.ToString();

                // Обновляем TextBox с массивом
                tbGen.Text = string.Join(", ", numbers);
            }
        }
    }
}