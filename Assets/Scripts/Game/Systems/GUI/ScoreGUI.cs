using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace KnifeThrower.Game
{
    public class ScoreGUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        private IScoreService _scoreService;

        [Inject]
        public void Construct(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }
        private void Update()
        {
            _scoreText.text = $"Score: {_scoreService.LevelScore}";
        }
    }
}