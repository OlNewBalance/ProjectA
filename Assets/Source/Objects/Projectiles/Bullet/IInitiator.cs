namespace Source.Objects.Projectiles.Bullet
{
    public interface IInitiator
    {
        InitiatorType GetInitiatorType();
    }

    public enum InitiatorType
    {
        Player = 1,
        EnemyCorvette = 2
    }
}