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

namespace Szinkevero
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            sliPiros.Value = 120;
            sliZold.Value = 120;
            sliKek.Value = 120;
        }

        private void sliRGB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(sliPiros.Value), Convert.ToByte(sliZold.Value), Convert.ToByte(sliKek.Value)));
            Piroslabel.Content = Convert.ToByte(sliPiros.Value);
            Zoldlabel.Content = Convert.ToByte(sliZold.Value);
            Keklabel.Content = Convert.ToByte(sliKek.Value);
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            String szinAdatok = $"{Convert.ToByte(sliPiros.Value)};{Convert.ToByte(sliZold.Value)};{Convert.ToByte(sliKek.Value)}";
            if (lbSzinek.Items.Contains(szinAdatok))
            {
                MessageBox.Show("Ez már a listában van!");
            }
            else
            {
            lbSzinek.Items.Add(szinAdatok);
            }
        }

        private void btnTorol_Click(object sender, RoutedEventArgs e)
        {
            if (lbSzinek.SelectedIndex>=0)
            {
                //MessageBox.Show(lbSzinek.SelectedIndex.ToString());
                lbSzinek.Items.RemoveAt(lbSzinek.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Nincs Kiválasztott elem!");
            }
        }

        private void btnUrit_Click(object sender, RoutedEventArgs e)
        {
            lbSzinek.Items.Clear();
        }

        private void kivalaszt(object sender, SelectionChangedEventArgs e)
        {
            string[] tagok = { "120", "120", "120" };
            if (lbSzinek.SelectedItem != null)
            {
            tagok = lbSzinek.SelectedItem.ToString().Split(';');
            }
            byte red = Convert.ToByte(tagok[0]);
            byte green = Convert.ToByte(tagok[1]);
            byte blue = Convert.ToByte(tagok[2]);
            Piroslabel.Content = red;
            Zoldlabel.Content = green;
            Keklabel.Content = blue;
            sliPiros.Value = red;
            sliZold.Value = green;
            sliKek.Value = blue;
            rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb(red, green, blue));
        }
    }
}
