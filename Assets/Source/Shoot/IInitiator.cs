namespace Source.Shoot
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