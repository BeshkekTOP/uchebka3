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

namespace Uchebka1
{
    /// <summary>
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        private CarRentalEntities context = new CarRentalEntities();
        public Window5()
        {
            InitializeComponent();
            Inner2GataGrid.ItemsSource = context.Rentals.ToList();
        }

        private void Inner2GataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
