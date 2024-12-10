using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using YG;

namespace KnifeThrower
{
    public class LevelButtonFunctions : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _recordText;
        [SerializeField] private int _levelNumber;
        

        private void Start()
        {
            _recordText.text = $"{YandexGame.savesData.LevelScores[_levelNumber]}";
        }
    }
}