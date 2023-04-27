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
using ClientWpf.MyPages;
using ClientWpf.Components;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace ClientWpf.MyPages
{
    /// <summary>
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
        
    public partial class AddOrderPage : Page
    {
        //public ObservableCollection<Order> orders
        //{
        //    get { return (ObservableCollection<Order>)GetValue(ordersProperty); }
        //    set { SetValue(ordersProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ordersProperty =
        //    DependencyProperty.Register("orders", typeof(ObservableCollection<Order>), typeof(AddOrderPage), new PropertyMetadata(0));

        public AddOrderPage()
        {
            //BdConect.db.Order.Load();
            //orders = BdConect.db.Order.Local.FirstOrDefault(x => x.Сlient.Id = Navogation.AutoUser.Id).ToArray();

            InitializeComponent();
            OrdertListViu.ItemsSource = BdConect.db.Order.Where(x => x.ClientId == Navogation.AutoUser.Id).ToList();
        }
    }
}
