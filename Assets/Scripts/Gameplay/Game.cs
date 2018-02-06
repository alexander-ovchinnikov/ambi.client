using Gameplay.Interfaces;
using Networking;
using UnityEngine;

namespace Gameplay
{
    public class Game : MonoBehaviour, IGame
    {
        [SerializeField] private PhotonServer _server;
        [SerializeField] private LevelUI LevelUI;

        public BattleController BattleController { get; private set; }
        public ScoreSontroller ScoreSontroller { get; private set; }


        void Start()
        {
            BattleController = new BattleController();
            ScoreSontroller = new ScoreSontroller();

            BattleController.BattleStartEvent += _server.SendStatsInitRequest;
            BattleController.BattleStartEvent += LevelUI.OnStart;
            BattleController.OnPlayerHitStartEvent += _server.SendHitRequest;


            _server.InitStats += BattleController.InitStats;
            _server.UpdateStats += BattleController.SetStats;
            _server.PlayerHit += BattleController.OnPlayerHitSuccess;
            _server.EnemyHit += BattleController.OnEnemyHitSuccess;

            _server.Win += LevelUI.OnWin;
            _server.Lose += LevelUI.OnLose;
            _server.Win += BattleController.OnWin;
            _server.Lose += BattleController.OnLose;

            _server.UpdateScore += ScoreSontroller.UpdateScore;
            _server.Init();
        }
    }
}