using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
            _selectSound.Play();
        }

        private void PlayPushSound()
        {
            _pushSound.Play();
        }

        private void OnDisable()
        {
            _thisButton.onClick.RemoveListener(PlayPushSound);
        }
    }
}
