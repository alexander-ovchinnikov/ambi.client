using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Gameplay
{
    public class LevelUI : MonoBehaviour
    {
        [SerializeField] private GameObject WinObject;
        [SerializeField] private GameObject LoseObject;
        [SerializeField] private Button BackButton;

        public void OnWin()
        {
            gameObject.SetActive(true);
            LoseObject.SetActive(false);
            WinObject.SetActive(true);
        }

        public void OnLose()
        {
            WinObject.SetActive(false);
            LoseObject.SetActive(true);
            gameObject.SetActive(true);
        }

        private void Start()
        {
            BackButton.onClick.AddListener(
                () => { SceneManager.LoadScene("Main"); }
            );
        }

        public void OnStart()
        {
            gameObject.SetActive(false);
        }
    }
}