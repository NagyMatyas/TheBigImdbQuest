namespace TheBigImdbQuest
{
    public static class OscarCalculator
    {
        public static double GetOscarRewards(int nrOfOscars)
        {
            double reward;

            if(nrOfOscars == 0)
            {
                reward = 0;
            }
            else if(nrOfOscars <= 2)
            {
                reward = 0.3;
            }
            else if (nrOfOscars <= 5)
            {
                reward = 0.5;
            }
            else if (nrOfOscars <= 10)
            {
                reward = 1.0;
            }
            else
            {
                reward = 1.5;
            }

            return reward;
        }
    }
}
