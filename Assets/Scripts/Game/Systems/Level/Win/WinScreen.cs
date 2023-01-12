using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace KnifeThrower.Game
{
    public class WinScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _innerObject;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Button _retryButton;
        [SerializeField] private Button _exitButton;
        private IRemainingTargetsService _remainingTargetsService;

        [Inject]
        public void Construct(IRemainingTargetsService remainingTargetsService)
        {
            _remainingTargetsService = remainingTargetsService;
        }
        private void Awake()
        {
            _innerObject.SetActive(false);
        }

        private void Start()
        {
            _remainingTargetsService.OnWin += ShowWinScreen;
            _nextLevelButton.onClick.AddListener(ToNextLevel);
            _retryButton.onClick.AddListener(ReloadLevel);
            _exitButton.onClick.AddListener(Quit);
        }

        private void OnDestroy()
        {
            _remainingTargetsService.OnWin -= ShowWinScreen;
        }

        private void ShowWinScreen(bool isGameWon)
        {
            _innerObject.SetActive(isGameWon);
        }

        private void ToNextLevel()
        {
            
        }

        private void ReloadLevel()
        {
            throw new NotImplementedException();
        }

        private void Quit()
        {
            throw new NotImplementedException();
        }
    }
}