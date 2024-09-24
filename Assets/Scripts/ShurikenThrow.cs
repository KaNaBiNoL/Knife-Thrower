using System;
using UnityEngine;
using Zenject;

namespace KnifeThrower
{
    public class ShurikenThrow : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private float _force;
        [SerializeField] private float _rotationAngle;

        [SerializeField] private ShurikenCollision _shurikenCollision;
        [SerializeField] private WindInfluence _wind;

        private Transform _playerShuriken;
        private Vector3 _throwDirection;
        private Vector3 _throwForce;
        private IInputPosition _inputPosition;
        private IGUIControl _guiControl;
        [Inject]
        private ThrowArea _throwArea;

        [Inject]
        public void Construct(IInputPosition inputPosition, IGUIControl guiControl)
        {
            _inputPosition = inputPosition;
            _guiControl = guiControl;
        }

        void Start()
        {
            SetStartRotation();
            SetThrowDirection();
            SurikenShot();
        }

        private void Update()
        {
            if (_shurikenCollision.AllowRotation)
            {
                transform.Rotate(Vector3.up, _rotationAngle, Space.Self);
            }
        }

        private void SetThrowDirection()
        {
            switch (gameObject.tag)
            {
                case Tags.ShurikenWithForce:
                    _throwDirection = _inputPosition.MousePoint;
                    break;
                case Tags.LeftShurikenClone:
                    _throwDirection = _inputPosition.ClonesMousePoint0;
                    break;
                case Tags.RightShurikenClone:
                    _throwDirection = _inputPosition.ClonesMousePoint1;
                    break;
                case Tags.UpShurikenClone:
                    _throwDirection = _inputPosition.ClonesMousePoint2;
                    break;
                case Tags.DownShurikenClone:
                    _throwDirection = _inputPosition.ClonesMousePoint3;
                    break;
            }
        }

        private void SurikenShot()
        {
            if (_guiControl.IsGameOn)
            {
                if (_inputPosition.IsPowerShotUsed)
                {
                    _throwForce = (_throwDirection - transform.position).normalized *
                        (_force * 10);
                    _rb.useGravity = false;
                    _wind.enabled = false;
                    _inputPosition.IsPowerShotUsed = false;
                }
                else
                {
                    _throwForce = (_throwDirection - transform.position).normalized *
                        (_force * _throwArea.MouseYDistance);
                    if (_throwForce.z > 1500)
                    {
                        _throwForce.z = 1500;
                    }
                }

                _rb.AddForce(_throwForce);
            }
        }

        private void SetStartRotation()
        {
            _playerShuriken = GameObject.FindGameObjectWithTag(Tags.PlayerShuriken).transform;
            transform.rotation = _playerShuriken.rotation;
        }
    }
}