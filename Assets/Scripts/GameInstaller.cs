using Gameplay;
using Gameplay.Interfaces;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller 
{
    [SerializeField] private Object GamePrefab;
    [SerializeField] private Object UI;
    [SerializeField] private Object ScorePanel;

    public override void InstallBindings()
    {
        Container.Bind<IGame>().To<Game>().FromComponentInNewPrefab(GamePrefab).AsSingle();
    }
}