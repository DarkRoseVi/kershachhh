using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp5.Componens;

namespace WpfApp5.MyPages
{
    /// <summary>
    /// Логика взаимодействия для RecipePage.xaml
    /// </summary>
    public partial class RecipePage : Page
    {
        public IEnumerable<IngredientOfCookingSage> IngredientOfCookings
        {
            get { return (IEnumerable<IngredientOfCookingSage>)GetValue(IngredientOfCookingsProperty); }
            set { SetValue(IngredientOfCookingsProperty, value); }
        }

        public static readonly DependencyProperty IngredientOfCookingsProperty =
            DependencyProperty.Register("IngredientOfCookings", typeof(IEnumerable<IngredientOfCookingSage>), typeof(RecipePage));

        public IEnumerable<CookingStage> CookingStages
        {
            get { return (IEnumerable<CookingStage>)GetValue(CookingStagesProperty); }
            set { SetValue(CookingStagesProperty, value); }
        }

        public static readonly DependencyProperty CookingStagesProperty =
            DependencyProperty.Register("CookingStages", typeof(IEnumerable<CookingStage>), typeof(IngredientOfCookingSage));

        public Dish dish { get; set; }
        public static RecipePage Instance;
        public RecipePage(Dish _dish)
        {
            IngredientOfCookings = BdConect.db.CookingStage.Where(x => x.DishId == _dish.Id).SelectMany(s => s.IngredientOfCookingSage).ToList();
            CookingStages = BdConect.db.CookingStage.Where(x => x.DishId == _dish.Id).ToList();

            dish = _dish;


            InitializeComponent();
            Instance = this;
        }


        private void AddIngredBtn_Click(object sender, RoutedEventArgs e) =>
            new AddCookStage(new Ingredient(), dish).ShowDialog();


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            dish.Title = TitleTb.Text.Trim();
            dish.Cost = int.Parse(CostTb.Text.Trim());
            BdConect.db.SaveChanges();
        }

        public static void UpdateIngridientList(Dish dish)
        {
            Instance.CookingStages = BdConect.db.CookingStage.Where(x => x.DishId == dish.Id).ToList();
        }



        private void CostTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void AddImageTbn_Click(object sender, RoutedEventArgs e) =>
              new AddImage(dish).ShowDialog();
    }
}
