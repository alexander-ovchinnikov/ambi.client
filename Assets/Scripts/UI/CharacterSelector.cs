using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;


public class CharacterSelector : MonoBehaviour
{
    [Inject] private IGame Game;
    [SerializeField] private Character[] _characters;
    [SerializeField] private Transform _charHolder;
    [SerializeField] private Button buttonTemplate;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        InitIterface();
    }

    private void SelectCharacter(ICharacter character)
    {
        DontDestroyOnLoad(character.GameObject);
        Game.Character = character;
    }


    private void CreateCharButton(ICharacter character)
    {
        Button button = Instantiate(buttonTemplate, _charHolder);
        button.onClick.AddListener(
            () => { SelectCharacter(character); }
        );
        button.image = character.Icon;
        button.GetComponent<Image>().sprite = character.Icon.sprite;
        button.gameObject.SetActive(true);
    }

    private void InitIterface()
    {
        foreach (ICharacter character in _characters)
        {
            CreateCharButton(character);
        }
    }
}