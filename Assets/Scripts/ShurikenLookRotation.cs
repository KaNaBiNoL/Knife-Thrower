using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace KnifeThrower
{
    public class ShurikenLookRotation : MonoBehaviour
    {
        private IInputPosition _inputPosition;
        private IGUIControl _guiControl;

        [Inject]
        public void Construct(IInputPosition inputPosition, IGUIControl guiControl)
        {
            _inputPosition = inputPosition;
            _guiControl = guiControl;
        }

        private void Update()
        {
            if (_guiControl.IsGameOn)
            {
                RotaionWithInput();
            }
        }

        private void RotaionWithInput()
        {
            transform.LookAt(_inputPosition.MousePoint);
        }
    }
}