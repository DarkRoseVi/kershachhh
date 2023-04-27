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
using WpfApp5.Componens;
using WpfApp5.MyPages;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navidation.main = this;
        }

        private void EmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            Navidation.NextPage(new Nav("Список сотрудников", new EmployeePage()));

        }

        private void DishBtn_Click(object sender, RoutedEventArgs e)
        {
            Navidation.NextPage(new Nav("Список блюд", new DishPage()));
        }

        private void ProviderBtn_Click(object sender, RoutedEventArgs e)
        {
            Navidation.NextPage(new Nav("Список поставщиков", new ProviderPage()));
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            Navidation.NextPage(new Nav("", new OrderPage()));
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            Navidation.NextPage(new Nav("", new ClientPage()));
        }

        private void IngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            Navidation.NextPage(new Nav("", new IngredientPage()));
        }

        private void LandingBtn_Click(object sender, RoutedEventArgs e)
        {
            Navidation.NextPage(new Nav("", new LandingPage()));
        }
    }
}
