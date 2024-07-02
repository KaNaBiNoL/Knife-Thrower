using System;
using UnityEngine;

namespace KnifeThrower.Game

{
    public class LevelTimer : MonoBehaviour, ILevelTimer
    {
        public float Timer { get; set; }
        private float timeStart = 59f;

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
            if (Timer > 0 )
            {
                Timer -= Time.deltaTime;
            }
        }
    }
}