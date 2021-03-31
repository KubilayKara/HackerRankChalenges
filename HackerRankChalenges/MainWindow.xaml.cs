using HackerRankChalenges.Challanges;
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

namespace HackerRankChalenges
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCommonnChid_Click(object sender, RoutedEventArgs e)
        {
            CommonChild.FindCommonChildSize(this.TxtCommonChil1.Text, this.TxtCommonChil2.Text);
        }

        private void BtnBeatifulTriplets_Click(object sender, RoutedEventArgs e)
        {

            int[] arr = ToIntArray(this.TxtBeatifulTripletsArray.Text);
            int dif = int.Parse(this.TxtBeatifulTripletsDif.Text);

            MessageBox.Show($"Result:{BeatifulTriplets.FindBeautifulTriplets(dif, arr)}");
        }

        private static int[] ToIntArray(string s)
        {
            var stryArr = s.Split(' ');
            return Array.ConvertAll(stryArr, Convert.ToInt32);
        }

        private void BtnMarkAndToys_Click(object sender, RoutedEventArgs e)
        {
            var result = MarkAndToys.MaximumToys(ToIntArray(this.TxtMarkAndToysPrices.Text), int.Parse(this.TxtMarkAndToysMoney.Text));
            MessageBox.Show($"Result:{result}");
        }

        private void BtnBubbleSort_Click(object sender, RoutedEventArgs e)
        {
            BubbleSort.CountSwaps(ToIntArray(this.TxtMarkAndToysPrices.Text));
        }
    }
}
