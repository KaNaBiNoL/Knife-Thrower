using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeThrower
{
    public class InputPosition : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;

        private Vector3 _mousePoint;

        public Vector3 MousePoint
        {
            get;
            private set;
        }

        void Update()
        {
            GetMouseCoordinates();
        }

        private void GetMouseCoordinates()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                MousePoint = raycastHit.point;
            }
        }
    }
}