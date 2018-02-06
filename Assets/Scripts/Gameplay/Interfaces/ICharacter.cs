using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Interfaces
{
    public interface ICharacter
    {
        Image Icon { get; }
        GameObject GameObject { get; }
        //ICharacter Instantiate(Transform holder, bool active);
        //T Instantiate<T>(Transform holder, bool active) where T : class, ICharacter;
    }
}