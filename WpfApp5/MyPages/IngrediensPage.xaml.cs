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
    /// Логика взаимодействия для IngrediensPage.xaml
    /// </summary>
    public partial class IngrediensPage : Page
    {
        public IngrediensPage()
        {
            InitializeComponent();
            IngredientLW.ItemsSource = BdConect.db.Ingredient.ToList();
            List<Unit> units = BdConect.db.Unit.ToList();
            units.Insert(0, new Unit { Title = "Все" });
            UnitTb.ItemsSource = units;
            UnitTb.SelectedIndex = 0; 
        }
        private void Reshres() 
        {
            IEnumerable<Ingredient> ingredienslist = BdConect.db.Ingredient.ToList();
            if (UnitTb.SelectedIndex !=  0 )
            {
                Unit selectunit = (Unit)UnitTb.SelectedItem;
                ingredienslist = ingredienslist.Where(i => i.UnitId == selectunit.Id).ToList();   
            }

            if (PoisTb == null)
                return;
            if (PoisTb.Text.Length>0)
            {
                ingredienslist = ingredienslist.Where(x => x.Title.StartsWith(PoisTb.Text));
            }
            IngredientLW.ItemsSource = ingredienslist.ToList();
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var ingred = (sender as Button).DataContext as Ingredient;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                BdConect.db.Ingredient.Remove(ingred);
            BdConect.db.SaveChanges();
            IngredientLW.ItemsSource = BdConect.db.Ingredient.ToList();
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

        private void UnitTb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reshres();
        }

        private void PoisTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Reshres();
        }
    }
}
