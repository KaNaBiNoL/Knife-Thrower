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
        private IInputPosition _inputPosition;

        public bool IsThrowPrepared { get; private set; }

        [Inject]
        public void Construct(IInputPosition inputPosition)
        {
            _inputPosition = inputPosition;
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

        private void SetStartMousePosition()
        {
            if (_isOnStartPosition && Input.GetButtonDown("Fire1"))
            {
                IsThrowPrepared = true;
                _startMousePosition = _inputPosition.MousePoint;
                Debug.Log($"StartPosSet {_startMousePosition}");
            }
        }

        private void SetEndMousePosition()
        {
            if (Input.GetButtonUp("Fire1"))
            {
                IsThrowPrepared = false;
                _endMousePosition = _inputPosition.MousePoint;
                CalculateMouseMagnitude();
                Debug.Log($"EndPosSet {_endMousePosition}");
            }
        }

        private void CalculateMouseMagnitude()
        {
            MouseYDistance = _endMousePosition.y - _startMousePosition.y;
            Debug.Log($"Distance = {MouseYDistance}");
        }
    }
}