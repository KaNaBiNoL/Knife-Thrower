namespace KnifeThrower.Game
{
    public interface IScoreService
    {
        int LevelScore { get; set; }
        int ScoreForShot { get; set; }
        
        

        void IncrementScore();

        public void ScoreToDefault();
    }
}