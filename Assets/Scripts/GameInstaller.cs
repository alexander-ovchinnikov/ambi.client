using Zenject;

public class GameInstaller : MonoInstaller<GameInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IGame>().To<Game>().FromNewComponentOnNewGameObject().WithGameObjectName("GameController").AsSingle();
    }
}