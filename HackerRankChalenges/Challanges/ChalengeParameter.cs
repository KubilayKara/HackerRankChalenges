namespace HackerRankChalenges.Challanges
{
    public class ChalengeParameter
    {
        public string Label { get; set; }
        public string DefaultValue { get; set; }


        public ChalengeParameter(string label, string defaultValue)
        {
            this.Label = label;
            this.DefaultValue = defaultValue;
        }


        public ChalengeParameter()
        {

        }

    }
}

