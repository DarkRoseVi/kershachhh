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
using System.Windows.Shapes;
using WpfApp5.Componens;

namespace WpfApp5.MyPages
{
    /// <summary>
    /// Логика взаимодействия для AddIngredientProv.xaml
    /// </summary>
    public partial class AddIngredientProv : Window
    {
        public List<Ingredient> Ingredients { get; set; }

        private Provider _provider;

        public AddIngredientProv(IEnumerable<Landing> _landing, Provider provider)
        {
            _provider = provider;

            List<int> ingredientIds = _landing.Select(s => s.Ingredient.Id).ToList();

            Ingredients = BdConect.db.Ingredient.Where(x => ingredientIds.Contains(x.Id) == false).ToList();

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IngridientList.SelectedItem == null)
                return;

            if (QuantityTextBox.Text == "")
                return;

            BdConect.db.Landing.Add
            (
                new Landing()
                {
                    Ingredient = IngridientList.SelectedItem as Ingredient,
                    Provider = _provider,
                    Quantity = int.Parse(QuantityTextBox.Text.Trim()),
                    Date = DateTime.Now
                }
            );

            BdConect.db.SaveChanges();

            ProviderInfoPage.UpdateIngridientList(_provider);

            Close();
        }
    }
}
