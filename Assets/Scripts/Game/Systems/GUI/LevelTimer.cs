using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace KnifeThrower.Game

{
    public class LevelTimer : MonoBehaviour, ILevelTimer
    {
        public float Timer { get; set; }
        private float _timeStart = 59f;
        private float _timeStop = 10f;
        private bool _isTimeStoppedByBooster = false;
        private IGUIControl _guiControl;

        [Inject]
        public void Construct(IGUIControl guiControl)
        {
            _guiControl = guiControl;
        }

        public void Init()
        {
            BoostersService.TimeStopPressed.AddListener(BoosterTimeStop);
            Timer = _timeStart;
        }

        private void Update()
        {
            TimerTick();
        }

        public void TimerTick()
        {
            if (_isTimeStoppedByBooster == false)
            {
                if (Timer > 0 && _guiControl.IsGameOn)
                {
                    Timer -= Time.deltaTime;
                }
            }
        }

        public void BoosterTimeStop()
        {
            _isTimeStoppedByBooster = true;
            StartCoroutine(Booster());
        }

        

        IEnumerator Booster()
        {
            for (int i = 10; i > 0; i--)
            {
                _timeStop--;
                if (_timeStop == 0)
                {
                    _isTimeStoppedByBooster = false;
                    _timeStop = 10f;
                    StopCoroutine(Booster());
                }

                yield return new WaitForSeconds(1f);
            }
        }
        
        private void OnDisable()
        {
            BoostersService.TimeStopPressed.RemoveListener(BoosterTimeStop);
        }
    }
}