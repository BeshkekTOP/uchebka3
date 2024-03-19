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
using Uchebka1.CarRentalDataSetTableAdapters;

namespace Uchebka1
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        CarsTableAdapter adapter = new CarsTableAdapter();
        public Window4()
        {
            InitializeComponent();
            InnerDataGrid.ItemsSource = adapter.GetFullInfo();
           
        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InnerDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            InnerDataGrid.Columns[5].Visibility = Visibility.Collapsed;
        }

        private void InnerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
