using System;

namespace Gameplay
{
    public class ScoreSontroller
    {
        public event Action<int, int> SetScore;
        public int UserWins { get; private set; }
        public int UserLoses { get; private set; }

        public void UpdateScore(int userWins, int userLoses)
        {
            UserWins = userWins;
            UserLoses = userLoses;
            SetScore(userWins, userLoses);
        }
    }
}