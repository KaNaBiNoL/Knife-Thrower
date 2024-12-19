using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using YG;
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
            ShurikenSpawn.OnShurikenThrowed.AddListener(SetScoreText);
        }

        private void SwitchShurikenCountText()
        {
            _remainingShurikensText.text = $" = {_remainingShurikens.ShurikenCount - 1} ";
        }

        private void Update()
        {
            _timerText.text = "0:" + Mathf.Round(_levelTimer.Timer);
        }

        private void SetScoreText()
        {
            StartCoroutine(ScoreTextChange());
        }

        IEnumerator ScoreTextChange()
        {
            for (int i = 4; i >= 0; i--)
            {
                switch (YandexGame.EnvironmentData.language)
                {
                    case "ru":
                        _scoreText.text = $"Счет: {_scoreService.LevelScore}";
                        break;
                    case "en":
                        _scoreText.text = $"Score: {_scoreService.LevelScore}";
                        break;
                    case "tr":
                        _scoreText.text = $"Gol: {_scoreService.LevelScore}";
                        break;
                    case "es":
                        _scoreText.text = $"Puntaje: {_scoreService.LevelScore}";
                        break;
                    case "de":
                        _scoreText.text = $"Punktzahl: {_scoreService.LevelScore}";
                        break;
                }

                if (i == 0)
                {
                    StopCoroutine(ScoreTextChange());
                }

                yield return new WaitForSeconds(0.5f);
            }
            

        }

        private void OnDisable()
        {
            ShurikenSpawn.OnShurikenThrowed.RemoveListener(SwitchShurikenCountText);
            ShurikenSpawn.OnShurikenThrowed.RemoveListener(SetScoreText);
        }
    }
}