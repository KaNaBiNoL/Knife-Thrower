using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace KnifeThrower.Game
{
    public class TargetCollision : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        private IRemainingTargetsService _remainingTargetsService;

        private bool _isTargetHit;

        [Inject]
        public void Construct(IRemainingTargetsService remainingTargetsService)
        {
            _remainingTargetsService = remainingTargetsService;
        }

        private void Start()
        {
            _isTargetHit = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_isTargetHit == false)
            {
                if (collision.gameObject.CompareTag(Tags.ShurikenWithForce) || 
                    collision.gameObject.CompareTag(Tags.LeftShurikenClone) ||
                    collision.gameObject.CompareTag(Tags.UpShurikenClone) ||
                    collision.gameObject.CompareTag(Tags.DownShurikenClone) ||
                    collision.gameObject.CompareTag(Tags.RightShurikenClone))
                {
                    _rb.isKinematic = false;
                    _remainingTargetsService.RemainingTargets--;
                    Debug.Log($"{_remainingTargetsService.RemainingTargets}");
                    _isTargetHit = true;
                    gameObject.tag = Tags.Environment;
                    Destroy(this);
                }
            }
        }
    }
}