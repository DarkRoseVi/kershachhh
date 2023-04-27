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
using CookWpf.Components;
using CookWpf.Pages;


namespace CookWpf.Pages
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
            LastNameTb.Text = Navigation.AutoUser.LastName;
            RoleTb.Text = Navigation.AutoUser.Role.Title;
        }

        private void IngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new IngredientPage());

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
          NavigationService.Navigate(new  AutoPage());
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new OrderPage());
        }

        private void DishBtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new DishPage());
        }
    }
}
