using System;
using KnifeThrower.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace KnifeThrower.Game
{
    public class PauseScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _innerObject;
        [SerializeField] private Button _pauseButton;
        

        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _ExitButton;

        private IPauseService _pauseService;
        private ISceneLoadingService _sceneLoadingService;
        private IGUIControl _guiControl;

        [Inject]
        public void Construct(IPauseService pauseService, ISceneLoadingService sceneLoadingService,
            IGUIControl guiControl)
        {
            _sceneLoadingService = sceneLoadingService;
            _pauseService = pauseService;
            _guiControl = guiControl;
        }

        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(PauseByButton);
            _resumeButton.onClick.AddListener(ResumeGame);
            _restartButton.onClick.AddListener(RestartLevel);
            _ExitButton.onClick.AddListener(GoToMenu);
            _pauseService.OnChanged += PauseChanged;
        }

        private void PauseByButton()
        {
            _pauseService.TogglePause();
            _guiControl.IsGamePaused = true;
        }

        private void Awake()
        {
            _innerObject.SetActive(false);
        }

        

        

        private void PauseChanged(bool isPaused)
        {
            if (_guiControl.IsGameOn)
            {
                _innerObject.SetActive(isPaused);
            }
        }

        private void ResumeGame()
        {
            _pauseService.TogglePause();
            _guiControl.IsGamePaused = false;
            _guiControl.IsGameOn = true;
        }

        private void RestartLevel()
        {
            _pauseService.TogglePause();
            _sceneLoadingService.Load(SceneManager.GetActiveScene().buildIndex);
            
        }
        
        private void GoToMenu()
        {
            _pauseService.TogglePause();
            _sceneLoadingService.Load(1);
            
        }

        private void OnDisable()
        {
            _pauseButton.onClick.RemoveListener(PauseByButton);
            _resumeButton.onClick.RemoveListener(ResumeGame);
            _restartButton.onClick.RemoveListener(RestartLevel);
            _ExitButton.onClick.RemoveListener(GoToMenu);
            _pauseService.OnChanged -= PauseChanged;
        }
    }
}