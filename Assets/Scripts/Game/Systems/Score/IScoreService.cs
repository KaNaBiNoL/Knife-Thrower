namespace KnifeThrower.Game
{
    public interface IScoreService
    {
        int LevelScore { get; set; }
        int ScoreForShot { get; set; }
        
        public void Init()
        {
            
        }

        void IncrementScore();

        public void ScoreToDefault();
    }
}