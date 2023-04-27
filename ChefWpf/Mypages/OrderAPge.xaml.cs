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
using ChefWpf.Componens;
using ChefWpf.Mypages;


namespace ChefWpf.Mypages
{
    /// <summary>
    /// Логика взаимодействия для OrderAPge.xaml
    /// </summary>
    public partial class OrderAPge : Page
    {

        public OrderAPge()
        {
      

            InitializeComponent();
            OrdertListViu.ItemsSource = BdConect.db.Order.Where(x => x.StatysId == 2 || x.StatysId == 3 || x.StatysId == 4).ToList();
                
                }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new AddOrderPage(new Order()));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var or = (sender as Button).DataContext as Order;
            NavigationService.Navigate(new EditOrderPage(or));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var em = (sender as Button).DataContext as Order;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                BdConect.db.Order.Remove(em);
            BdConect.db.SaveChanges();

        }
    }
}
