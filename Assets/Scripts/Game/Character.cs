using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


[RequireComponent(typeof(Image))]
public class Character : MonoBehaviour, ICharacter
{
    public enum CharTypes
    {
        Human,
        Bot
    }

    [SerializeField] private CharTypes CharType = CharTypes.Human;
    private IPlayerControl Control { get; set; }

    private void Awake()
    {
        Icon = GetComponent<Image>();
    }

    public Image Icon { get; private set; }

    public GameObject GameObject
    {
        get { return gameObject; }
    }

    public void Init()
    {
        switch (CharType)
        {
            case CharTypes.Human:
                break;
            case CharTypes.Bot:
                break;
        }
    }
}