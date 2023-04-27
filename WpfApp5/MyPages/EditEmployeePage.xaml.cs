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
    /// Логика взаимодействия для EditEmployeePage.xaml
    /// </summary>
    public partial class EditEmployeePage : Page
    {
        public  Employees emloyees { get; set; }
        public EditEmployeePage(Employees _employees)
        {
            emloyees = _employees;
            InitializeComponent();
           
            CmbRole.ItemsSource = BdConect.db.Role.ToList();
            CmbRole.DisplayMemberPath = "Title";

        }
        

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var EmployeeId = BdConect.db.Employees.Where(x => x.Name == NameTb.Text.Trim()&& x.Patronymic == PatronumekTb.Text.Trim()&& x.LastName == LastNameTb.Text.Trim()).FirstOrDefault();
            if (EmployeeId == null)
            {
                BdConect.db.Employees.Add(emloyees);
                MessageBox.Show("yes");

            }
            BdConect.db.SaveChanges();
            Navidation.NextPage(new Nav("Сотрудники", new EmployeePage()));
        }

        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void LastNameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void PatronumekTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

     
    }
}
