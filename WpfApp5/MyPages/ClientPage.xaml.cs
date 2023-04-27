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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
   
        public ClientPage()
        {

            InitializeComponent();
            ClientLW.ItemsSource = BdConect.db.Сlient.ToList();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navidation.NextPage(new Nav("Добавление клиента", new EsitClientPage(new Сlient())));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var n = (sender as Button).DataContext as Сlient;
            Navidation.NextPage(new Nav("Добавление клиента", new EsitClientPage(n)));

        }

        public void Reshre() 
        {
            IEnumerable<Сlient> clList = BdConect.db.Сlient;

            if (SortCb.SelectedItem != null)
            {
                switch ((SortCb.SelectedItem as ComboBoxItem).Tag)
                {
                    case "1":
                        clList = clList.OrderBy(x => x.Name);
                        break;
                    case "2":
                        clList = clList.OrderByDescending(x => x.Name);
                        break;
                    case "3":
                        clList = BdConect.db.Сlient;
                        break;
                    default:
                        break;
                }

            }
            if (PoisTb == null)
                return;
            if (PoisTb.Text.Length > 0 )
            {
                clList = clList.Where(x => x.LastName.StartsWith(PoisTb.Text) || x.LastName.StartsWith(PoisTb.Text) );
             }
            ClientLW.ItemsSource = clList.ToList();
        }
        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var em = (sender as Button).DataContext as Сlient;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                BdConect.db.Сlient.Remove(em);
            BdConect.db.SaveChanges();
            ClientLW.ItemsSource = BdConect.db.Сlient.ToList();
        }

        private void PoisTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Reshre();

        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reshre();
        }

        private void PoisTb_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Reshre();
        }
    }
}
