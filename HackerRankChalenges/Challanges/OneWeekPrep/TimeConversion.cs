using System;
using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.OneWeekPrep
{
    public class TimeConversion : Chalange
    {
        public override void SetParameters()
        {
            this.url = "https://www.hackerrank.com/challenges/one-week-preparation-kit-time-conversion/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=preparation-kits&playlist_slugs%5B%5D=one-week-preparation-kit&playlist_slugs%5B%5D=one-week-day-one";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter() };
            this.ButtonText = typeof(TimeConversion).Name;
        }
        // Implementing the abstract method 'Run' from the base class 'Chalange'
        public override string Run(string[] parameters)
        {
            string time = "07:05:45PM";
            return timeConversion(time);
        }
        public static string timeConversion(string s)
        {
            TimeOnly time = TimeOnly.Parse(s);
            return time.ToString("HH:mm:ss");
        }
    }
}
