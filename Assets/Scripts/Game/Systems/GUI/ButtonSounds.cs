using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YG;

namespace KnifeThrower
{
    public class ButtonSounds : MonoBehaviour, IPointerEnterHandler
    {
        private Button _thisButton;
        [SerializeField] private AudioSource _pushSound;
        [SerializeField] private AudioSource _selectSound;

        private bool _isDesktopPlatform;
        void Start()
        {
            if (YandexGame.EnvironmentData.isDesktop)
            {
                _isDesktopPlatform = true;
            }
            _thisButton = gameObject.GetComponent<Button>();
            _thisButton.onClick.AddListener(PlayPushSound);
            _pushSound.volume = 0.5f;
            _pushSound.pitch = 0.5f;
            _selectSound.volume = 0.5f;
            _selectSound.pitch = 0.5f;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_thisButton.interactable && _isDesktopPlatform)
            {
                _selectSound.Play();
            }
        }

        private void PlayPushSound()
        {
            if (_thisButton.interactable)
            {
                _pushSound.Play();
            }
        }

        private void OnDestroy()
        {
            if (gameObject.activeInHierarchy)
            {
                _thisButton.onClick.RemoveAllListeners();
            }
        }
    }
}