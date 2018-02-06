using Gameplay.Interfaces;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Level : MonoBehaviour
    {
        [Inject] private IGame Game;

        [SerializeField] private BotCharacter Enemy;
        [SerializeField] private Transform Holder1;
        [SerializeField] private Transform Holder2;

        private void Start()
        {
            Init();
            Game.BattleController.Level = this;
        }

        void Init()
        {
            Enemy = Enemy.Instantiate<BotCharacter>(Holder1, true);
            Game.BattleController.Enemy = Enemy;

            HumanCharacter
                Player = Instantiate(
                    Game.BattleController.Player as HumanCharacter); //.Instantiate<Character>(Holder2, true);
            Player.GameObject.transform.SetParent(Holder2, false);
            Player.GameObject.SetActive(true); //.parent = Holder2;

            Enemy.GameObject.transform.LookAt(
                Player.GameObject.transform
            );

            Player.GameObject.transform.LookAt(
                Enemy.GameObject.transform
            );
            Game.BattleController.Player = Player;
        }
    }
}