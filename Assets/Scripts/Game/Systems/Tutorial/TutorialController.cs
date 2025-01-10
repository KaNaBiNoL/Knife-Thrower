using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace KnifeThrower
{
    public class TutorialController : MonoBehaviour
    {
        [SerializeField] private GameObject _starTutorialBlock;
        [SerializeField] private GameObject _secondTutorialBlock;

        private bool _isStartBlockShowed = false;
        private bool _isSecondBlockShowed = false;

        [Inject]
        private ThrowArea _throwArea;

        private void OnEnable()
        {
        }

        void Start()
        {
        }

        void Update()
        {
            if (_throwArea.IsThrowPrepared)
            {
                ShowSecondBlock();
            }
            else
            {
                ShowStartBlock();
            }
        }

        private void ShowStartBlock()
        {
            if (_isStartBlockShowed == false)
            {
                _secondTutorialBlock.SetActive(false);
                _starTutorialBlock.SetActive(true);
                _isSecondBlockShowed = false;
                _isStartBlockShowed = true;
            }
        }

        private void ShowSecondBlock()
        {
            if (_isSecondBlockShowed == false)
            {
                _secondTutorialBlock.SetActive(true);
                _starTutorialBlock.SetActive(false);
                _isSecondBlockShowed = true;
                _isStartBlockShowed = false;
            }
        }
    }
}