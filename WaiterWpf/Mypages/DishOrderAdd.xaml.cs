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
using WaiterWpf.Mypages;
using WaiterWpf.Components;


namespace WaiterWpf.Mypages
{
    /// <summary>
    /// Логика взаимодействия для DishOrderAdd.xaml
    /// </summary>
    public partial class DishOrderAdd : Window
    {
        public List<Dish> dishes { get; set; }
        private Order _order;
        public DishOrderAdd(IEnumerable<Dish> _dishes, Order order)
        {
            _order = order;

            List<int> disexh = _dishes.Select(s => s.Id).ToList();

            dishes = BdConect.db.Dish.Where(x => disexh.Contains(x.Id) == false).ToList();

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IngridientList.SelectedItem == null)
                return;

            if (QuantityTextBox.Text == "")
                return;

            BdConect.db.OrderDish.Add(
                    new OrderDish()
                    {
                        Dish = IngridientList.SelectedItem as Dish,
                        Quantity = int.Parse(QuantityTextBox.Text.Trim()),
                        Order = _order
                    }
                );

            BdConect.db.SaveChanges();
            AddOrderpage.UpdateIngridientListWithOrder(_order);
            Close();
        }
    }
}
