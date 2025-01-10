using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace KnifeThrower
{
    public class AdditionalTutorialController : MonoBehaviour
    {
        [SerializeField] private GameObject _startTutorialBlock;
        [SerializeField] private GameObject _secondTutorialBlock;

        private bool _isStartTutorialShowed;
        private bool _isSecondTutorialShowed;
        private bool _isSwitchAllowed = true;

        [Inject]
        private ThrowArea _throwArea;

        void Start()
        {
            _isStartTutorialShowed = true;
            _isSecondTutorialShowed = false;
            _startTutorialBlock.SetActive(true);
            _secondTutorialBlock.SetActive(false);
        }

        void Update()
        {
            if (_isSwitchAllowed)
            {


                if (_throwArea.IsThrowPrepared && _isStartTutorialShowed)
                {
                    SwitchBlocksFirstTime();
                }

                else if (!_throwArea.IsThrowPrepared && !_isStartTutorialShowed)
                {
                    SwitchBlockSecondTime();
                }

                else if (_throwArea.IsThrowPrepared && _isSecondTutorialShowed)
                {
                    SwitchBlockThirdTime();
                }
            }
        }

        

        private void SwitchBlocksFirstTime()
        {
            if (_isStartTutorialShowed)
            {
                _isStartTutorialShowed = false;
                _startTutorialBlock.SetActive(false);
                _secondTutorialBlock.SetActive(false);
            }
        }
        
        private void SwitchBlockSecondTime()
        {
            _secondTutorialBlock.SetActive(true);
            _isSecondTutorialShowed = true;
        }
        
        private void SwitchBlockThirdTime()
        {
            _secondTutorialBlock.SetActive(false);
            _isSecondTutorialShowed = false;
            _isSwitchAllowed = false;
        }
    }
}