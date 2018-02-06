namespace Gameplay.Interfaces
{
    public interface IGame
    {
        BattleController BattleController { get; }
        ScoreSontroller ScoreSontroller { get; }
    }
}