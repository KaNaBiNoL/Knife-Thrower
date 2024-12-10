using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YG;

namespace KnifeThrower
{
    public class VideoReward : MonoBehaviour
    {
        [SerializeField] private Button _videoRewardButton;

        private void OnEnable()
        {
            _videoRewardButton.onClick.AddListener(OpenRewardVideo);
        }

        private void OpenRewardVideo()
        {
            YandexGame.RewVideoShow(0);
        }

        private void OnDisable()
        {
            _videoRewardButton.onClick.RemoveListener(OpenRewardVideo);
        }
    }
}
