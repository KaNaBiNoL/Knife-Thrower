using System;
using System.Collections;
using System.Collections.Generic;
using KnifeThrower.Game;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace KnifeThrower
{
    public class ShurikenCollision : MonoBehaviour
    {
        private Rigidbody _rb;
        private IScoreService _scoreService;

        public bool AllowRotation { get; private set; }

        public static UnityEvent OnShurikenCollide = new UnityEvent();

        [Inject]
        public void Construct(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            AllowRotation = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(Tags.Target) || collision.gameObject.CompareTag(Tags.Environment))
            {
                OnShurikenCollide?.Invoke();
                AllowRotation = false;
                Destroy(_rb);
                transform.parent = collision.transform;
                
            }

            if (collision.gameObject.CompareTag(Tags.Target))
            {
                _scoreService.IncrementScore(1000,1);
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
