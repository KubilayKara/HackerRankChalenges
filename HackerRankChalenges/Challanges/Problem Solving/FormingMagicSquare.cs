using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.Problem_Solving
{
    class FormingMagicSquare : Chalange
    {
        public override void SetParameters()
        {
            this.url = "https://www.hackerrank.com/challenges/magic-square-forming/problem?isFullScreen=true";
            this.ChalangeParameters = new List<ChalengeParameter>();// { new ChalengeParameter { Label = "N", DefaultValue = "5" } };

            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            List<List<int>> s = new List<List<int>>
            {
                new List<int> {4, 9, 2 },
                new List<int> {3, 5 ,7},
                new List<int> {8, 1, 5}
            };

            var result = formingMagicSquare(s);
            return result.ToString();
        }

        public static int formingMagicSquare(List<List<int>> s)
        {
            List<List<List<int>>> magicSquareList = GetMagicSquareList();
            int[] distanceList = new int[magicSquareList.Count()];
            for (int squareIndex = 0; squareIndex < magicSquareList.Count(); squareIndex++)
            {
                for (int rowIndex = 0; rowIndex < 3; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
                    {
                        int distance = magicSquareList[squareIndex][columnIndex][rowIndex] - s[columnIndex][rowIndex];
                        if (distance < 0)
                            distance = (-1) * distance;
                        distanceList[squareIndex] += distance;
                    }
                }
            }
            int? minDistance = null;
            foreach (var item in distanceList)
            {
                if (minDistance == null || minDistance.Value > item)
                    minDistance = item;
            }
            return minDistance.Value;
        }

        private static List<List<List<int>>> GetMagicSquareList()
        {
            List<List<List<int>>> magicSquareList = new List<List<List<int>>>()
            { new List<List<int>>
            {
                 new List<int> { 2  , 7,   6 },
                 new List<int> { 9  , 5,   1 },
                 new List<int>{ 4  , 3,   8 }
             },
            new List<List<int>>
            {
                 new List<int> {  2 ,  9,   4 },
                 new List<int> {   7   ,5 ,  3 },
                 new List<int> { 6,   1  , 8 }
            },
            new List<List<int>>
            {
                new List<int> {4 ,  3,   8},
                new List<int> {9,   5 ,  1},
                new List<int> {2 ,  7 ,  6}
            },
            new List<List<int>>
            {
                new List<int> {4,   9  , 2},
                new List<int> { 3 ,  5  , 7},
                new List<int> {8  , 1 ,  6}
            },
            new List<List<int>>
            {
                new List<int> {6 ,  1,   8},
                new List<int> {7 ,  5  , 3},
                new List<int> {2 ,  9,   4}
            },
            new List<List<int>>
            {
                new List<int> {6 ,  7   ,2},
                new List<int> {1  , 5 ,  9},
                new List<int> {8  , 3 ,  4}
            },
            new List<List<int>>
            {
                new List<int> {8,   1 ,  6},
                new List<int> { 3,   5 ,  7},
                new List<int> {4 ,  9 ,  2}
            },
            new List<List<int>>
            {
                new List<int> {8,   3,   4},
                new List<int> {1,   5,   9},
                new List<int> { 6,   7 ,  2}
            } };
            return magicSquareList;
        }

        public static List<int[,]> ListMagicSquares(int n)
        {
            List<int[,]> result = new List<int[,]>();

            Square s = new Square(n);
            Iterate(s, 0, 0, result);


            return result;

        }
        public static void Iterate(Square s, int curentRow, int currentCloumn, List<int[,]> validSquares)
        {

            for (int index = 0; index < s.NumberUsage.Length; index++)
            {
                bool avaliable = !s.NumberUsage[index];
                if (avaliable)
                {
                    s.NumberUsage[index] = true;
                    s.Numbers[curentRow, currentCloumn] = index + 1;

                    if (s.IsValid())
                    {
                        int nextColumn = (currentCloumn + 1 < s.Length) ? currentCloumn + 1 : 0;
                        int nextRow = (currentCloumn + 1 < s.Length) ? curentRow : curentRow + 1; //nextRow
                        if (nextRow < s.Length)
                            Iterate(s, nextRow, nextColumn, validSquares);
                        else if (s.IsValid())//filled all and valid
                        {
                            validSquares.Add(CloneArray(s.Numbers));
                            Trace.WriteLine("----------------------");
                            Trace.WriteLine(s);
                        }
                    }
                    //clean values for next cycle
                    s.Numbers[curentRow, currentCloumn] = 0;
                    s.NumberUsage[index] = false;
                }
            }
        }

        public static int[,] CloneArray(int[,] source)
        {
            int[,] result = new int[source.GetLength(0), source.GetLength(1)];
            if (CopyArray(source, result))
                return result;
            throw new Exception("olmadi");
        }
        public static bool CopyArray(int[,] source, int[,] target)
        {
            if (source.GetLength(0) != target.GetLength(0) || source.GetLength(1) != target.GetLength(1))
                return false;
            for (int i = 0; i < source.GetLength(0); i++)
            {
                for (int j = 0; j < source.GetLength(1); j++)
                {

                    target[i, j] = source[i, j];
                }
            }
            return true;
        }
    }

    public class Square
    {
        public int Length { get; set; }
        public int[,] Numbers { get; set; }
        public bool[] NumberUsage;
        public int MagicNumber;

        public Square(int length)
        {
            this.Length = length;
            Numbers = new int[length, length];
            int MaxNumber = length * length;
            NumberUsage = new bool[MaxNumber];
            MagicNumber = ((MaxNumber + 1) * MaxNumber) / (2 * length);
        }

        public bool IsValid()
        {

            //check diagonals
            bool isAnyBotomLeftEmpty = false;
            int botomLeftSum = 0;

            bool isAnyBotomRightEmpty = false;
            int botomRightSum = 0;

            //check rows and columns
            for (int i = 0; i < this.Length; i++)
            {
                int rowSum = 0;
                bool isAnyEmptyCellInRow = false;

                int columnSum = 0;
                bool isAnyEmptyCellInColumn = false;

                for (int j = 0; j < this.Length; j++)
                {
                    //row
                    if (this.Numbers[i, j] > 0)
                    {
                        rowSum += Numbers[i, j];
                    }
                    else
                        isAnyEmptyCellInRow = true;

                    //column
                    if (this.Numbers[j, i] > 0)
                        columnSum += Numbers[j, i];
                    else
                        isAnyEmptyCellInColumn = true;

                    if (rowSum > MagicNumber || columnSum > MagicNumber)
                        return false;
                }

                if ((rowSum < MagicNumber && !isAnyEmptyCellInRow) || (columnSum < MagicNumber && !isAnyEmptyCellInColumn))
                    return false;



                //BotomRight
                if (this.Numbers[i, i] == 0)
                    isAnyBotomRightEmpty = true;
                else
                    botomRightSum += this.Numbers[i, i];

                //BotomLeft
                if (this.Numbers[i, this.Length - i - 1] == 0)
                    isAnyBotomLeftEmpty = true;
                else
                    botomLeftSum += this.Numbers[i, this.Length - i - 1];


                if (botomLeftSum > this.MagicNumber || botomRightSum > MagicNumber)
                    return false;
            }
            if ((botomLeftSum < MagicNumber && !isAnyBotomLeftEmpty) || (botomRightSum < MagicNumber && !isAnyBotomRightEmpty))
                return false;

            return true;
        }

        public override string ToString()
        {
            string result = string.Empty;
            for (int i = 0; i < this.Length; i++)
            {
                for (int j = 0; j < this.Length; j++)
                {
                    string n = (this.Numbers[i, j] > 0) ? this.Numbers[i, j].ToString() : "_";
                    result += $"{n}\t";
                }
                result += "\n";
            }
            return result;
        }
    }
}
