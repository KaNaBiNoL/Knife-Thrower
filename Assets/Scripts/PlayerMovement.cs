using System;
using UnityEngine;

namespace KnifeThrower
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _speed;

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            Vector3 moveVector = transform.right * horizontal + transform.forward * vertical;
            moveVector *= _speed;

            _controller.Move(moveVector * Time.deltaTime);
        }
    }
}