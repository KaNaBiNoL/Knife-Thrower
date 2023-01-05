using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeThrower
{
    public class InputPosition : MonoBehaviour, IInputPosition
    {
        private Camera _mainCamera;

        private Vector3 _mousePoint;

        public Vector3 MousePoint
        {
            get;
            private set;
        }

        public void Init()
        {
            _mainCamera = Camera.main;
        }

        void Update()
        {
            GetMouseCoordinates();
        }

        private void GetMouseCoordinates()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit,15f, 
                    LayerMask.GetMask("MouseInput")))
            {
                MousePoint = raycastHit.point;
            }
        }
    }
}