using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeThrower
{
    public class InputPosition : MonoBehaviour, IInputPosition
    {
        private Camera _mainCamera;
        private bool _isMultiBoosterPressed = false;

        public bool IsPowerShotUsed
        {
            get;
            set;
        }

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

        public Vector3 ClonesMousePoint0
        {
            get; set;
        }
        public Vector3 ClonesMousePoint1
        {
            get; set;
        }
        public Vector3 ClonesMousePoint2
        {
            get; set;
        }
        public Vector3 ClonesMousePoint3
        {
            get; set;
        }
        
        

        public void Start()
        {
            BoostersService.MultiShurikenPressed.AddListener(AllowToGetClonesCoordinates);
            BoostersService.PowerShotPressed.AddListener(AllowBoosterPowerShot);
            _mainCamera = Camera.main;
            IsPowerShotUsed = false; 
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

            if (_isMultiBoosterPressed)
            {
                ClonesMousePoint0 = MousePoint + Vector3.left;
                ClonesMousePoint1 = MousePoint + Vector3.right;
                ClonesMousePoint2 = MousePoint + Vector3.up;
                ClonesMousePoint3 = MousePoint + Vector3.down;
            }
        }
        
        private void AllowToGetClonesCoordinates()
        {
            _isMultiBoosterPressed = true;
        }
        
        private void AllowBoosterPowerShot()
        {
            IsPowerShotUsed = true;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_mainCamera.transform.position, MousePoint);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_mainCamera.transform.position, MouseYPoint);
        }

        private void OnDisable()
        {
            BoostersService.MultiShurikenPressed.RemoveListener(AllowToGetClonesCoordinates);
            BoostersService.PowerShotPressed.RemoveListener(AllowBoosterPowerShot); 
        }
    }
}