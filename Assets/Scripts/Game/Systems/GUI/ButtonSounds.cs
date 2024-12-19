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

        void Start()
        {
            _thisButton = gameObject.GetComponent<Button>();
            _thisButton.onClick.AddListener(PlayPushSound);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_thisButton.interactable && YandexGame.EnvironmentData.isDesktop)
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