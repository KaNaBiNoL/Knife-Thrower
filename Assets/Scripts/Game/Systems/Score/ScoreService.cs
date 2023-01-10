namespace KnifeThrower.Game
{
    public class ScoreService : IScoreService 
    {
        public int LevelScore { get; set; }

        private int _fixedScoreRaise = 1000;

        public void IncrementScore(int score, int multiplier)
        {
            LevelScore += score * multiplier;
        }
    }
}