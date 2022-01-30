using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.ArraysAndString
{
    internal class RotateMatrix : Chalange
    {
        /*
            Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4
            bytes, write a method to rotate the image by 90 degrees. Can you do this in place
          */

        public override void SetParameters()
        {
            this.url = "";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "String 1", DefaultValue = "aabcccccaaa" } };
            base.SetParameters();

        }
        public override string Run(string[] parameters)
        {
            char[,] matrix = new char[,] {
            {'a','b' },
            {'c','d' },
            {'e','f' }

            };


            var result = RotateMatrix_solution(matrix);

            return result.ToString();

        }

        private char[,] RotateMatrix_solution(char[,] matrix)
        {
            //rotate right or left?

            int columnCount = matrix.GetLength(1);
            int rowCount = matrix.GetLength(0);
            char[,] result = new char[columnCount, rowCount];
            for (int ColumnIndex = 0; ColumnIndex < columnCount; ColumnIndex++)
            {
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    result[columnCount - ColumnIndex - 1, rowIndex] = matrix[rowIndex, ColumnIndex];
                }
            }
            return result;
        }




    }
}
