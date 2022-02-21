using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.Certificates
{
    class ProblemSolving_Intermediate : Chalange
    {
        public override void SetParameters()
        {
            //https://www.hackerrank.com/test/6ln9g5g0r6f/questions/4elchsd8en3
            this.url = "https://www.hackerrank.com/test/6ln9g5g0r6f/questions/d8k87ha4or";
            this.ChalangeParameters = new List<ChalengeParameter>();
            this.ButtonText = typeof(ProblemSolving_Intermediate).Name;
        }
        public override string Run(string[] parameters)
        {
            /*
             * 4
                3
                2
                1
                1
                2
                1
                3*/
            var result = getMaxArea(4, 3, new List<bool> { true, true }, new List<int> { 3, 1 });
            return result.ToString();
        }

        //public static List<long> getMaxArea(int width, int height, List<bool> isVerticalList, List<int> distanceList)
        //{
        //    List<long> result = new List<long>();
        //    int w1 = 0;
        //    int w2 = width;
        //    int h1 = 0;
        //    int h2 = height;
        //    int maxwidh = width;
        //    int maxheignt = height;

        //    for (int i = 0; i < isVerticalList.Count; i++)
        //    {
        //        bool isVertical = isVerticalList[i];
        //        int distance = distanceList[i];

        //        if (isVertical)
        //        {
        //            if (distance < w2 && distance > w1)
        //            {
        //                int d1 = distance - w1;
        //                int d2 = w2- distance;
        //                if (d1 > d2)
        //                    maxDis = d1;

        //                if (d2 > maxDis)
        //                    maxDis = d2;
        //            }
        //        }
        //    }

        //}

        public static int numberOfWays(List<List<int>> roads)
        {
            return 0;
        }
        public static List<long> getMaxArea(int width, int height, List<bool> isVerticalList, List<int> distanceList)
        {
            List<long> result = new List<long>();
            Point horizontalPoints = new Point(0, new Point(width, null));
            Point verticalPoints = new Point(0, new Point(height, null));
            int maxwidh = width;
            int maxheignt = height;

            for (int i = 0; i < isVerticalList.Count; i++)
            {
                bool isVertical = isVerticalList[i];
                int distance = distanceList[i];
                if (isVertical)
                {
                    maxwidh = AddToList(horizontalPoints, distance);
                    //maxwidh = GetMaxDif(horizontalPoints);


                }
                else
                {

                    maxheignt = AddToList(verticalPoints, distance);
                    //maxheignt = GetMaxDif(verticalPoints);
                }
                result.Add(Convert.ToInt64(maxwidh) * Convert.ToInt64(maxheignt));

            }


            return result;

        }

        private static int GetMaxDif(Point startPoint)
        {
            var currentPoint = startPoint;

            int maxDis = 0;
            while (currentPoint.NextPoint != null)
            {
                int curDis = currentPoint.NextPoint.Value - currentPoint.Value;
                if (curDis > maxDis)
                {
                    maxDis = curDis;
                }
                currentPoint = currentPoint.NextPoint;
            }
            return maxDis;
        }
        private static int AddToList(Point startPoint, int distance)
        {
            var currentPoint = startPoint;
            bool inserted = false;
            int maxDis = 0;
            while (currentPoint.NextPoint != null)
            {
                if (!inserted && currentPoint.NextPoint.Value != distance && currentPoint.NextPoint.Value > distance)
                {
                    //insert between
                    int d1 = distance - currentPoint.Value;
                    int d2 = currentPoint.NextPoint.Value - distance;
                    var newpoint = new Point(distance, currentPoint.NextPoint);
                    currentPoint.NextPoint = newpoint;
                    if (d1 > maxDis)
                        maxDis = d1;

                    if (d2 > maxDis)
                        maxDis = d2;

                    currentPoint = newpoint.NextPoint;
                    inserted = true;

                }
                else
                {

                    int curDis = currentPoint.NextPoint.Value - currentPoint.Value;
                    if (curDis > maxDis)
                        maxDis = curDis;
                    currentPoint = currentPoint.NextPoint;

                }

            }
            return maxDis;
        }
    }

    class Point
    {
        public int Value { get; set; }
        public Point NextPoint { get; set; }

        public Point(int value, Point nextPoint)
        {
            Value = value;
            NextPoint = nextPoint;
        }


    }
}
