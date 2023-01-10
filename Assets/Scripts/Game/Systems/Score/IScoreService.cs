namespace KnifeThrower.Game
{
    public interface IScoreService
    {
        int LevelScore { get; set; }

        void IncrementScore(int score, int multiplier);
    }
}