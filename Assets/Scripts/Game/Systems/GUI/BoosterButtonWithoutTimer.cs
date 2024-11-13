using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeThrower
{
    public class BoosterButtonWithoutTimer : BoosterButton
    {
        private bool _canBeActive;

        private void OnEnable()
        {
            ShurikenCollision.OnShurikenCollide.AddListener(MakeButtonActive);
        }

        void Awake()
        {
            base.Awake();
            Button.onClick.AddListener(PushProcess);
            Start();
        }
        
        

        void Update()
        {
        }

        private void MakeButtonActive()
        {
            if (_canBeActive)
            {
                DarkImage.gameObject.SetActive(false);
                CheckAvailabilityByCount();
                _canBeActive = false;
            }
        }

        private void PushProcess()
        {
            StartCoroutine(StartDelay());
        }

        IEnumerator StartDelay()
        {
            for (int i = 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    _canBeActive = true;
                    StopCoroutine(StartDelay());
                }

                yield return new WaitForSeconds(1f);
            }
        }

        private void OnDestroy()
        {
            OnDisable();
            ShurikenCollision.OnShurikenCollide.RemoveListener(MakeButtonActive);
        }
    }
}