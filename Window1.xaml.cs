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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        CustomersTableAdapter customer = new CustomersTableAdapter();
        public Window1()
        {
            InitializeComponent();
            CustomersDataGrid.ItemsSource = customer.GetData();
            CustomerComboBox.ItemsSource = customer.GetData();
            CustomerComboBox.DisplayMemberPath = "FirstName";
        }

        private void NextTable2_Click(object sender, RoutedEventArgs e)
        {
            Window2 window = new Window2();
            window.Show();
            Close();
        }

        private void LastTable2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void CustomersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object num = (CustomerComboBox.SelectedItem as DataRowView).Row[1];
            MessageBox.Show(num.ToString());
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            customer.InsertQuery(FirstNameTbx.Text);
            CustomersDataGrid.ItemsSource = customer.GetData();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (CustomersDataGrid.SelectedItem as DataRowView).Row[0];
            customer.UpdateQuery(FirstNameTbx.Text, Convert.ToInt32(id));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            object id = (CustomersDataGrid.SelectedItem as DataRowView).Row[0];
            customer.DeleteQuery(Convert.ToInt32(id));
            CustomersDataGrid.ItemsSource = customer.GetData();
        }
    }
    
    
}
