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

        private Transform _playerShuriken;
        private Vector3 _throwDirection;
        private IInputPosition _inputPosition;

        [Inject]
        public void Construct(IInputPosition inputPosition)
        {
            _inputPosition = inputPosition;
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
            _throwDirection = _inputPosition.MousePoint;
        }

        private void SurikenShot()
        {
            _rb.AddForce((_throwDirection - transform.position).normalized * _force);
        }

        private void SetStartRotation()
        {
            _playerShuriken = GameObject.FindGameObjectWithTag(Tags.PlayerShuriken).transform;
            transform.rotation = _playerShuriken.rotation;
        }
    }
}