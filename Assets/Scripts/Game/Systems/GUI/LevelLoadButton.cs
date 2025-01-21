using System;
using System.Collections;
using System.Collections.Generic;
using KnifeThrower.Services;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace KnifeThrower
{
    public class LevelLoadButton : MonoBehaviour
    {
        [SerializeField] private Button _thisButton;
        
        [SerializeField] private int _loadedSceneIndex;
        
        private ISceneLoadingService _sceneLoadingService;

        [Inject]
        public void Construct(ISceneLoadingService sceneLoadingService)
        {
            _sceneLoadingService = sceneLoadingService;
        }

        private void OnEnable()
        {
            _thisButton.onClick.AddListener(LoadLevel);
        }

        

        private void LoadLevel()
        {
            _sceneLoadingService.Load(_loadedSceneIndex);
        }

        private void OnDisable()
        {
            _thisButton.onClick.RemoveListener(LoadLevel);
        }
    }
}