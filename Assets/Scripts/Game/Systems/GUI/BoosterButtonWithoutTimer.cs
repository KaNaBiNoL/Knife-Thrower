using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KnifeThrower
{
    public class BoosterButtonWithoutTimer : BoosterButton
    {
        [SerializeField] private Image _imageOfNeighborBooster;
        [SerializeField] private TextMeshProUGUI _neighborBoosterTextCount;
        
        
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
                MakeNeibhorButtonActive();
                _canBeActive = false;
            }
        }

        private void MakeNeibhorButtonActive()
        {
            if (int.Parse(_neighborBoosterTextCount.text) < 1)
            {
                _imageOfNeighborBooster.gameObject.SetActive(true);
            }
            else
            {
                _imageOfNeighborBooster.gameObject.SetActive(false);
            }
        }

        private void PushProcess()
        {
            StartCoroutine(StartDelay());
            _imageOfNeighborBooster.gameObject.SetActive(true);
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
            Button.onClick.RemoveListener(PushProcess);
        }
    }
}