using System;
using KnifeThrower.Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;
using Zenject;

namespace KnifeThrower.Game
{
    public class WinScreen : MonoBehaviour
    {
        public int FullLevelScore { get; set; }

        [SerializeField] private GameObject _innerObject;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Button _retryButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _adsButton;
        [SerializeField] private TextMeshProUGUI _scoreForShotsText;
        [SerializeField] private TextMeshProUGUI _scoreForRemainingShurikensText;
        [SerializeField] private TextMeshProUGUI _scoreForTimeText;
        [SerializeField] private TextMeshProUGUI _levelScoreText;
        [SerializeField] private TextMeshProUGUI _levelGoldText;

        private IRemainingTargetsService _remainingTargetsService;
        private ISceneLoadingService _sceneLoadingService;
        private IScoreService _scoreService;
        private IRemainingShurikens _remainingShurikens;
        private ILevelTimer _levelTimer;
        private IGoldForLevel _goldForLevel;
        private IGUIControl _guiControl;

        [Inject]
        public void Construct(IRemainingTargetsService remainingTargetsService,
            ISceneLoadingService sceneLoadingService,
            IScoreService scoreService, IRemainingShurikens remainingShurikens, ILevelTimer levelTimer,
            IGoldForLevel goldForLevel, IGUIControl guiControl)
        {
            _sceneLoadingService = sceneLoadingService;
            _remainingTargetsService = remainingTargetsService;
            _scoreService = scoreService;
            _remainingShurikens = remainingShurikens;
            _levelTimer = levelTimer;
            _goldForLevel = goldForLevel;
            _guiControl = guiControl;
        }

        private void OnEnable()
        {
            _remainingTargetsService.OnWin += ShowWinScreen;
            _nextLevelButton.onClick.AddListener(ToNextLevel);
            _retryButton.onClick.AddListener(ReloadLevel);
            _exitButton.onClick.AddListener(GoToMenu);
        }

        private void Awake()
        {
            _innerObject.SetActive(false);
        }

        

        private void OnDestroy()
        {
            _remainingTargetsService.OnWin -= ShowWinScreen;
        }

        private void ShowWinScreen(bool isGameWon)
        {
            UnlockNewLevel();
            _innerObject.SetActive(isGameWon);
            _guiControl.IsGameOn = false;
            _guiControl.IsGameWinOrLost = true;

            if (isGameWon)
            {
                _scoreForShotsText.text = $"Очки за сбитые мишени - {_scoreService.LevelScore}";
                _scoreForRemainingShurikensText.text = $"Бонус за оставшиеся сюрикены - " +
                    $"{(_remainingShurikens.ShurikenCount - 1) * 100}";
                _scoreForTimeText.text = $"Бонус за время - {Convert.ToInt32(_levelTimer.Timer) * 10}";
                FullLevelScore = _scoreService.LevelScore + ((_remainingShurikens.ShurikenCount - 1) * 100) +
                    (Convert.ToInt32(_levelTimer.Timer) * 10);
                _levelScoreText.text = $"{FullLevelScore}";
                _levelGoldText.text = $"{_goldForLevel.GoldReward + 30}";
                SaveScore();
            }
        }

        private void SaveScore()
        {
            int sceneNumber = (SceneManager.GetActiveScene().buildIndex - 1);
            if (FullLevelScore > YandexGame.savesData.LevelScores[sceneNumber])
            {
                YandexGame.savesData.LevelScores[sceneNumber] = FullLevelScore;
                YandexGame.SaveProgress();
            }
        }

        private void UnlockNewLevel()
        {
            if (SceneManager.GetActiveScene().buildIndex >= YandexGame.savesData.UnlockedLevels)
            {
                YandexGame.savesData.UnlockedLevels = SceneManager.GetActiveScene().buildIndex;
                YandexGame.SaveProgress();
            }
        }

        private void ToNextLevel()
        {
            _sceneLoadingService.Load(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void ReloadLevel()
        {
            _sceneLoadingService.Load(SceneManager.GetActiveScene().buildIndex);
        }
        
        private void GoToMenu()
        {
            _sceneLoadingService.Load(1);
        }

        private void OnDisable()
        {
            _remainingTargetsService.OnWin -= ShowWinScreen;
            _nextLevelButton.onClick.RemoveListener(ToNextLevel);
            _retryButton.onClick.RemoveListener(ReloadLevel);
            _exitButton.onClick.RemoveListener(GoToMenu);
        }

        
    }
}