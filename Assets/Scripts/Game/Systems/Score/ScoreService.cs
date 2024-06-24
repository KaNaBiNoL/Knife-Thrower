using System;
using Zenject;

namespace KnifeThrower.Game
{
    public class ScoreService : IScoreService 
    {
        public int LevelScore { get; set; }

        private int _fixedScoreRaise = 100;
        private float _fixedMultiplierStep = 0;
        public int ScoreForShot { get; set; }
        
        public void Init()
        {
            ShurikenCollision.OnShurikenCollideWithTarget.AddListener(IncrementScore);
            ShurikenCollision.OnShurikenCollideNotWithTarget.AddListener(ScoreToDefault);
        }

        public void IncrementScore()
        {
            ScoreForShot = Convert.ToInt32(_fixedScoreRaise + _fixedScoreRaise * _fixedMultiplierStep);
            LevelScore += ScoreForShot;
            _fixedMultiplierStep += 0.2f;
        }

        public void ScoreToDefault()
        {
            _fixedMultiplierStep = 0;
        }
    }
}