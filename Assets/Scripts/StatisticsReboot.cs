using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace KnifeThrower
{
    public class StatisticsReboot : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(StatReboot);
        }

        private void StatReboot()
        {
            YandexGame.ResetSaveProgress();

        }

        

        private void OnDisable()
        {
            _button.onClick.RemoveListener(StatReboot);
        }
    }
}
