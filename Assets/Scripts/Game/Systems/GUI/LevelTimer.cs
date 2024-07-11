using System;
using UnityEngine;
using Zenject;

namespace KnifeThrower.Game

{
    public class LevelTimer : MonoBehaviour, ILevelTimer
    {
        public float Timer { get; set; }
        private float timeStart = 59f;
        private IGUIControl _guiControl;

        [Inject]
        public void Construct(IGUIControl guiControl)
        {
            _guiControl = guiControl;
        }

        public void Init()
        {
            Timer = timeStart;
        }

        private void Update()
        {
            TimerTick();
        }

        public void TimerTick()
        {
            if (Timer > 0 && _guiControl.IsGameOn)
            {
                Timer -= Time.deltaTime;
            }
        }
    }
}