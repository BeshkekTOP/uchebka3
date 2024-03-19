using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

namespace Uchebka1
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        private CarRentalEntities context = new CarRentalEntities();
        public Window3()
        {
            InitializeComponent();
            CarsDataGrid.ItemsSource = context.Cars.ToList();

        }

        private void CarsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarsDataGrid != null)
            {
                var selected = CarsDataGrid.SelectedItem as Cars;
                context.SaveChanges();
                BrandTbx.DataContext = selected.Brand;
            }
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
           
                Cars mashina = new Cars();
                mashina.Brand = BrandTbx.Text;

                context.Cars.Add(mashina);
                context.SaveChanges();
                CarsDataGrid.ItemsSource = context.Cars.ToList();
           
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CarsDataGrid.SelectedItem != null)
            {
                context.Cars.Remove(CarsDataGrid.SelectedItem as Cars);

                context.SaveChanges();
                CarsDataGrid.ItemsSource = context.Cars.ToList();
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CarsDataGrid != null)
            {
                var selected = CarsDataGrid.SelectedItem as Cars;

                selected.Brand = BrandTbx.Text;
                context.SaveChanges();
                CarsDataGrid.ItemsSource= context.Cars.ToList();
            }
        }

        private void NextTable3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void LastTable1_Click(object sender, RoutedEventArgs e)
        {
            Window2 window = new Window2();
            window.Show();
            Close();
        }
    }
}
