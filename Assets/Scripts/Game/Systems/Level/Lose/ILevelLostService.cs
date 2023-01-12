namespace KnifeThrower.Game
{
    public interface ILevelLostService
    {
        public bool IsGameEnd { get;  set; }
        bool IsGameLost { get; set; }
    }
}