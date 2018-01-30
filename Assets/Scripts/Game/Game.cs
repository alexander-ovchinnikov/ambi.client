using UnityEngine;

public class Game : MonoBehaviour, IGame
{
    public int i = 0;
    public ICharacter Character { set; get; }

    public int GetI()
    {
        return i;
    }
    public void SetI()
    {
        i = 10;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}