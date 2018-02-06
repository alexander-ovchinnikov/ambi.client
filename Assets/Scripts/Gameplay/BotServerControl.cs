using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay
{
    public class BotServerControl : MonoBehaviour, IPlayerControl
    {
        public bool CanHit()
        {
            return true;
        }

        public void Hit()
        {
            return;
        }

        public IPlayerControl Init()
        {
            return new BotServerControl();
        }
    }
}