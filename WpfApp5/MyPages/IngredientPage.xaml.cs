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
    /// Логика взаимодействия для IngredientPage.xaml
    /// </summary>
    public partial class IngredientPage : Page
    {
        public IngredientPage()
        {
            InitializeComponent();
            IngredientLW.ItemsSource = BdConect.db.Ingredient.ToList();
            List<Unit> unitlist = BdConect.db.Unit.ToList();
            unitlist.Insert(0, new Unit { Title = "Все" });
            UnitlCb.ItemsSource = unitlist;
            UnitlCb.SelectedIndex = 0;
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var ing = (sender as Button).DataContext as Ingredient;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                BdConect.db.Ingredient.Remove(ing);
            BdConect.db.SaveChanges();
        }
        public void reshres() 
        {
        IEnumerable<Ingredient> inglist = BdConect.db.Ingredient.ToList();
            if (UnitlCb.SelectedIndex !=0)
            {
                Unit selectiunt = (Unit)UnitlCb.SelectedItem;
                inglist = inglist.Where(x=>x.UnitId == selectiunt.Id).ToList();
            }
            IngredientLW.ItemsSource = inglist.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var ing = (sender as Button).DataContext as Ingredient;
            Navidation.NextPage(new Nav("Редактирование", new EsitIngredientpage(ing)));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navidation.NextPage(new Nav("Добавление", new EsitIngredientpage(new Ingredient())));
        }

        private void UnitlCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            reshres();
        }
    }
}
