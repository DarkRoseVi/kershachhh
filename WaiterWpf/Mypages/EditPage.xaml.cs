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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public Order order { get; set; }
        public EditPage(Order _order)
        {
            InitializeComponent();
               

            order = _order;
            InitializeComponent();
            ClientCb.ItemsSource = BdConect.db.Сlient.ToList();
            ClientCb.DisplayMemberPath = "LastName";
            EmployeeCb.ItemsSource = BdConect.db.Employees.ToList();
            EmployeeCb.DisplayMemberPath = "LastName";
            StatysCb.ItemsSource = BdConect.db.Status.ToList();
            StatysCb.DisplayMemberPath = "Title";
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            order.Сlient = ClientCb.SelectedItem as Сlient;
            order.Employees = EmployeeCb.SelectedItem as Employees;
            order.Status = StatysCb.SelectedItem as Status;
            BdConect.db.SaveChanges();
        }
    }
  }
