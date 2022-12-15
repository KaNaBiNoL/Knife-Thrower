using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KnifeThrower
{
    public class ShurikenCollision : MonoBehaviour
    {
        private Rigidbody _rb;

        public static UnityEvent OnShurikenCollide = new UnityEvent();

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(Tags.Target) || collision.gameObject.CompareTag(Tags.Environment))
            {
                OnShurikenCollide?.Invoke();
                Destroy(_rb);
                transform.parent = collision.transform;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.Border))
            {
                OnShurikenCollide?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
