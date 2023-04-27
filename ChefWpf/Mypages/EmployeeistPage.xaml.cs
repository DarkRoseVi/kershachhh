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
    /// Логика взаимодействия для EmployeeistPage.xaml
    /// </summary>
    public partial class EmployeeistPage : Page
    {
        public EmployeeistPage()
        {
            InitializeComponent();
            EmployeeLW.ItemsSource = BdConect.db.Employees.Where(x=>x.RoleId == 1).ToList();
        }
        private void Reshres()
        {
            IEnumerable<Employees> employeslist = BdConect.db.Employees.ToList();
           

            if (PoisTb == null)
                return;
            if (PoisTb.Text.Length > 0)
            {
                employeslist = employeslist.Where(x => x.Name.StartsWith(PoisTb.Text) || x.LastName.StartsWith(PoisTb.Text));
            }
            EmployeeLW.ItemsSource = employeslist.ToList();
        }

        private void PoisTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Reshres();
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {

            var em = (sender as Button).DataContext as Employees;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                BdConect.db.Employees.Remove(em);
            BdConect.db.SaveChanges();
            EmployeeLW.ItemsSource = BdConect.db.Employees.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var ue = (sender as Button).DataContext as Employees;
            NavigationService.Navigate(new EditEmployeePage(ue));
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditEmployeePage(new Employees()));
        }
    }
}
