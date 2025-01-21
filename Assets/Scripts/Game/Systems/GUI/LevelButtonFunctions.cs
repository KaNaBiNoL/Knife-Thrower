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
        
        [SerializeField] private TextMeshProUGUI _recordText;
        [SerializeField] private int _levelNumber;
        

        private void Awake()
        {
            {
                _recordText.text = $"{YandexGame.savesData.ScoreOnLevel[_levelNumber]}";
            }
        }
    }
}