using System;
using UnityEngine;

namespace KnifeThrower
{
    public class ShurikenThrow : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private float _force;
        
        private Transform _playerShuriken;
        private Vector3 _throwDirection;

        void Start()
        {
            SetStartRotation();
            SetThrowDirection();
            SurikenShot();
        }

        private void Update()
        {
            
        }

        private void SetThrowDirection()
        {
            InputPosition inputPosition = (InputPosition)FindObjectOfType(typeof(InputPosition));
            _throwDirection = inputPosition.MousePoint;
        }

        private void SurikenShot()
        {
            _rb.AddForce((_throwDirection - transform.position).normalized * _force);
        }

        private void SetStartRotation()
        {
            _playerShuriken = GameObject.FindGameObjectWithTag(Tags.PlayerShuriken).transform;
        }
    }
}