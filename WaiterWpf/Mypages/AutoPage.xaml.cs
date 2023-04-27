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
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        private void VxodBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Text.Trim();
            if (login.Length == 0 && password.Length == 0)
            {
                MessageBox.Show("Заполните поля!");
            }
            else
            {
                var users = BdConect.db.Employees.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
                if (users == null )
                {
                    MessageBox.Show("Увы такого пользователя нет,зарегистрируйтесь пожалуйства");
                }
                else
                {
                    if (users.RoleId == 5)
                    {

                        Navigation.AutoUser = users;
                        NavigationService.Navigate(new HomePage());
                    }
                    else MessageBox.Show("У вас нет прав официанта");
                }
            }
        }
    }
}
