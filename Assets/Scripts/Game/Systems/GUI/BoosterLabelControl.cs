using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace KnifeThrower
{
    public class BoosterLabelControl : MonoBehaviour, IPointerExitHandler
    {
        [SerializeField] private Button _showButton;
        [SerializeField] private RectTransform _rt;
        [SerializeField] private float _duration = 1f;
        [SerializeField] private Ease _ease;

        private float _endPosforLeft = -5f;

        private void OnEnable()
        {
        }

        void Start()
        {
            _showButton.onClick.AddListener(ShowLabel);
            _endPosforLeft = _rt.anchoredPosition.x;
        }

        void Update()
        {
        }

        private void ShowLabel()
        {
            _showButton.gameObject.SetActive(false);
            _rt.DOAnchorPosX(_endPosforLeft + 150f, _duration);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _showButton.gameObject.SetActive(true);
            _rt.DOAnchorPosX(_endPosforLeft, _duration);
        }

        private void OnDisable()
        {
            _showButton.onClick.RemoveListener(ShowLabel);
        }
    }
}