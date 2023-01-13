using System;
using KnifeThrower.Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace KnifeThrower.Game
{
    public class LevelLostScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _innerContainer;
        [SerializeField] private Button _retryButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _exitButton;
        
        private ILevelLostService _levelLostService;
        private ISceneLoadingService _sceneLoadingService;

        [Inject]
        public void Construct(ILevelLostService levelLostService, ISceneLoadingService sceneLoadingService)
        {
            _sceneLoadingService = sceneLoadingService;
            _levelLostService = levelLostService;
        }

        private void Awake()
        {
            _innerContainer.SetActive(false);
        }

        private void Start()
        {
            _retryButton.onClick.AddListener(RestartLevel);
            _menuButton.onClick.AddListener(OpenMenuScene);
            _exitButton.onClick.AddListener(QuitGame);
        }

        private void Update()
        {
            if (_levelLostService.IsGameLost)
            {
                _innerContainer.SetActive(true);
            }
        }

        private void RestartLevel()
        {
            _sceneLoadingService.Load(SceneManager.GetActiveScene().name);
        }

        private void OpenMenuScene()
        {
            _sceneLoadingService.Load("MenuScene");
        }

        private void QuitGame()
        {
            throw new NotImplementedException();
        }
    }
}