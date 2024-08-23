using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace KnifeThrower
{
    public class LevelButtonFunctions : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _recordText;
        [SerializeField] private int _levelNumber;
        

        private void Start()
        {
            _recordText.text = $"Рекорд: {PlayerPrefs.GetInt($"Level{_levelNumber}Score", 0)}";
        }
    }
}