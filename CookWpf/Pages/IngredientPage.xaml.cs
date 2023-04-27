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
using CookWpf.Pages;
using CookWpf.Components;

namespace CookWpf.Pages
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

        private void UnitlCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            reshres();
        }
        public void reshres()
        {
            IEnumerable<Ingredient> inglist = BdConect.db.Ingredient.ToList();
            if (UnitlCb.SelectedIndex != 0)
            {
                Unit selectiunt = (Unit)UnitlCb.SelectedItem;
                inglist = inglist.Where(x => x.UnitId == selectiunt.Id).ToList();
            }
            IngredientLW.ItemsSource = inglist.ToList();
        }
    }
}
