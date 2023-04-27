using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp5.Componens;

namespace WpfApp5.MyPages
{
    /// <summary>
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        public static AddOrderPage Instance { get; private set; }


        public IEnumerable<Dish> diseslidt
        {
            get { return (IEnumerable<Dish>)GetValue(diseslidtProperty); }
            set { SetValue(diseslidtProperty, value); }
        }

        public static readonly DependencyProperty diseslidtProperty =
            DependencyProperty.Register("diseslidt", typeof(IEnumerable<Dish>), typeof(AddOrderPage));


        public Order orders { get; set; }
        public AddOrderPage(Order _orders)
        {
            orders = _orders;
            diseslidt = BdConect.db.Dish.ToList();
            InitializeComponent();
            Instance = this;

            ClientCb.ItemsSource = BdConect.db.Сlient.ToList();
            ClientCb.DisplayMemberPath = "LastName";
            EmployeeCb.ItemsSource = BdConect.db.Employees.ToList();
            EmployeeCb.DisplayMemberPath = "LastName";
            StatysCb.ItemsSource = BdConect.db.Status.ToList();
            StatysCb.DisplayMemberPath = "Title";
            UpdateIngridientListWithOrder(orders);
        }
        public static void UpdateIngridientListWithOrder(Order orders)
        {
            Instance.diseslidt = BdConect.db.OrderDish.Where(x => x.OrserId == orders.Id).Select(s => s.Dish).ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            orders.Сlient = ClientCb.SelectedItem as Сlient;
            orders.Employees = EmployeeCb.SelectedItem as Employees;
            orders.Status = StatysCb.SelectedItem as Status;

            orders.Sum = 0;
            orders.OrderDish = BdConect.db.OrderDish.Local.Where(x => x.OrserId == orders.Id).ToArray();
            MessageBox.Show("Заказ создан");

            BdConect.db.SaveChanges();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e) =>
         new DishOrderAdd(diseslidt, orders).ShowDialog();
    }
}
