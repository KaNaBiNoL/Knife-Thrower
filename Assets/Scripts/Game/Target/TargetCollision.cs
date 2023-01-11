using System;
using Unity.VisualScripting;
using UnityEngine;

namespace KnifeThrower.Game
{
    public class TargetCollision : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        private float _force = 20f;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(Tags.ShurikenWithForce))
            {
                gameObject.transform.SetParent(null);
                _rb.AddForce(Vector3.down * _force);
            }
        }
    }
}