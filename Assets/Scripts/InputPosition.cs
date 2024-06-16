using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeThrower
{
    public class InputPosition : MonoBehaviour, IInputPosition
    {
        private Camera _mainCamera;

        public Vector3 MousePoint
        {
            get;
            private set;
        }
        public Vector3 MouseYPoint
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
            GetMouseYCoordinates();
        }

        private void GetMouseYCoordinates()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 15f,
                    LayerMask.GetMask("MouseInput")))
            {
                MouseYPoint = raycastHit.point;
            }
        }

        private void GetMouseCoordinates()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 40f,
                    LayerMask.GetMask("MouseOnLevel")))
            {
                MousePoint = raycastHit.point;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_mainCamera.transform.position, MousePoint);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_mainCamera.transform.position, MouseYPoint);
        }
    }
}