using System;
using KnifeThrower.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace KnifeThrower.Game
{
    public class WinScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _innerObject;
        [SerializeField] private Button _nextLevelButton;
       // [SerializeField] private Button _retryButton;
        [SerializeField] private Button _exitButton;
        
        private IRemainingTargetsService _remainingTargetsService;
        private ISceneLoadingService _sceneLoadingService;

        [Inject]
        public void Construct(IRemainingTargetsService remainingTargetsService, ISceneLoadingService sceneLoadingService)
        {
            _sceneLoadingService = sceneLoadingService;
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