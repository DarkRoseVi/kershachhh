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
using ClientWpf.Components;
using ClientWpf.MyPages;


namespace ClientWpf.MyPages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordTb.Text.Trim();
            string login = LoginTb.Text.Trim();
            string name = NameTb.Text.Trim();   
            string lastname = LastNameTb.Text.Trim();
            string patromimyc = PatronimecTb.Text.Trim();
            if (password.Length > 0 && login.Length>0 && name.Length>0 && lastname.Length>0 && patromimyc.Length>0 )
            {
                if (BdConect.db.Сlient.Local.Any(x => x.Name == name && x.LastName == lastname && x.Patronymic == patromimyc))
                {
                    MessageBox.Show("Такой пользователь уже существует");
                    return;
                }
                else
                {
                    BdConect.db.Сlient.Add(new Сlient
                    {
                        LastName = lastname,
                        Password = password,
                        Login = login,
                        Name = name,    
                        Patronymic = patromimyc,    
                    });
                    BdConect.db.SaveChanges();
                    MessageBox.Show("Вы зрегистрированны");
                    NavigationService.Navigate(new AutoPage());
                }

            }
            else MessageBox.Show("Заполните все поля");
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordTb.Clear();
            LoginTb.Clear();
            NameTb.Clear();
            PatronimecTb.Clear();
            LastNameTb.Clear();
        }
    }
}
