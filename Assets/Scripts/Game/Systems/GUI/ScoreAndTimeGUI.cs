using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace KnifeThrower.Game
{
    public class ScoreAndTimeGUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _remainingShurikensText;
        [SerializeField] private int _startShurikensText;
        private IScoreService _scoreService;
        private ILevelTimer _levelTimer;
        private IRemainingShurikens _remainingShurikens;

        [Inject]
        public void Construct(IScoreService scoreService, ILevelTimer levelTimer, IRemainingShurikens remainingShurikens )
        {
            _scoreService = scoreService;
            _levelTimer = levelTimer;
            _remainingShurikens = remainingShurikens;
        }

        private void Start()
        {
            _remainingShurikensText.text = $" = {_startShurikensText} ";
            ShurikenSpawn.OnShurikenThrowed.AddListener(SwitchShurikenCountText);
        }

        private void SwitchShurikenCountText()
        {
            _remainingShurikensText.text = $" = {_remainingShurikens.ShurikenCount - 1} ";
        }

        private void Update()
        {
            _scoreText.text = $" {_scoreService.LevelScore}";
            _timerText.text = "0:" + Mathf.Round(_levelTimer.Timer);
        }
    }
}