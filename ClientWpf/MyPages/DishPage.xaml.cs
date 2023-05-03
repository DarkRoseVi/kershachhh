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
using ClientWpf.Components;
using ClientWpf.MyPages;

namespace ClientWpf.MyPages
{
    /// <summary>
    /// Логика взаимодействия для DishPage.xaml
    /// </summary>
    public partial class DishPage : Page
    {
        kersachViEntities _context = new kersachViEntities();
        public DishPage()
        {
            InitializeComponent();
            LViewDishes.ItemsSource = BdConect.db.Dish.ToList();
            List<Category> cated = BdConect.db.Category.ToList();
            cated.Insert(0, new Category { Title = "Все" });
            CategorylCb.ItemsSource = cated;
            CategorylCb.SelectedIndex = 0;
            Refrese();
        }
        private void Refrese()
        {
            List<Dish> listdis = _context.Dish.ToList();
            if (CategorylCb.SelectedIndex != 0)
            {
                Category categose = (Category)CategorylCb.SelectedItem;
                listdis = listdis.Where(x => x.CategoryId == categose.Id).ToList();
            }
            var DegreeCb = DegreeSharpnesslCb.SelectedItem as ComboBoxItem;
            if (DegreeCb != null)
            {
                if (DegreeCb.Tag.ToString() == "1")
                    listdis = listdis.ToList();
                if (DegreeCb.Tag.ToString() == "2")
                    listdis = listdis.Where(x => x.DegreeSharpnessId == 1).ToList();
                if (DegreeCb.Tag.ToString() == "3")
                    listdis = listdis.Where(x => x.DegreeSharpnessId == 2).ToList();
                if (DegreeCb.Tag.ToString() == "4")
                    listdis = listdis.Where(x => x.DegreeSharpnessId == 3).ToList();
                if (DegreeCb.Tag.ToString() == "5")
                    listdis = listdis.Where(x => x.DegreeSharpnessId == 4).ToList();
                if (DegreeCb.Tag.ToString() == "6")
                    listdis = listdis.Where(x => x.DegreeSharpnessId == 5).ToList();
            }
            if (PoisTb == null)
                return;
            if (PoisTb.Text.Length > 0)
            {
                listdis = listdis.Where(x => x.Title.StartsWith(PoisTb.Text)).ToList();
            }

            LViewDishes.ItemsSource = listdis;
        }

        private void CategorylCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refrese();
        }

        private void DegreeSharpnesslCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refrese();
        }

        private void PoisTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refrese();
        }
    }
}
