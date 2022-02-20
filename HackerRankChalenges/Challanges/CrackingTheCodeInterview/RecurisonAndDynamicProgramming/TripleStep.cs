using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.RecurisonAndDynamicProgramming
{
    internal class TripleStep : Chalange
    {
        /*Triple Step: A child is running up a staircase with n steps and can hop either 1 step, 2 steps, or 3
            steps at a time. Implement a method to count how many possible ways the child can run up the
            stairs.
            Hints: #152, #178, #217, #237, #262, #359
        */
        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter>() { new ChalengeParameter("StepCount", "3") };
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            if (int.TryParse(parameters[0], out int stepCount))
            {
                return Sollution(stepCount).ToString();
            }
            return "ERROR";
        }

        private int Sollution(int stepCount)
        {
            if (stepCount <= 0)
                return 0;

            Dictionary<int, int> cache = new Dictionary<int, int>();

            for (int i = stepCount - 1; i >= 0; i--)
            {
                int total = 0;
                total += GetValueFor(stepCount, i + 1, cache); ;
                total += GetValueFor(stepCount, i + 2, cache); ;
                total += GetValueFor(stepCount, i + 3, cache); ;
                cache[i] = total;
            }

            return cache[0];
        }

        private static int GetValueFor(int stepCount, int currentStep, Dictionary<int, int> cache)
        {
            if (currentStep == stepCount)
                return 1;
            else if (currentStep < stepCount)
                return cache[currentStep];

            return 0;
        }
    }
}
