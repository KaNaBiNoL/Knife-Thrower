using System;
using KnifeThrower.Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace KnifeThrower.Game
{
    public class WinScreen : MonoBehaviour
    {
        public int FullLevelScore { get; set; }
        
        [SerializeField] private GameObject _innerObject;
        [SerializeField] private Button _nextLevelButton;
       // [SerializeField] private Button _retryButton;
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

        [Inject]
        public void Construct(IRemainingTargetsService remainingTargetsService, ISceneLoadingService sceneLoadingService,
            IScoreService scoreService, IRemainingShurikens remainingShurikens, ILevelTimer levelTimer, 
            IGoldForLevel goldForLevel)
        {
            _sceneLoadingService = sceneLoadingService;
            _remainingTargetsService = remainingTargetsService;
            _scoreService = scoreService;
            _remainingShurikens = remainingShurikens;
            _levelTimer = levelTimer;
            _goldForLevel = goldForLevel;
        }
        private void Awake()
        {
            _innerObject.SetActive(false);
        }

        private void Start()
        {
            _remainingTargetsService.OnWin += ShowWinScreen;
            _nextLevelButton.onClick.AddListener(ToNextLevel);
         //   _retryButton.onClick.AddListener(ReloadLevel);
            _exitButton.onClick.AddListener(Quit);
        }

        private void OnDestroy()
        {
            _remainingTargetsService.OnWin -= ShowWinScreen;
        }

        private void ShowWinScreen(bool isGameWon)
        {
            _innerObject.SetActive(isGameWon);

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

        private void Quit()
        {
            throw new NotImplementedException();
        }
        
    }
}