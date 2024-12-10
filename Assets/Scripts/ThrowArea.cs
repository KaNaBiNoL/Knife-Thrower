using System;
using UnityEngine;
using Zenject;

namespace KnifeThrower
{
    public class ThrowArea : MonoBehaviour
    {
        public float MouseYDistance { get; private set; }

        private Vector3 _startMousePosition;
        private Vector3 _endMousePosition;

        private bool _isOnStartPosition = false;
        private bool _isPowerShotBoosterUsed = false;
        private IInputPosition _inputPosition;

        public bool IsThrowPrepared { get; private set; }

        [Inject]
        public void Construct(IInputPosition inputPosition)
        {
            _inputPosition = inputPosition;
        }

        private void OnEnable()
        {
            BoostersService.PowerShotPressed.AddListener(BoosterUseReaction);
        }

        private void Update()
        {
            SetStartMousePosition();
            SetEndMousePosition();
        }

        private void OnMouseEnter()
        {
            _isOnStartPosition = true;
        }

        private void OnMouseExit()
        {
            _isOnStartPosition = false;
        }

        private void BoosterUseReaction()
        {
            _isPowerShotBoosterUsed = true;
        }

        private void SetStartMousePosition()
        {
            if (_isPowerShotBoosterUsed && Input.GetButtonDown("Fire1"))
            {
                IsThrowPrepared = true;
                _isPowerShotBoosterUsed = false;
            }
            else if (_isOnStartPosition && Input.GetButtonDown("Fire1"))
            {
                IsThrowPrepared = true;
                _startMousePosition = _inputPosition.MouseYPoint;
            }
        }

        private void SetEndMousePosition()
        {
            if (Input.GetButtonUp("Fire1"))
            {
                IsThrowPrepared = false;
                _endMousePosition = _inputPosition.MouseYPoint;
                CalculateMouseMagnitude();
            }
        }

        private void CalculateMouseMagnitude()
        {
            MouseYDistance = _endMousePosition.y - _startMousePosition.y;
        }

        private void OnDisable()
        {
            BoostersService.PowerShotPressed.RemoveListener(BoosterUseReaction);
        }
    }
}