using ChefWpf.Componens;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ChefWpf.Mypages
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

        private void SavveBtn_Click(object sender, RoutedEventArgs e)
        {
            BdConect.db.Dish.FirstOrDefault(x => x.Id == dis.Id).Photo = image;
            MessageBox.Show("yes");
            BdConect.db.SaveChanges();
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
    }
}
