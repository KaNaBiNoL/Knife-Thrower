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

        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _selectLevelButton;
        [SerializeField] private Button _ExitButton;
        
        
        private IPauseService _pauseService;
        private ISceneLoadingService _sceneLoadingService;

        [Inject]
        public void Construct(IPauseService pauseService, ISceneLoadingService sceneLoadingService)
        {
            _sceneLoadingService = sceneLoadingService;
            _pauseService = pauseService;
        }

        private void Awake()
        {
            _innerObject.SetActive(false);
        }

        private void Start()
        {
            _pauseService.OnChanged += PauseChanged;
            _resumeButton.onClick.AddListener(ResumeGame);
            _restartButton.onClick.AddListener(RestartLevel);
        }

        private void OnDestroy()
        {
            _pauseService.OnChanged -= PauseChanged;
        }

        private void PauseChanged(bool isPaused)
        {
            _innerObject.SetActive(isPaused);
        }

        private void ResumeGame()
        {
            _pauseService.TogglePause();
        }

        private void RestartLevel()
        {
            _sceneLoadingService.Load(SceneManager.GetActiveScene().buildIndex);
            _pauseService.TogglePause();
        }
    }
}