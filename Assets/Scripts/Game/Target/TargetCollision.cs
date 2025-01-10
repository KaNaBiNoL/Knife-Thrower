using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace KnifeThrower.Game
{
    public class TargetCollision : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        private IRemainingTargetsService _remainingTargetsService;

        [NonSerialized] public bool IsTargetHit;

        [Inject]
        public void Construct(IRemainingTargetsService remainingTargetsService)
        {
            _remainingTargetsService = remainingTargetsService;
        }

        private void Start()
        {
            IsTargetHit = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (IsTargetHit == false)
            {
                if (collision.gameObject.CompareTag(Tags.ShurikenWithForce) || 
                    collision.gameObject.CompareTag(Tags.LeftShurikenClone) ||
                    collision.gameObject.CompareTag(Tags.UpShurikenClone) ||
                    collision.gameObject.CompareTag(Tags.DownShurikenClone) ||
                    collision.gameObject.CompareTag(Tags.RightShurikenClone))
                {
                    gameObject.transform.SetParent(null);
                    _rb.isKinematic = false;
                    _remainingTargetsService.RemainingTargets--;
                    Debug.Log($"{_remainingTargetsService.RemainingTargets}");
                    IsTargetHit = true;
                    gameObject.tag = Tags.Environment;
                    Destroy(this);
                }
            }
        }
    }
}