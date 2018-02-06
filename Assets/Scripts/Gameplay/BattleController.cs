using System;
using UnityEngine;

namespace Gameplay
{
    public class BattleController
    {
        public event Action BattleStartEvent;
        public event Action OnPlayerHitStartEvent;

        private HumanCharacter _player;

        public HumanCharacter Player
        {
            set
            {
                if (_player != value && value != null)
                {
                    value.OnHitRequest += OnPlayerHitStart;
                }

                _player = value;
            }
            get { return _player; }
        }

        public Character Enemy { set; get; }

        private MonoBehaviour _level;

        private void OnPlayerHitStart()
        {
            if (OnPlayerHitStartEvent != null) OnPlayerHitStartEvent();
        }


        public void OnEnemyHitSuccess()
        {
            Enemy.Hit();
        }

        public void OnPlayerHitSuccess()
        {
            Player.Hit();
        }


        public void InitStats(int PlayerHealth, int EnemyHealth)
        {
            Player.InitStats(PlayerHealth);
            Enemy.InitStats(EnemyHealth);
        }

        public void SetStats(int PlayerHealth, int EnemyHealth)
        {
            Player.Health = PlayerHealth;
            Enemy.Health = EnemyHealth;
        }


        public MonoBehaviour Level
        {
            get { return _level; }
            set
            {
                if (_level != value)
                {
                    _level = value;
                }

                BattleStartEvent();
            }
        }

        public void OnWin()
        {
            DeactivateChars();
        }

        public void OnLose()
        {
            DeactivateChars();
        }

        private void DeactivateChars()
        {
            Player.gameObject.SetActive(false);
            Enemy.gameObject.SetActive(false);
        }
    }
}