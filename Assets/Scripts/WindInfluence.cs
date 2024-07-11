using System;
using UnityEngine;

namespace KnifeThrower
{
    public class WindInfluence : MonoBehaviour
    {
        [SerializeField] private ShurikenCollision _shurikenCollision;
        [SerializeField] private Rigidbody _rb;
        private WindController _windController;

        private bool _isInfluenceEnable = true;
        private float _speed;

        private void Start()
        {
            ShurikenCollision.OnShurikenCollide.AddListener(StopInfluence);
            _windController = FindObjectOfType<WindController>();
            if (_windController.IsWindActive)
            {
                if (_windController.IsWindStartsOnLeftSide)
                {
                    SetMoveRight();
                }

                else
                {
                    SetMoveLeft();
                }
            }
        }

        private void FixedUpdate()
        {
            if (_isInfluenceEnable)
            {
                _rb.velocity += new Vector3(_speed, 0, 0);
            }
        }

        private void StopInfluence()
        {
            _isInfluenceEnable = false;
        }

        private void SetMoveRight()
        {
            _speed = WindController.WindSpeed * 0.02f;
        }

        private void SetMoveLeft()
        {
            _speed = WindController.WindSpeed * -0.02f;
        }
    }
}