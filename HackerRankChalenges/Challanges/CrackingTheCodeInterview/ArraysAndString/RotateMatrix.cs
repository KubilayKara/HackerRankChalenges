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
            this.ChalangeParameters = new List<ChalengeParameter> { };
            base.SetParameters();

        }
        public override string Run(string[] parameters)
        {
            string[,] matrix = new string[,] {
            {"a","b" },
            {"c","d" },
            {"e","f" }
            };


            var result = RotateMatrix_solution(matrix);

            return Utility.MatrixToString(result);

        }

        private T[,] RotateMatrix_solution<T>(T[,] matrix)
        {
            //rotate right or left?

            int columnCount = matrix.GetLength(1);
            int rowCount = matrix.GetLength(0);
            T[,] result = new T[columnCount, rowCount];
            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    result[columnCount - columnIndex - 1, rowIndex] = matrix[rowIndex, columnIndex];
                }
            }
            return result;
        }
    }
}

