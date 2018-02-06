using Gameplay.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class StatisticPanel : MonoBehaviour
    {
        [Inject] private IGame Game;
        [SerializeField] private Text WinsText;
        [SerializeField] private Text LosesText;
    
        private void Start()
        {
            Game.ScoreSontroller.SetScore += SetScore;
            WinsText.text = Game.ScoreSontroller.UserWins.ToString();
            LosesText.text = Game.ScoreSontroller.UserLoses.ToString();
        }

        public void SetScore(int wins, int loses)
        {
            this.wins = wins;
            this.loses = loses;
        }


        private int wins
        {
            set { WinsText.text = value.ToString(); }
        }

        private int loses
        {
            set { LosesText.text = value.ToString(); }
        }
    }
}