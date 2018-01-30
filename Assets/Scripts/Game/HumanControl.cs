using UnityEngine;

public class HumanControl : MonoBehaviour, IPlayerControl
{
    public bool CanHit()
    {
        throw new System.NotImplementedException();
    }

    public void Hit()
    {
        throw new System.NotImplementedException();
    }

    public IPlayerControl Init()
    {
        return new HumanControl();
    }
    
}