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
            Refrese();
        }
        private void Refrese()
        {
            List<Dish> listdis = _context.Dish.ToList();
            LViewDishes.ItemsSource = listdis;
        }
    }
}
