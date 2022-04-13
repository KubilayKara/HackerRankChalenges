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
            //this._cache = new Dictionary<int, int>();
            return CoinChange(coins, amount).ToString();
        }

        int?[] _cache;
        int[] _coins;
        public int CoinChange(int[] coins, int amount)
        {
             _cache = new int?[amount+1];
            this._coins = coins;
            return CoinChange(amount);
        }
        public int CoinChange(int amount)
        {
            if (amount == 0)
                return 0;
            if (this._cache[amount]!=null)
                return _cache[amount].Value;

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

        public int CoinChange_Disc(int[] coins, int amount)
        {
            // lets get the easy solution out the way first. $0 amounts dont need any coins.
            if (amount <= 0)
                return 0;

            // Create a DP array for the full amount of $$ (between $1 and <amount>, inclusive)
            // this DP array represents the amount of coins needed for each dollar amount between $1 and <amount>
            // so, if you need 2 coins to make $10, dp[10] = 2
            int[] dp = new int[amount + 1];
            // prefill the array with -1, which is the value returned when a solution cannot be found
            for (int i = 0; i < dp.Length; i++)
                dp[i] = -1;

            // now, iterate from $1 to <amount>, inclusive (in other words, iterate over the dp array)
            for (int i = 1; i <= amount; i++)
            {
                // for each dollar amount evaluated, iterate over our available coins
                foreach (int coin in coins)
                    
                    if (coin == i)
                        dp[i] = 1;   
                    else if (coin < i)
                        if (dp[i - coin] != -1 && ((dp[i] != -1 && dp[i] > dp[i - coin] + 1) // (check existing solution, realize we can do better)
                               || dp[i] == -1))                        // (no existing solution)

                            dp[i] = dp[i - coin] + 1;  // take the amount of coins needed to make $8, and add 1 more coin (because of our $2 coin)

            }

            // Now then, because of the way our solution is setup, the final answer will be in dp[amount]
            // (it could also be -1 for no solution - we prefilled the array, remember?)
            return dp[amount];
        }
    }
}
