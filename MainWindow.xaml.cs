using System;
using System.Collections.Generic;
using System.Data;
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
using Uchebka1.CarRentalDataSetTableAdapters;

namespace Uchebka1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CarsTableAdapter cars = new CarsTableAdapter();
       
        public MainWindow()
        {
            InitializeComponent();
            CarsDataGrid.ItemsSource = cars.GetData();
            CarsComboBox.ItemsSource = cars.GetData();
            CarsComboBox.DisplayMemberPath = "Brand";
        }

        private void NextTable1_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
            Close();
        }

        private void LastTable1_Click(object sender, RoutedEventArgs e)
        {
            Window3 window = new Window3();
            window.Show();
            Close();
        }

        private void CarsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }
        private void CarsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object num = (CarsComboBox.SelectedItem as DataRowView).Row[1];
            MessageBox.Show(num.ToString());
        }
        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            cars.InsertQuery(BrandTbx.Text);
            CarsDataGrid.ItemsSource = cars.GetData();

        }
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (CarsDataGrid.SelectedItem as DataRowView).Row[0];
            cars.UpdateQuery(BrandTbx.Text, Convert.ToInt32(id));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (CarsDataGrid.SelectedItem as DataRowView).Row[0];
            cars.DeleteQuery(Convert.ToInt32(id));
            CarsDataGrid.ItemsSource = cars.GetData();

        }

        private void InnerBtn_Click(object sender, RoutedEventArgs e)
        {
            Window4 window = new Window4();
            window.Show();
            Close();
        }

        private void Inner2Btn_Click(object sender, RoutedEventArgs e)
        {
            Window5 window = new Window5();
            window.Show();
            Close();
        }
    }
}
