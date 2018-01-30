public interface IPlayerControl
{
    bool CanHit();
    void Hit();
    IPlayerControl Init();
}