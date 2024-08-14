using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace KnifeThrower
{
    public class SwipeLevelsMenuController : MonoBehaviour
    {
        [SerializeField] private RectTransform _pages;

        [SerializeField] private Vector3 _swipeOffset;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;
        [SerializeField] private int _numberOfPages;
        private int _pagesCount;
        private Vector3 _targetPos;
        private Vector3 _rectPos;

        private void Awake()
        {
            _pagesCount = 1;
            _rectPos.x = _pages.rect.x;
        }

        public void SwipeNext()
        {
            if (_pagesCount < _numberOfPages)
            {
                _targetPos.x = _rectPos.x - _swipeOffset.x;
                _rectPos.x = _targetPos.x;
                _pages.DOAnchorPosX(_targetPos.x, _duration).SetEase(_ease);
                _pagesCount++;
            }
        }

        public void SwipePrevious()
        {
            if (_pagesCount > 1)
            {
                _targetPos.x = _rectPos.x + _swipeOffset.x;
                _rectPos.x = _targetPos.x;
                _pages.DOAnchorPosX(_targetPos.x, _duration).SetEase(_ease);
                _pagesCount--;
            }
        }
    }
}