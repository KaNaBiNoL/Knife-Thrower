using System;
using System.Collections;
using System.Collections.Generic;
using KnifeThrower.Game;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YG;
using Zenject;

namespace KnifeThrower
{
    public class BoostersService : MonoBehaviour
    {
        [SerializeField] private Button _timeStopButton;
        [SerializeField] private Button _windStopButton;
        [SerializeField] private Button _multiShurikenButton;
        [SerializeField] private Button _powerShotButton;
        [SerializeField] private TextMeshProUGUI _timeStopCountText;
        [SerializeField] private TextMeshProUGUI _windStopCountText;
        [SerializeField] private TextMeshProUGUI _multiShurikenCountText;
        [SerializeField] private TextMeshProUGUI _powerShotCountText;
        private int _timeStopCount;
        private int _windStopCount;
        private int _multiShurikenCount;
        private int _powerShotCount;
        public static UnityEvent TimeStopPressed = new UnityEvent();
        public static UnityEvent WindStopPressed = new UnityEvent();
        public static UnityEvent MultiShurikenPressed = new UnityEvent();
        public static UnityEvent PowerShotPressed = new UnityEvent();

        private void OnEnable()
        {
            _timeStopButton.onClick.AddListener(TimeStopPressed.Invoke);
            _windStopButton.onClick.AddListener(WindStopPressed.Invoke);
            _multiShurikenButton.onClick.AddListener(MultiShurikenPressed.Invoke);
            _powerShotButton.onClick.AddListener(PowerShotPressed.Invoke);
        }

        private void Awake()
        {
            _timeStopCount = YandexGame.savesData.BoostersCount[0];
            _windStopCount = YandexGame.savesData.BoostersCount[1];
            _multiShurikenCount = YandexGame.savesData.BoostersCount[2];
            _powerShotCount = YandexGame.savesData.BoostersCount[3];
        }

        void Start()
        {
            UpdateBoosterLabel(_timeStopCountText, _timeStopCount);
            UpdateBoosterLabel(_windStopCountText, _windStopCount);
            UpdateBoosterLabel(_multiShurikenCountText, _multiShurikenCount);
            UpdateBoosterLabel(_powerShotCountText, _powerShotCount);
        }

        void Update()
        {
        }

        private void UpdateBoosterLabel(TextMeshProUGUI label, int count)
        {
            label.text = $"{count}";
        }

        public void DecreaseCountOfBooster1()
        {
            _timeStopCount--;
            UpdateBoosterLabel(_timeStopCountText, _timeStopCount);
        }

        public void DecreaseCountOfBooster2()
        {
            _windStopCount--;
            UpdateBoosterLabel(_windStopCountText, _windStopCount);
        }

        public void DecreaseCountOfBooster3()
        {
            _multiShurikenCount--;
            UpdateBoosterLabel(_multiShurikenCountText, _multiShurikenCount);
        }

        public void DecreaseCountOfBooster4()
        {
            _powerShotCount--;
            UpdateBoosterLabel(_powerShotCountText, _powerShotCount);
        }

        private void OnDisable()
        {
            _timeStopButton.onClick.RemoveAllListeners();
            _windStopButton.onClick.RemoveAllListeners();
            _multiShurikenButton.onClick.RemoveAllListeners();
            _powerShotButton.onClick.RemoveAllListeners();
        }
    }
}