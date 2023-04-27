using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using WpfApp5.MyPages;
using WpfApp5.Componens;

namespace WpfApp5.MyPages
{
    /// <summary>
    /// Логика взаимодействия для EsitIngredientpage.xaml
    /// </summary>
    public partial class EsitIngredientpage : Page
    {
        public Ingredient ingrediebts { get; set; }
        public EsitIngredientpage(Ingredient _ingredient)
        {
            ingrediebts = _ingredient;
            InitializeComponent();
            UnitCb.ItemsSource = BdConect.db.Unit.ToList();
            UnitCb.DisplayMemberPath = "Title";
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFil = new OpenFileDialog()
            {
                Filter = "**.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg",
            };
            if (openFil.ShowDialog().GetValueOrDefault())
            {
                ingrediebts.Photo = File.ReadAllBytes(openFil.FileName);
                IngredientPhoto.Source = new BitmapImage(new Uri(openFil.FileName));
            }

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var IgredientId = BdConect.db.Ingredient.Where(x => x.Title == TitleTb.Text.Trim()).FirstOrDefault();
            if (IgredientId == null)
            {
                BdConect.db.Ingredient.Add(ingrediebts);
                
            }
            BdConect.db.SaveChanges();
            MessageBox.Show("yes");
            Navidation.NextPage(new Nav("Продукты", new IngredientPage()));
        }

        private void QouantitiTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
