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
        [SerializeField] private Texture2D _crosshairCursor;
        [SerializeField] private Vector2 _crosshairOffset;

        [SerializeField] private Button _timeStopButton;
        [SerializeField] private Button _windStopButton;
        [SerializeField] private Button _multiShurikenButton;
        [SerializeField] private Button _powerShotButton;
        [SerializeField] private Button _trajectoryShowButton;
        [SerializeField] private TextMeshProUGUI _timeStopCountText;
        [SerializeField] private TextMeshProUGUI _windStopCountText;
        [SerializeField] private TextMeshProUGUI _multiShurikenCountText;
        [SerializeField] private TextMeshProUGUI _powerShotCountText;
        [SerializeField] private TextMeshProUGUI _trajectoryShowText;
        private int _timeStopCount;
        private int _windStopCount;
        private int _multiShurikenCount;
        private int _powerShotCount;
        private int _trajectoryShowCount;
        public static UnityEvent TimeStopPressed = new UnityEvent();
        public static UnityEvent WindStopPressed = new UnityEvent();
        public static UnityEvent MultiShurikenPressed = new UnityEvent();
        public static UnityEvent PowerShotPressed = new UnityEvent();
        public static UnityEvent TrajectoryShowPressed = new UnityEvent();

        public static bool IsPowerShotPressed
        {
            get;
            private set;
        }

        private void OnEnable()
        {
            _timeStopButton.onClick.AddListener(TimeStopPressed.Invoke);
            _windStopButton.onClick.AddListener(WindStopPressed.Invoke);
            _multiShurikenButton.onClick.AddListener(MultiShurikenPressed.Invoke);
            _powerShotButton.onClick.AddListener(PowerShotPressed.Invoke);
            _trajectoryShowButton.onClick.AddListener(TrajectoryShowPressed.Invoke);
            PowerShotPressed.AddListener(PowerShotLink);
            PowerShotPressed.AddListener(CursorToCrosshair);
            ShurikenCollision.OnShurikenCollide.AddListener(EndPowerShotLink);
            ShurikenCollision.OnShurikenCollide.AddListener(CursorToDefault);
        }

        private void Awake()
        {
            _timeStopCount = YandexGame.savesData.BoostersCount[0];
            _windStopCount = YandexGame.savesData.BoostersCount[1];
            _multiShurikenCount = YandexGame.savesData.BoostersCount[2];
            _powerShotCount = YandexGame.savesData.BoostersCount[3];
            _trajectoryShowCount = YandexGame.savesData.AddedBoosterCount;
            UpdateBoosterLabel(_timeStopCountText, _timeStopCount);
            UpdateBoosterLabel(_windStopCountText, _windStopCount);
            UpdateBoosterLabel(_multiShurikenCountText, _multiShurikenCount);
            UpdateBoosterLabel(_powerShotCountText, _powerShotCount);
            UpdateBoosterLabel(_trajectoryShowText, _trajectoryShowCount);
        }

        void Start()
        {
            CursorToDefault();
        }

        void Update()
        {
        }

        private void UpdateBoosterLabel(TextMeshProUGUI label, int count)
        {
            label.text = $"{count}";
        }

        private void CursorToDefault()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        private void CursorToCrosshair()
        {
            Cursor.SetCursor(_crosshairCursor, _crosshairOffset, CursorMode.Auto);
        }

        private void PowerShotLink()
        {
            IsPowerShotPressed = true;
        }

        private void EndPowerShotLink()
        {
            IsPowerShotPressed = false;
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
        public void DecreaseCountOfBooster5()
        {
            _trajectoryShowCount--;
            UpdateBoosterLabel(_trajectoryShowText, _trajectoryShowCount);
        }

        private void OnDisable()
        {
            YandexGame.savesData.BoostersCount[0] = _timeStopCount;
            YandexGame.savesData.BoostersCount[1] = _windStopCount;
            YandexGame.savesData.BoostersCount[2] = _multiShurikenCount;
            YandexGame.savesData.BoostersCount[3] = _powerShotCount;
            YandexGame.savesData.AddedBoosterCount = _trajectoryShowCount;
            YandexGame.SaveProgress();
            _timeStopButton.onClick.RemoveAllListeners();
            _windStopButton.onClick.RemoveAllListeners();
            _multiShurikenButton.onClick.RemoveAllListeners();
            _powerShotButton.onClick.RemoveAllListeners();
            _trajectoryShowButton.onClick.RemoveAllListeners();
            PowerShotPressed.RemoveListener(PowerShotLink);
            ShurikenCollision.OnShurikenCollide.RemoveListener(EndPowerShotLink);
            ShurikenCollision.OnShurikenCollide.RemoveListener(CursorToDefault); 
        }
    }
}