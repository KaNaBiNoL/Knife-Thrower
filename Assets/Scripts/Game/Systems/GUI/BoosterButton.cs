using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace KnifeThrower
{
    public class BoosterButton : MonoBehaviour
    {
        [SerializeField] private protected Button Button;
        [SerializeField] private protected Image DarkImage;
        [SerializeField] private protected TextMeshProUGUI Text;
        
        private protected void Awake()
        { 
            Button.onClick.AddListener(SetButtonUnActive);
            Button.onClick.AddListener(CheckAvailabilityByCount);
            DarkImage.gameObject.SetActive(false);
        }

        private protected void Start()
        {
            CheckAvailabilityByCount();
        }

        private void SetButtonUnActive()
        {
            DarkImage.gameObject.SetActive(true);
        }

        private protected void CheckAvailabilityByCount()
        {
            if (int.Parse(Text.text) <= 0)
            {
                DarkImage.gameObject.SetActive(true);
                Debug.Log($"{gameObject.name} set active");
            }

            else
            {
                Debug.Log($"{int.Parse(Text.text)} ne prohodit");
            }
        }

        private protected void OnDisable()
        {
            Button.onClick.RemoveListener(CheckAvailabilityByCount);
            Button.onClick.RemoveListener(SetButtonUnActive);
        }
    }
}
