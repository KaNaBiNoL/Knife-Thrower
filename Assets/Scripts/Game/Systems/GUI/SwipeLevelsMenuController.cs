using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace KnifeThrower
{
    public class SwipeLevelsMenuController : MonoBehaviour
    {
        [SerializeField] private RectTransform _pages;
        [SerializeField] private Image[] _pagesObjects;
        [SerializeField] private GameObject[] _page1Childs;
        [SerializeField] private GameObject[] _page2Childs;
        //  [SerializeField] private GameObject[] _page3Childs;

        [SerializeField] private Vector3 _swipeOffset;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;
        [SerializeField] private int _numberOfPages;
        [SerializeField] private Image[] _circleImages;

        private int _pagesCount;
        private Vector3 _targetPos;
        private Vector3 _rectPos;
        private float _smallScale = 0.6f;
        private Color _lowAlpha = new(1, 1, 1, 0.5f);
        private Color _defaultAlpha = new(1, 1, 1, 1);

        private void Awake()
        {
            
        }

        private void Start()
        {
            _pagesCount = 1;
            _rectPos.x = _pages.rect.x + _pages.rect.width/2;
            SwipeDownCircle();
        }

        public void SwipeNext()
        {
            if (_pagesCount < _numberOfPages)
            {
                _targetPos.x = _rectPos.x - _swipeOffset.x;
                Debug.Log($"rect {_rectPos.x} - offset {_swipeOffset} = target {_targetPos.x}");
                _rectPos.x = _targetPos.x;
                _pages.DOAnchorPosX(_targetPos.x, _duration).SetEase(_ease);
                _pagesCount++;
                SwipeDownCircle();
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
                SwipeDownCircle();
            }
        }

        private void SwipeDownCircle()
        {
            switch (_pagesCount)
            {
                case 1:
                    _circleImages[0].transform.localScale = new Vector3(1f, 1f, 1f);
                    _circleImages[1].transform.localScale = new Vector3(_smallScale, _smallScale, _smallScale);
                    _circleImages[2].transform.localScale = new Vector3(_smallScale, _smallScale, _smallScale);
                    _circleImages[0].color = _defaultAlpha;
                    _circleImages[1].color = _lowAlpha;
                    _circleImages[2].color = _lowAlpha;
                    _pagesObjects[0].enabled = true;
                    _pagesObjects[1].enabled = false;
                    _pagesObjects[2].enabled = false;
                    foreach (GameObject i in _page1Childs)
                    {
                        i.SetActive(true);
                    }

                    foreach (GameObject i in _page2Childs)
                    {
                        i.SetActive(false);
                    }

                    /*   foreach (GameObject i in _page3Childs)
                       {
                           i.SetActive(false);
                       } */
                    break;
                case 2:
                    _circleImages[0].transform.localScale = new Vector3(_smallScale, _smallScale, _smallScale);
                    _circleImages[1].transform.localScale = new Vector3(1f, 1f, 1f);
                    _circleImages[2].transform.localScale = new Vector3(_smallScale, _smallScale, _smallScale);
                    _circleImages[0].color = _lowAlpha;
                    _circleImages[1].color = _defaultAlpha;
                    _circleImages[2].color = _lowAlpha;
                    _pagesObjects[0].enabled = false;
                    _pagesObjects[1].enabled = true;
                    _pagesObjects[2].enabled = false;
                    foreach (GameObject i in _page1Childs)
                    {
                        i.SetActive(false);
                    }

                    foreach (GameObject i in _page2Childs)
                    {
                        i.SetActive(true);
                    }

                    /*   foreach (GameObject i in _page3Childs)
                       {
                           i.SetActive(false);
                       } */
                    break;

                case 3:
                    _circleImages[0].transform.localScale = new Vector3(_smallScale, _smallScale, _smallScale);
                    _circleImages[1].transform.localScale = new Vector3(_smallScale, _smallScale, _smallScale);
                    _circleImages[2].transform.localScale = new Vector3(1f, 1f, 1f);
                    _circleImages[0].color = _lowAlpha;
                    _circleImages[1].color = _lowAlpha;
                    _circleImages[2].color = _defaultAlpha;
                    _pagesObjects[0].enabled = false;
                    _pagesObjects[1].enabled = false;
                    _pagesObjects[2].enabled = true;
                    foreach (GameObject i in _page1Childs)
                    {
                        i.SetActive(false);
                    }

                    foreach (GameObject i in _page2Childs)
                    {
                        i.SetActive(false);
                    }

                    /*   foreach (GameObject i in _page3Childs)
                       {
                           i.SetActive(true);
                       } */
                    break;
            }
        }
    }
}