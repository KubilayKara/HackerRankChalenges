using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.ArraysAndString
{
    internal class ZeroMatrix : Chalange
    {
        /*  Zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0, its entire row and
            column are set to 0.
          */

        public override void SetParameters()
        {
            this.url = "";
            this.ChalangeParameters = new List<ChalengeParameter> { };
            base.SetParameters();

        }
        public override string Run(string[] parameters)
        {
            int[,] matrix = new int[,] {
                    {0,0,3,4 },
                    {1,2,3,0 },
                    {1,2,0,4 },
                    {1,2,3,4 },
                    {1,2,3,4 }
            };
            var result = ZeroMatrix_solution(matrix);
            return "\n" + Utility.MatrixToString(result);
        }

        private int[,] ZeroMatrix_solution(int[,] matrix)
        {
            //are elements int?

            int columnCount = matrix.GetLength(1);
            int rowCount = matrix.GetLength(0);
            //what if every columns or every rows are signed as zero?



            GetZeroColumnsAndRows(matrix, out bool[] zeroColumns, out bool[] zeroRows);

            int[,] result = new int[rowCount, columnCount];

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    result[rowIndex, columnIndex] = (zeroColumns[columnIndex] || zeroRows[rowIndex] ? 0 : matrix[rowIndex, columnIndex]);

                }
            }
            return result;
        }

        private static void GetZeroColumnsAndRows(int[,] matrix, out bool[] zeroColumns, out bool[] zeroRows)
        {
            int columnCount = matrix.GetLength(1);
            int rowCount = matrix.GetLength(0);

            zeroColumns = new bool[columnCount];
            zeroRows = new bool[rowCount];
            int zeroRowCount = 0; int zeroColumntCount = 0;

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    if (matrix[rowIndex, columnIndex] == 0)
                    {
                        if (!zeroColumns[columnIndex])
                        {
                            zeroColumns[columnIndex] = true;
                            zeroColumntCount++;
                        }
                        if (!zeroRows[rowIndex])
                        {
                            zeroRowCount++;
                            zeroRows[rowIndex] = true;
                        }
                        if (zeroColumntCount == columnCount || zeroRowCount == rowCount)
                            return;
                    }
                }
            }
        }
    }

}

