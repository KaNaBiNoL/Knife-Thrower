using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace KnifeThrower
{
    public class FullScreenADSystem : MonoBehaviour
    {
        private int _countToAD;

        void Start()
        {
            SetNewCountToAD();
        }

        private void SetNewCountToAD()
        {
            _countToAD = YandexGame.savesData.AdsCounter;
            _countToAD--;
            if (_countToAD < 1)
            {
                YandexGame.FullscreenShow();
                _countToAD = Random.Range(2, 3);
            }

            YandexGame.savesData.AdsCounter = _countToAD;
            YandexGame.SaveProgress();
        }
    }
}