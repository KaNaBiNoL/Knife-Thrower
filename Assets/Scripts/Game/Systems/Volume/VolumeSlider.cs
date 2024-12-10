using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using YG;

namespace KnifeThrower
{
    public class VolumeSlider : MonoBehaviour
    {
        [SerializeField] private Slider _volumeSlider;
        
        [SerializeField] private AudioMixer _audioMixer;
        public string _volumeParameter = "VolumeMaster";

        private const float Multiplier = 20f;
        private float _volumeValue;

        private void OnEnable()
        {
            _volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }

        

        void Start()
        {
            _volumeValue = YandexGame.savesData.GlobalVolumeValue;
            _volumeSlider.value = Mathf.Pow(10f, _volumeValue / Multiplier);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        private void ChangeVolume(float value)
        {
            _volumeValue = Mathf.Log10(value) * Multiplier;
            _audioMixer.SetFloat(_volumeParameter, _volumeValue);
        }

        private void OnDisable()
        {
            _volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
            YandexGame.savesData.GlobalVolumeValue = _volumeValue;
            YandexGame.SaveProgress();
        }
    }
}
