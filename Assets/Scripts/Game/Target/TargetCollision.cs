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

        [Inject]
        public void Construct(IRemainingTargetsService remainingTargetsService)
        {
            _remainingTargetsService = remainingTargetsService;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(Tags.ShurikenWithForce))
            {
                _rb.isKinematic = false;
                _remainingTargetsService.RemainingTargets--;
                Debug.Log($"{_remainingTargetsService.RemainingTargets}");
                Destroy(this);
            }
        }
    }
}