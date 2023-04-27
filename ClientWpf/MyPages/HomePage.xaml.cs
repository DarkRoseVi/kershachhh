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
using ClientWpf.Components;
using ClientWpf.MyPages;

namespace ClientWpf.MyPages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            //NameTb.Text = Navogation.AutoUser.Name;
            //lastnameTb.Text  = Navogation.AutoUser.LastName;
            //PatromimecTb.Text = Navogation.AutoUser.Patronymic;
        }

        private void DishBtn_Click(object sender, RoutedEventArgs e)
        {
            //InfaSt.Visibility.HasFlag(Visibility.Visible);
            MyFrame.NavigationService.Navigate(new DishPage());
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate( new AddOrderPage());
        }

        private void ExsitBtn_Click(object sender, RoutedEventArgs e)
        {
          NavigationService.Navigate(new AutoPage());
        }
    }
}
