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
    /// Логика взаимодействия для RecheptPage.xaml
    /// </summary>
    public partial class RecheptPage : Page
    {
        public IEnumerable<IngredientOfCookingSage> IngredientOfCookings
        {
            get { return (IEnumerable<IngredientOfCookingSage>)GetValue(IngredientOfCookingsProperty); }
            set { SetValue(IngredientOfCookingsProperty, value); }
        }

        public static readonly DependencyProperty IngredientOfCookingsProperty =
            DependencyProperty.Register("IngredientOfCookings", typeof(IEnumerable<IngredientOfCookingSage>), typeof(RecheptPage));

        public IEnumerable<CookingStage> CookingStages
        {
            get { return (IEnumerable<CookingStage>)GetValue(CookingStagesProperty); }
            set { SetValue(CookingStagesProperty, value); }
        }

        public static readonly DependencyProperty CookingStagesProperty =
            DependencyProperty.Register("CookingStages", typeof(IEnumerable<CookingStage>), typeof(IngredientOfCookingSage));

        public Dish dish { get; set; }
        public RecheptPage(Dish _dish)
        {
            IngredientOfCookings = BdConect.db.CookingStage.Where(x => x.DishId == _dish.Id).SelectMany(s => s.IngredientOfCookingSage).ToList();
            CookingStages = BdConect.db.CookingStage.Where(x => x.DishId == _dish.Id).ToList();

            dish = _dish;
            InitializeComponent();
        }

        //private void AddIngredBtn_Click(object sender, RoutedEventArgs e) =>
        //    new AddCookStage(new Ingredient(), dish).ShowDialog();

        //private void SaveBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    dish.Title = TitleTb.Text.Trim();
        //    dish.Cost = int.Parse(CostTb.Text.Trim());
        //    BdConect.db.SaveChanges();
        //}

        private void CostTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TitleTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
