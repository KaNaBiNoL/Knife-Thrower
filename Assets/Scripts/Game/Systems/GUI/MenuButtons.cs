using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KnifeThrower
{
    public class MenuButtons : MonoBehaviour
    {
        [SerializeField] private Button _selectLevelsButton;
        [SerializeField] private Button _shopButton;
        [SerializeField] private Button _tutorialButton;
        [SerializeField] private GameObject _levelsPanel;
        [SerializeField] private GameObject _shopPanel;
        [SerializeField] private GameObject _tutorialPanel;

        private void OnEnable()
        {
            _selectLevelsButton.onClick.AddListener(OpelLeveLsPanel);
            _shopButton.onClick.AddListener(OpenShopPanel);
            _tutorialButton.onClick.AddListener(OpenTutorialPanel);
        }

        

        

        private void OpelLeveLsPanel()
        {
            if (!_levelsPanel.activeInHierarchy && !_shopPanel.activeInHierarchy && !_tutorialPanel.activeInHierarchy)
            {
                _levelsPanel.SetActive(true);
            }
        }
        
        private void OpenShopPanel()
        {
            if (!_levelsPanel.activeInHierarchy && !_shopPanel.activeInHierarchy && !_tutorialPanel.activeInHierarchy)
            {
                _shopPanel.SetActive(true);
            }
        }
        private void OpenTutorialPanel()
        {
            if (!_levelsPanel.activeInHierarchy && !_shopPanel.activeInHierarchy && !_tutorialPanel.activeInHierarchy)
            {
                _tutorialPanel.SetActive(true);
            }
        }

        private void OnDisable()
        {
            _selectLevelsButton.onClick.RemoveListener(OpelLeveLsPanel);
            _shopButton.onClick.RemoveListener(OpenShopPanel);
            _tutorialButton.onClick.RemoveListener(OpenTutorialPanel);
        }
    }
}
