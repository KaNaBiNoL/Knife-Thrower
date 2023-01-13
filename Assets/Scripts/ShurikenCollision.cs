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
        public static UnityEvent OnLastShurikenCollide = new UnityEvent();
        
        private IRemainingShurikens _remainingShurikens;
        private ILevelLostService _levelLostService;

        [Inject]
        public void Construct(IScoreService scoreService, IRemainingShurikens remainingShurikens, 
            ILevelLostService levelLostService)
        {
            _levelLostService = levelLostService;
            _remainingShurikens = remainingShurikens;
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
                if (_remainingShurikens.IsLastShurikenWillBeThrowed)
                {
                    OnLastShurikenCollide?.Invoke();
                }

                OnShurikenCollide?.Invoke();
                AllowRotation = false;
                Destroy(_rb);
                transform.parent = collision.transform; 
                Destroy(this);
                

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
