using HackerRankChalenges.Challanges;
using HackerRankChalenges.Challanges.Amazon;
using HackerRankChalenges.Challanges.Certificates;
using HackerRankChalenges.Challanges.CrackingTheCodeInterview.ArraysAndString;
using HackerRankChalenges.Challanges.CrackingTheCodeInterview.LinkedLists;
using HackerRankChalenges.Challanges.CrackingTheCodeInterview.RecurisonAndDynamicProgramming;
using HackerRankChalenges.Challanges.Interview_Preparation_Kit;
using HackerRankChalenges.Challanges.LeetCode75;
using HackerRankChalenges.Challanges.LeetCode75.Binary;
using HackerRankChalenges.Challanges.LeetCode75.Dynamic_Programming;
using HackerRankChalenges.Challanges.LeetCode75.Graph;
using HackerRankChalenges.Challanges.LeetCodeAlgo1;
using HackerRankChalenges.Challanges.Problem_Solving;
using HackerRankChalenges.Challanges.Strings;
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
            this.ChalengeList.Items.Add(new AS2Q1());
            this.ChalengeList.Items.Add(new AS2Q2());
            this.ChalengeList.Items.Add(new AS1Q1());
            this.ChalengeList.Items.Add(new AS1Q2());
            this.ChalengeList.Items.Add(new LeetSumOfTwoIntagers());
            this.ChalengeList.Items.Add(new LeetCloneGraph());
            this.ChalengeList.Items.Add(new LeetCoinChange());
            this.ChalengeList.Items.Add(new LeetFirstBadVersion());
            this.ChalengeList.Items.Add(new LeetSortedSquares());
            this.ChalengeList.Items.Add(new LeetRotateArray());
            this.ChalengeList.Items.Add(new LeetTwoSum());
            
            this.ChalengeList.Items.Add(new TwoCharacters());
            this.ChalengeList.Items.Add(new FibonacciNumbers());
            this.ChalengeList.Items.Add(new DavisStairCase());
            this.ChalengeList.Items.Add(new CrossWordPuzzle());
            this.ChalengeList.Items.Add(new ProblemSolving_Intermediate());
            this.ChalengeList.Items.Add(new DivisibleSumPairs());
            this.ChalengeList.Items.Add(new ExtraLongFactorials());
            this.ChalengeList.Items.Add(new FormingMagicSquare());
            this.ChalengeList.Items.Add(new Sms());
            this.ChalengeList.Items.Add(new PicingNumbers());
            this.ChalengeList.Items.Add(new TwoSum());
            this.ChalengeList.Items.Add(new ProductExceptSelf());
            this.ChalengeList.Items.Add(new MaxSubArray());
            this.ChalengeList.Items.Add(new AS1Q1());
            this.ChalengeList.Items.Add(new AS1Q2());
            this.ChalengeList.Items.Add(new BinarySearch());
            
            





            //CrackingTheCoreInterViewList
            this.CrackingTheCoreInterViewList.Items.Add(new IsUnique());
            this.CrackingTheCoreInterViewList.Items.Add(new CheckPermutation());
            this.CrackingTheCoreInterViewList.Items.Add(new URLify());
            this.CrackingTheCoreInterViewList.Items.Add(new PalindromePermutation());
            this.CrackingTheCoreInterViewList.Items.Add(new OneWay());
            this.CrackingTheCoreInterViewList.Items.Add(new StringCompression());
            this.CrackingTheCoreInterViewList.Items.Add(new RotateMatrix());
            this.CrackingTheCoreInterViewList.Items.Add(new ZeroMatrix());
            this.CrackingTheCoreInterViewList.Items.Add(new StringRotation ());
            //LinkedLists            
            this.CrackingTheCoreInterViewList.Items.Add(new RemoveDuplicates());
            this.CrackingTheCoreInterViewList.Items.Add(new KthToLast());
            this.CrackingTheCoreInterViewList.Items.Add(new DeleteMiddleNode());
            this.CrackingTheCoreInterViewList.Items.Add(new Partition());
            this.CrackingTheCoreInterViewList.Items.Add(new SumLists());
            this.CrackingTheCoreInterViewList.Items.Add(new LinkedListPalindrome());
            this.CrackingTheCoreInterViewList.Items.Add(new LinkedListIntersection());
            this.CrackingTheCoreInterViewList.Items.Add(new LoopDetection());
            //RecurisonAndDynamicProgramming            
            this.CrackingTheCoreInterViewList.Items.Add(new TripleStep());








        }

        private void BtnCommonnChid_Click(object sender, RoutedEventArgs e)
        {
            CommonChild.FindCommonChildSize(this.TxtCommonChil1.Text, this.TxtCommonChil2.Text);
        }

        private void BtnBeatifulTriplets_Click(object sender, RoutedEventArgs e)
        {

            int[] arr = ToIntArray(this.TxtBeatifulTripletsArray.Text);
            int dif = int.Parse(this.TxtBeatifulTripletsDif.Text);

            MessageBox.Show($"Result:{DictionariesAndHashmaps.FindBeautifulTriplets(dif, arr)}");
        }

        private static int[] ToIntArray(string s)
        {
            var stryArr = s.Split(' ');
            return Array.ConvertAll(stryArr, Convert.ToInt32);
        }
        private static long[] ToLongArray(string s)
        {
            var stryArr = s.Split(' ');
            return Array.ConvertAll(stryArr, Convert.ToInt64);
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

        private void BtnCheckSubString_Click(object sender, RoutedEventArgs e)
        {
            bool value = StringOperations.CheckCommonSubString(this.TxtStringOp1.Text, this.TxtStringOp2.Text);
            MessageBox.Show($"Result:{value}");
        }

        private void CountTriplets_Click(object sender, RoutedEventArgs e)
        {
            long[] arr = ToLongArray(this.TxtBeatifulTripletsArray.Text);
            int dif = int.Parse(this.TxtBeatifulTripletsDif.Text);

            MessageBox.Show($"Result:{DictionariesAndHashmaps.CountTriplets(arr.ToList(), dif)}");
        }

        private void BtnCheckSpecialStrings_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show($"Result:{StringOperations.CountSpecialStrings(this.TxtStringOp1.Text)}");
        }

    }

}



