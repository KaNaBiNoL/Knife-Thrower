using System;
using Zenject;
using UnityEngine;

namespace KnifeThrower.Game
{
    public class ScoreService : MonoBehaviour, IScoreService
    {
        public int LevelScore { get; set; }

        private int _fixedScoreRaise = 100;
        private float _fixedMultiplierStep = 0;
        public int ScoreForShot { get; set; }

        public void Start()
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

        private void OnDisable()
        {
            ShurikenCollision.OnShurikenCollideWithTarget.RemoveListener(IncrementScore);
            ShurikenCollision.OnShurikenCollideNotWithTarget.RemoveListener(ScoreToDefault);
        }
    }
}