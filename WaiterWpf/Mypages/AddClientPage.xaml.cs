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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        public Сlient client { get; set; }
        public AddClientPage(Сlient _client)
        {
            client = _client;
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var ClientId = BdConect.db.Сlient.Where(x => x.Name == NameTb.Text.Trim() && x.Patronymic == PatronumekTb.Text.Trim() && x.LastName == LastNameTb.Text.Trim()).FirstOrDefault();
            if (ClientId == null)
            {
                BdConect.db.Сlient.Add(client);
                MessageBox.Show("yes");

            }
            BdConect.db.SaveChanges();
            NavigationService.Navigate(new ClientPage());
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
