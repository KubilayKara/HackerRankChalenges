using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges
{
    public class Utility
    {
     
        public static List<int> StringToIntagerList(string s, char seperator=',')
        {
            string[] testPrm = s.Split(seperator);
            List<int> a = new List<int>();
            foreach (var item in testPrm)
            {
                int i;
                if (int.TryParse(item.Trim(), out i))
                    a.Add(i);
            }
            return a;
        }

    }
}
