using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using KnifeThrower.Game;
using UnityEngine;

namespace KnifeThrower
{
    public class RoundingPillar : MonoBehaviour
    {
        [SerializeField] private TargetCollision _target1;
        [SerializeField] private TargetCollision _target2;
        [SerializeField] private bool _isFirstTargetOnTheLeftSide;
        [SerializeField] private bool _isSecondTargetOnTheSameSide;
        

        private bool _isRotationByFirstHitPossible = true;
        private bool _isRotationBySecondHitPossible = true;

        private Vector3 _rotationVector = new Vector3(0f, 180f, 0f);
        
        void Start()
        {
            if (!_isFirstTargetOnTheLeftSide)
            {
                _rotationVector = new Vector3(0f, -180f, 0f);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (_target1.IsTargetHit && _isRotationByFirstHitPossible)
            {
                DoRotation();
                _isRotationByFirstHitPossible = false;
                if (_isFirstTargetOnTheLeftSide && _isSecondTargetOnTheSameSide)
                {
                    _rotationVector = new Vector3(0f, -360f, 0f);
                }
                else if (!_isFirstTargetOnTheLeftSide && _isSecondTargetOnTheSameSide)
                {
                    _rotationVector = new Vector3(0f, 360f, 0f);
                }
            }
            
            if (_target2.IsTargetHit && _isRotationBySecondHitPossible)
            {
                DoRotation();
                _isRotationBySecondHitPossible = false;
            }
            
        }

        private void DoRotation()
        {
            transform.DOLocalRotate(_rotationVector, 0.5f, RotateMode.Fast);
            _rotationVector = new Vector3(0f, 360f, 0f);
            if (!_isFirstTargetOnTheLeftSide)
            {
                _rotationVector = new Vector3(0f, -360f, 0f);
            }
        }
    }
}
