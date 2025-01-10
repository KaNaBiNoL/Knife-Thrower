using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

namespace KnifeThrower
{
    public class MobileRetryButton : MonoBehaviour
    {
        [SerializeField] private Button _thisButton;

        private void OnEnable()
        {
            _thisButton.onClick.AddListener(ReloadLevel);
        }

        private void Start()
        {
            if (YandexGame.EnvironmentData.isDesktop)
            {
                _thisButton.gameObject.SetActive(false);
            }
        }

        private void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        private void OnDisable()
        {
            _thisButton.onClick.RemoveListener(ReloadLevel);
        }

        
    }
}
