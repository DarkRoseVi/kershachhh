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
    /// Логика взаимодействия для Laindingpge.xaml
    /// </summary>
    public partial class Laindingpge : Page
    {
        public Laindingpge()
        {
            InitializeComponent();
            Listlaidunf.ItemsSource = BdConect.db.Landing.ToList();
            IngCb.ItemsSource = BdConect.db.Ingredient.ToList();
            IngCb.DisplayMemberPath = "Title";
            ProviderCb.ItemsSource = BdConect.db.Provider.ToList();
            ProviderCb.DisplayMemberPath = "Title";
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            int qount = Convert.ToInt32(QountititTb.Text.Trim());
            BdConect.db.Landing.Add(new Landing
            {
                Ingredient = IngCb.SelectedItem as Ingredient,
                Provider = ProviderCb.SelectedItem as Provider,
                //Date = datePc.SelectedDate as DatePicker,
                //Date = dataBt.DataContext
                Quantity = qount,
            }) ;
            MessageBox.Show("Поставка создана");
            BdConect.db.SaveChanges();
            Listlaidunf.ItemsSource = BdConect.db.Landing.ToList();
        }
    }
}
