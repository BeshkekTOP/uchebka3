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
using System.Windows.Shapes;
using Uchebka1.CarRentalDataSetTableAdapters;

namespace Uchebka1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        RentalsTableAdapter rental = new RentalsTableAdapter();
        public Window2()
        {
            InitializeComponent();
            RentalsDatagrid.ItemsSource = rental.GetData();
            RentalComboBox.ItemsSource = rental.GetData();
            RentalComboBox.DisplayMemberPath = "TotalCost";
        }

        private void RentalComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object num = (RentalComboBox.SelectedItem as DataRowView).Row[5];
            MessageBox.Show(num.ToString());
        }

        private void NextTable3_Click(object sender, RoutedEventArgs e)
        {
            Window3 window = new Window3();
            window.Show();
            Close();
        }

        private void LastTable3_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
            Close();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            rental.InsertQuery(RentalDateTbx.Text);
            RentalsDatagrid.ItemsSource = rental.GetData();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (RentalsDatagrid.SelectedItem as DataRowView).Row[2];
            rental.UpdateQuery(RentalDateTbx.Text, Convert.ToInt32(id));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

            object id = (RentalsDatagrid.SelectedItem as DataRowView).Row[0];
            rental.DeleteQuery(Convert.ToInt32(id));
            RentalsDatagrid.ItemsSource = rental.GetData();
        }

        private void RentalsDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    
}
