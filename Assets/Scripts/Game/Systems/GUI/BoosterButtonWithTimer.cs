using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace KnifeThrower
{
    public class BoosterButtonWithTimer : BoosterButton
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        private int _timeOfActivity = 10;

        void Awake()
        {
            base.Awake();
            Button.onClick.AddListener(StartTimer);
            _timerText.gameObject.SetActive(false);
            Start();
        }

        private void StartTimer()
        {
            _timeOfActivity = 10;
            StartCoroutine(TimerToOn());
        }

        IEnumerator TimerToOn()
        {
            _timerText.gameObject.SetActive(true);
            for (int i = 10; i >= 0; i--)
            {
                _timeOfActivity--;
                _timerText.text = $"{_timeOfActivity}";
                if (_timeOfActivity == 0)
                {
                    _timerText.gameObject.SetActive(false);
                    DarkImage.gameObject.SetActive(false);
                    CheckAvailabilityByCount();
                    StopCoroutine(TimerToOn());
                }

                yield return new WaitForSeconds(1f);
            }
        }

        private void OnDestroy()
        {
            OnDisable();
        }
    }
}