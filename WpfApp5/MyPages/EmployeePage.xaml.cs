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

namespace WpfApp5.MyPages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
            EmployeeLW.ItemsSource = BdConect.db.Employees.ToList();
            List<Role> listrole = BdConect.db.Role.ToList();
            listrole.Insert(0, new Role { Title = "Все роли" });
            OtdelCb.ItemsSource = listrole;
            OtdelCb.SelectedIndex = 0;

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var em = (sender as Button).DataContext as Employees;
            Navidation.NextPage(new Nav("Редактирвоание сотрдуника", new EditEmployeePage(em)));
         
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var em = (sender as Button).DataContext as Employees;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                BdConect.db.Employees.Remove(em);
            BdConect.db.SaveChanges();
            EmployeeLW.ItemsSource = BdConect.db.Employees.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navidation.NextPage(new Nav("Добавление сотрдуника", new EditEmployeePage(new Employees())));

        }
         private void Reshres() 
        {
            IEnumerable<Employees> employeslist = BdConect.db.Employees.ToList();
            if (OtdelCb.SelectedIndex != 0)
            {
                Role selectedrole = (Role)OtdelCb.SelectedItem;
                employeslist = employeslist.Where(x => x.RoleId == selectedrole.Id).ToList();
            }
            if (PoisTb == null)
                return;
            if (PoisTb.Text.Length > 0 )
            {
                employeslist = employeslist.Where(x => x.Name.StartsWith(PoisTb.Text) || x.LastName.StartsWith(PoisTb.Text));
            }
            EmployeeLW.ItemsSource = employeslist.ToList();
        }

      
        private void PoisTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Reshres();
        }

        private void OtdelCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reshres();
        }
    }
}
