using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeThrower
{
    public class ShurikenLookRotation : MonoBehaviour
    {
        [SerializeField] private InputPosition _inputPosition;

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