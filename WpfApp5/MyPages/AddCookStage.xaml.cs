using System.Linq;
using System.Windows;
using WpfApp5.Componens;

namespace WpfApp5.MyPages
{
    /// <summary>
    /// Логика взаимодействия для AddCookStage.xaml
    /// </summary>
    public partial class AddCookStage : Window
    {
        public Ingredient cookingStage { get; set; }
        public Dish dis { get; set; }
        public AddCookStage(Ingredient _cookingStage, Dish dish)
        {
            cookingStage = _cookingStage;
            dis = dish;
            InitializeComponent();
            DisTb.Text = dis.Title;
            int id = dis.Id;
            IngredienCb.ItemsSource = BdConect.db.Ingredient.ToList();
            IngredienCb.DisplayMemberPath = "Title";

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            BdConect.db.IngredientOfCookingSage.Add(new IngredientOfCookingSage
            {
                Ingredient = IngredienCb.SelectedItem as Ingredient,
                Quantity = int.Parse(QuantityTb.Text.Trim()),
                CookingStage = new CookingStage
                {
                    DishId = dis.Id,
                    Description = DescriptionTb.Text.Trim(),
                },
            });

            MessageBox.Show("yes");
            BdConect.db.SaveChanges();
            RecipePage.UpdateIngridientList(dis);
        }
    }
}
