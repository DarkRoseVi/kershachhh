using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp5.Componens;
using WpfApp5.MyPages;
using System.Data.Entity;

namespace WpfApp5.MyPages
{
    /// <summary>
    /// Логика взаимодействия для ProviderInfoPage.xaml
    /// </summary>
    public partial class ProviderInfoPage : Page
    {
        public static ProviderInfoPage Instance { get; private set; }

        public IEnumerable<Ingredient> ingrediebt
        {
            get { return (IEnumerable<Ingredient>)GetValue(ingrediebtProperty); }
            set { SetValue(ingrediebtProperty, value); }
        }

        public static readonly DependencyProperty ingrediebtProperty =
            DependencyProperty.Register("ingrediebt", typeof(IEnumerable<Ingredient>), typeof(ObservableCollection<Ingredient>));



        public IEnumerable<Landing> landings
        {
            get { return (IEnumerable<Landing>)GetValue(landingsProperty); }
            set { SetValue(landingsProperty, value); }
        }
        public static readonly DependencyProperty landingsProperty =
            DependencyProperty.Register("landings", typeof(IEnumerable<Landing>), typeof(ProviderInfoPage));



        public Provider Proviser { get; set; }
        public ProviderInfoPage(Provider _provider)
        {
            Proviser = _provider;
            
            ingrediebt = BdConect.db.Ingredient.ToList();
            
            InitializeComponent();

            Instance = this;

            UpdateIngridientList(Proviser);
        }

        public static void UpdateIngridientList(Provider Proviser)
        {
            Instance.landings = BdConect.db.Landing.Where(x => x.ProviderId == Proviser.Id).ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var ProviderId = BdConect.db.Provider.Where(x => x.Title == NameTb.Text.Trim()).FirstOrDefault();
            if (ProviderId == null)
            {
                BdConect.db.Provider.Add(Proviser);
                MessageBox.Show("Yes");
            }
            BdConect.db.SaveChanges();
              
 
              
                Navidation.NextPage(new Nav("", new ProviderPage()));

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e) =>
            new AddIngredientProv(landings, Proviser).ShowDialog();

        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void PhoneTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
