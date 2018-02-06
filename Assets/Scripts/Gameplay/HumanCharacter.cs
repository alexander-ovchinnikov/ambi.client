using System;
using Gameplay;
using Gameplay.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

[RequireComponent(typeof(HumanControl))]
public class HumanCharacter : Character, IPointerClickHandler
{
    [Inject] private IGame Game;
    public event Action OnHitRequest;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnHitRequest != null) OnHitRequest();
    }
}