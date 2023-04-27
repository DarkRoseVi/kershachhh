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
using WaiterWpf.Components;
using WaiterWpf.Mypages;

namespace WaiterWpf.Mypages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            NameTb.Text = Navigation.AutoUser.Name;
            LastNamTb.Text = Navigation.AutoUser.LastName;
        }

        private void DishBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new DishPage());
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new OrderPage());
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new ClientPage());
        }

        private void ExsitBtn_Click(object sender, RoutedEventArgs e) 
        {
            NavigationService.Navigate(new AutoPage());
        }
  
       
    }
}
