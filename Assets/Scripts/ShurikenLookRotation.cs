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

        [Inject]
        public void Construct(IInputPosition inputPosition)
        {
            _inputPosition = inputPosition;
        }

        private void Update()
        {
            RotaionWithInput();
        }

        private void RotaionWithInput()
        {
            transform.LookAt(_inputPosition.MousePoint);
        }
    }
}