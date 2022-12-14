using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeThrower
{
    public class ShurikenLookRotation : MonoBehaviour
    {
        [SerializeField] private InputPosition _inputPosition;
        
        private Vector3 previousMousePosition;

        private void Start()
        {
            transform.Rotate(0,0,90);
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