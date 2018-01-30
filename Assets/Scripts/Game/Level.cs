using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class Level : MonoBehaviour
{
    [Inject] private IGame Game;
    public BotCharacter Enemy;
    public Character Player;
    public Transform Holder1;
    public Transform Holder2;

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