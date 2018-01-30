using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneSelector : MonoBehaviour
{
    [Inject] private IGame Game;
    [SerializeField] private String[] Scenes;
    [SerializeField] private Transform _buttonsHolder;
    [SerializeField] private LevelButton _buttonTemplate;

    private void Start()
    {
        Init();
    }

    void CreateSceneButton(string sceneName)
    {
        LevelButton button = Instantiate(_buttonTemplate, _buttonsHolder);

        button.Button.onClick.AddListener(
            () => { LoadLevel(sceneName); }
        );
        button.Text.text = sceneName.Split('/').Last();
        button.gameObject.SetActive(true);
    }

    void LoadLevel(string sceneName)
    {
        if (Game.Character != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    void Init()
    {
        foreach (string scene in Scenes)
        {
            CreateSceneButton(scene);
        }
    }
}