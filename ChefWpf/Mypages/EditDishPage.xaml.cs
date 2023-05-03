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
    /// Логика взаимодействия для EditDishPage.xaml
    /// </summary>
    public partial class EditDishPage : Page
    {
        public IEnumerable<IngredientOfCookingSage> IngredientOfCookings
        {
            get { return (IEnumerable<IngredientOfCookingSage>)GetValue(IngredientOfCookingsProperty); }
            set { SetValue(IngredientOfCookingsProperty, value); }
        }

        public static readonly DependencyProperty IngredientOfCookingsProperty =
            DependencyProperty.Register("IngredientOfCookings", typeof(IEnumerable<IngredientOfCookingSage>), typeof(EditDishPage));

        public IEnumerable<CookingStage> CookingStages
        {
            get { return (IEnumerable<CookingStage>)GetValue(CookingStagesProperty); }
            set { SetValue(CookingStagesProperty, value); }
        }

        public static readonly DependencyProperty CookingStagesProperty =
            DependencyProperty.Register("CookingStages", typeof(IEnumerable<CookingStage>), typeof(IngredientOfCookingSage));

        public Dish dish { get; set; }
        public static EditDishPage Instance;
        public EditDishPage(Dish _dish)
        {
            IngredientOfCookings = BdConect.db.CookingStage.Where(x => x.DishId == _dish.Id).SelectMany(s => s.IngredientOfCookingSage).ToList();
            CookingStages = BdConect.db.CookingStage.Where(x => x.DishId == _dish.Id).ToList();

            dish = _dish;

            InitializeComponent();
        }
        public static void UpdateIngridientList(Dish dish)
        {
            Instance.CookingStages = BdConect.db.CookingStage.Where(x => x.DishId == dish.Id).ToList();
        }

        private void AddIngredBtn_Click(object sender, RoutedEventArgs e) =>
            new AddCookStage(new Ingredient(), dish).ShowDialog();

        private void AddImageTbn_Click(object sender, RoutedEventArgs e) =>
            new AddImage(dish).ShowDialog();

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            dish.Title = TitleTb.Text.Trim();
            dish.Cost = int.Parse(CostTb.Text.Trim());
            BdConect.db.SaveChanges();
        }
    }
}
