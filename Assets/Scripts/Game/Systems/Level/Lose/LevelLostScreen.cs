using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace KnifeThrower.Game
{
    public class LevelLostScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _innerContainer;
        [SerializeField] private TextMeshProUGUI _levelLostText;
        
        
        private ILevelLostService _levelLostService;

        [Inject]
        public void Construct(ILevelLostService levelLostService)
        {
            _levelLostService = levelLostService;
        }

        private void Update()
        {
            if (_levelLostService.IsGameEnd)
            {
                _innerContainer.SetActive(true);
            }
        }
    }
}