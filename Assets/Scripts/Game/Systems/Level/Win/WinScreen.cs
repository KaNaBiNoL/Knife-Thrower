using System;
using DG.Tweening;
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
        [SerializeField] private RectTransform _adRewardedTextRectTransform;
        [SerializeField] private TextMeshProUGUI _adRewardedText;
        [SerializeField] private float _adRewardedTextFadeDuration;
        [SerializeField] private Ease _adRewardedTextFadeEase;
        
        

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
            YandexGame.RewardVideoEvent += Rewarded;
        }

        

        private void Awake()
        {
            _innerObject.SetActive(false);
        }

        

        

        private void ShowWinScreen(bool isGameWon)
        {
            
            _innerObject.SetActive(isGameWon);
            _guiControl.IsGameOn = false;
            _guiControl.IsGameWinOrLost = true;

            if (isGameWon)
            {
                switch (YandexGame.EnvironmentData.language)
                {
                    case "ru":
                        _scoreForShotsText.text = $"Очки за сбитые мишени - {_scoreService.LevelScore}";
                        _scoreForRemainingShurikensText.text = "Бонус за оставшиеся сюрикены - " +
                            $"{_remainingShurikens.ShurikenCount * 100}";
                        _scoreForTimeText.text = $"Бонус за время - {Convert.ToInt32(_levelTimer.Timer) * 10}";
                        break;
                    case "en":
                        _scoreForShotsText.text = $"Points for downed targets - {_scoreService.LevelScore}";
                        _scoreForRemainingShurikensText.text = "Bonus for remaining shurikens - " +
                            $"{_remainingShurikens.ShurikenCount * 100}";
                        _scoreForTimeText.text = $"Time bonus - {Convert.ToInt32(_levelTimer.Timer) * 10}";
                        break;
                    case "es":
                        _scoreForShotsText.text = $"Puntos por objetivos derribados - {_scoreService.LevelScore}";
                        _scoreForRemainingShurikensText.text = "Bonificación por los shurikens restantes - " +
                            $"{_remainingShurikens.ShurikenCount * 100}";
                        _scoreForTimeText.text = $"Bonificación de tiempo - {Convert.ToInt32(_levelTimer.Timer) * 10}";
                        break;
                    case "de":
                        _scoreForShotsText.text = $"Punkte für abgeschossene Ziele - {_scoreService.LevelScore}";
                        _scoreForRemainingShurikensText.text = "Bonus für verbleibende Shuriken – " +
                            $"{_remainingShurikens.ShurikenCount * 100}";
                        _scoreForTimeText.text = $"Zeitbonus - {Convert.ToInt32(_levelTimer.Timer) * 10}";
                        break;
                    case "tr":
                        _scoreForShotsText.text = $"Düşen hedefler için puanlar - {_scoreService.LevelScore}";
                        _scoreForRemainingShurikensText.text = "Kalan shurikenler için bonus - " +
                            $"{_remainingShurikens.ShurikenCount * 100}";
                        _scoreForTimeText.text = $"Zaman bonusu - {Convert.ToInt32(_levelTimer.Timer) * 10}";
                        break;
                }
              //  _scoreForShotsText.text = $" {_scoreService.LevelScore}";
               // _scoreForRemainingShurikensText.text = $" {(_remainingShurikens.ShurikenCount - 1) * 100}";
              //  _scoreForTimeText.text = $" {Convert.ToInt32(_levelTimer.Timer) * 10}";
                FullLevelScore = _scoreService.LevelScore + ((_remainingShurikens.ShurikenCount) * 100) +
                    (Convert.ToInt32(_levelTimer.Timer) * 10);
                _levelScoreText.text = $"{FullLevelScore}";
                _goldForLevel.GoldReward += 30;
                _levelGoldText.text = $"{_goldForLevel.GoldReward}";
                SaveScore();
            }
            
            UnlockNewLevel();
        }
        
        private void Rewarded(int id)
        {
            id = 0;
            _adRewardedText.text = $"+{_goldForLevel.GoldReward}";
            _goldForLevel.GoldReward *= 2;
            _levelGoldText.text = $"{_goldForLevel.GoldReward}";
            _adRewardedText.gameObject.SetActive(true);
            _adsButton.gameObject.SetActive(false);
            _adRewardedTextRectTransform.DOAnchorPosY(0.2f, _adRewardedTextFadeDuration);
            _adRewardedText.DOFade(0, _adRewardedTextFadeDuration + 0.5f).SetEase(_adRewardedTextFadeEase);
        }

        private void SaveScore()
        {
            int sceneNumber = (SceneManager.GetActiveScene().buildIndex - 1);
            if (FullLevelScore > YandexGame.savesData.ScoreOnLevel[sceneNumber])
            {
                YandexGame.savesData.ScoreOnLevel[sceneNumber] = FullLevelScore;
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
            YandexGame.savesData.PlayerMoney += _goldForLevel.GoldReward;
            YandexGame.RewardVideoEvent -= Rewarded;
            YandexGame.SaveProgress();
        }

        
    }
}