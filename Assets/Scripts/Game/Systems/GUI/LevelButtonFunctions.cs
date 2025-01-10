using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace KnifeThrower
{
    public class LevelButtonFunctions : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        [SerializeField] private TextMeshProUGUI _recordText;
        [SerializeField] private int _levelNumber;
        

        private void Start()
        {
            if (_button.interactable)
            {
                _recordText.text = $"{YandexGame.savesData.LevelScores[_levelNumber]}";
            }

            else
            {
                _recordText.text = "0";
            }

            
        }
    }
}