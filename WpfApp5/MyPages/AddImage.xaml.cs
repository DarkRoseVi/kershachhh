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
using System.Windows.Shapes;
using WpfApp5.Componens;
using WpfApp5.MyPages;

namespace WpfApp5.MyPages
{
    /// <summary>
    /// Логика взаимодействия для AddImage.xaml
    /// </summary>
    public partial class AddImage : Window
    {
        public Dish dis { get; set; }
        public static byte[] image { get; set; }
        public AddImage(Dish dish)
        {
            dis = dish;
            InitializeComponent();
            DisTb.Text = dis.Title;
            int id = dis.Id;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFil = new OpenFileDialog()
            {
                Filter = "**.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg",
            };
            if (openFil.ShowDialog().GetValueOrDefault())
            {
                image = File.ReadAllBytes(openFil.FileName);
                IngredientPhoto.Source = new BitmapImage(new Uri(openFil.FileName));
            }
        }

        private void SavveBtn_Click(object sender, RoutedEventArgs e)
        {
            BdConect.db.Dish.FirstOrDefault(x => x.Id == dis.Id).Photo = image;
            MessageBox.Show("yes");
            BdConect.db.SaveChanges();
        }
    }
}
