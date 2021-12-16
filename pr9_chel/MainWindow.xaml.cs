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

        private void FillTable(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(outNumber.Text, out int position) && position <= 7 && position > 0 && outCity.Text != string.Empty &&
                outWhom.Text != string.Empty && outValue.Text != string.Empty && outStreet.Text != string.Empty && int.TryParse(outHouse.Text, out int house) &&
                int.TryParse(outRoom.Text, out int room))
            {
           
                pochta[position - 1] = new Pochta(outCity.Text, outWhom.Text, outValue.Text, outStreet.Text, house, room);
                matrix[position - 1, 0] = pochta[position - 1].Whom;
                matrix[position - 1, 1] = pochta[position - 1].City;
                matrix[position - 1, 2] = pochta[position - 1].Value;
                matrix[position - 1, 3] = pochta[position - 1].Street;
                matrix[position - 1, 4] = pochta[position - 1].House.ToString();
                matrix[position - 1, 5] = pochta[position - 1].Room.ToString();
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

        private void DeleteLine(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(outNumber.Text, out int position) && position > 0 && position <= 7)
            {
                pochta[position - 1] = new Pochta();
                for (int i = 0; i <= 5; i++)
                {
                    matrix[position - 1, i] = string.Empty;
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
                    if (matrix[i, 2] == null)
                    {
                        continue;
                    }
                    if (matrix[i, 2] == searchCity.Text)
                    {
                        package++;
                    }
                }
                outPackage.Text = package.ToString();
            }
        }

        private void searchStreet_TextChanged(object sender, TextChangedEventArgs e)
        {
            outPackage.Clear();
        }

        private void outPosition_TextChanged(object sender, TextChangedEventArgs e)
        {
            outWhom.Clear();
            outCity.Clear();
            outValue.Clear();
            outStreet.Clear();
            outHouse.Clear();
            outRoom.Clear();
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
