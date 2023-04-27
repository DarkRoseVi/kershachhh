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
    /// Логика взаимодействия для AddOrderpage.xaml
    /// </summary>
    public partial class AddOrderpage : Page
    {
        public static AddOrderpage Instance { get; private set; }


        public IEnumerable<Dish> diseslidt
        {
            get { return (IEnumerable<Dish>)GetValue(diseslidtProperty); }
            set { SetValue(diseslidtProperty, value); }
        }

        public static readonly DependencyProperty diseslidtProperty =
            DependencyProperty.Register("diseslidt", typeof(IEnumerable<Dish>), typeof(AddOrderpage));


        public Order orders { get; set; }
        public AddOrderpage(Order _orders)
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
            orders.Sum = 0;
            orders.Status = StatysCb.SelectedItem as Status;
            orders.OrderDish = BdConect.db.OrderDish.Local.Where(x => x.OrserId == orders.Id).ToArray();
            BdConect.db.SaveChanges();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)=>
         new DishOrderAdd(diseslidt, orders).ShowDialog();
    
    }
}
