using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    [Inject] private IGame Game;
    [SerializeField]
    private BotCharacter Enemy;
    private Character Player;
    [SerializeField]
    private Transform Holder1;
    [SerializeField]
    private Transform Holder2;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        Enemy = Instantiate(Enemy, Holder1);
        Player= Instantiate(Game.Character as HumanCharacter, Holder2);
    }
}