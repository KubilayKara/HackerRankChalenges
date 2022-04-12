using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.LeetCode75.Dynamic_Programming
{
    public class LeetCoinChange : Chalange
    {

        public override void SetParameters()
        {
            this.url = "https://leetcode.com/problems/coin-change/";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "Coins", DefaultValue = "1,2,5" },
            new ChalengeParameter{Label="Amount", DefaultValue="11" } };
            base.SetParameters();
        }

        public override string Run(string[] parameters)
        {
            int[] coins = Utility.StringToIntagerList(parameters[0]).ToArray();
            int amount = int.Parse(parameters[1]);
            this._cache = new Dictionary<int, int>();
            return CoinChange(coins, amount).ToString();
        }

        Dictionary<int, int> _cache = new Dictionary<int, int>();
        int[] _coins;
        public int CoinChange(int[] coins, int amount)
        {
            this._coins = coins.OrderBy(x => -x).ToArray();
            return CoinChange(amount);
        }
        public int CoinChange(int amount)
        {
            if (amount == 0)
                return 0;
            if (this._cache.ContainsKey(amount))
                return _cache[amount];

            //System.Diagnostics.Trace.WriteLine($"CoinChange=> {amount}");
            int least = -1;
            if (_coins.Contains(amount))
                least = 0;
            else
                foreach (var coin in _coins)
                {
                    int rem = amount - coin;
                    if (rem < 0)
                        continue;
                    if (rem == 0)
                    {
                        least = 0;
                        break;
                    }
                    if (rem > 0)
                    {
                        int curr = CoinChange(rem);

                        if (curr > 0 && (least == -1 || curr < least))
                        {
                            least = curr;
                            if (curr == 1)
                                break;
                        }
                    }

                }
            if (least == -1)
            {
                _cache[amount] = least;
                //System.Diagnostics.Trace.WriteLine($"CoinChange cache[{amount}]={least}");
                return -1;
            }
            least++;
            _cache[amount] = least;
            //System.Diagnostics.Trace.WriteLine($"CoinChange cache[{amount}]={least}");

            return least;
        }
    }
}
