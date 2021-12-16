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

namespace pr9_chel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pochta[] pochta = new Pochta[7];
        string[,] matrix = new string[7, 6];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Fill(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(outNumber.Text, out int number) && number <= 7 && number > 0 && outCity.Text != string.Empty &&
                outWhom.Text != string.Empty && outValue.Text != string.Empty && outStreet.Text != string.Empty && int.TryParse(outHouse.Text, out int house) &&
                int.TryParse(outFlat.Text, out int flat))
            {
           
                pochta[number - 1] = new Pochta(outCity.Text, outWhom.Text, outValue.Text, outStreet.Text, house, flat);
                matrix[number - 1, 0] = pochta[number - 1].Whom;
                matrix[number - 1, 1] = pochta[number - 1].City;
                matrix[number - 1, 2] = pochta[number - 1].Value;
                matrix[number - 1, 3] = pochta[number - 1].Street;
                matrix[number - 1, 4] = pochta[number - 1].House.ToString();
                matrix[number - 1, 5] = pochta[number - 1].Flat.ToString();
                dataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
                dataGrid.Columns[0].Header = "Кому";
                dataGrid.Columns[1].Header = "Город";
                dataGrid.Columns[2].Header = "Ценность";
                dataGrid.Columns[3].Header = "Улица";
                dataGrid.Columns[4].Header = "№ дома";
                dataGrid.Columns[5].Header = "№ квартиры";     
            }
            outPackage.Clear();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(outNumber.Text, out int number) && number > 0 && number <= 7)
            {
                pochta[number - 1] = new Pochta();
                for (int i = 0; i <= 5; i++)
                {
                    matrix[number - 1, i] = string.Empty;
                }
                dataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
                dataGrid.Columns[0].Header = "Кому";
                dataGrid.Columns[1].Header = "Город";
                dataGrid.Columns[2].Header = "Ценность";
                dataGrid.Columns[3].Header = "Улица";
                dataGrid.Columns[4].Header = "№ дома";
                dataGrid.Columns[5].Header = "№ квартиры";
            }
            outPackage.Clear();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            int package = 0;
            if (searchCity.Text != string.Empty)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (matrix[i, 1] == null)
                    {
                        continue;
                    }
                    if (matrix[i, 1] == searchCity.Text)
                    {
                        package++;
                    }
                }
                outPackage.Text = package.ToString();
            }
        }

        private void SearchCities(object sender, TextChangedEventArgs e)
        {
            outPackage.Clear();
        }

        private void OutNumbers(object sender, TextChangedEventArgs e)
        {
            outWhom.Clear();
            outCity.Clear();
            outValue.Clear();
            outStreet.Clear();
            outHouse.Clear();
            outFlat.Clear();
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Челяев Никита\nПрактическая работа №9\nОписать, используя структуру, почтовую сортировку (город, улица, дом, квартира, кому, ценность).Вывести результат на экран.Вывести информацию, сколько посылок отправлено в заданный город.", "Информация о программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
