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
    /// Логика взаимодействия для ProviderPage.xaml
    /// </summary>
    public partial class ProviderPage : Page
    {
        public ProviderPage()
        {
            InitializeComponent();
            ProviderLW.ItemsSource = BdConect.db.Provider.ToList();

        }

    

        private void ProsmotrBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Provider;
            Navidation.NextPage(new Nav("Информация", new ProviderInfoPage(prod)));
        }
    }
}
