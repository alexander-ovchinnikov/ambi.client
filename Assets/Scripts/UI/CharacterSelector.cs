using Gameplay;
using Gameplay.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
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

        private void SelectCharacter(HumanCharacter character)
        {
            DontDestroyOnLoad(character.GameObject);
            Game.BattleController.Player = character;
        }


        private void CreateCharButton(ICharacter character)
        {
            Button button = Instantiate(buttonTemplate, _charHolder);
            button.onClick.AddListener(
                () => { SelectCharacter(character as HumanCharacter); }
            );
            button.image = character.Icon;
            button.GetComponent<Image>().sprite = character.Icon.sprite;
            button.gameObject.SetActive(true);
        }

        private void InitIterface()
        {
            foreach (var character in _characters)
            {
                CreateCharButton(character);
            }
        }
    }
}