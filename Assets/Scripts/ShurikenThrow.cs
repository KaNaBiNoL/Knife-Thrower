using UnityEngine;

namespace KnifeThrower
{
    public class ShurikenThrow : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private float _force;

        private Vector3 _throwDirection;

        void Start()
        {
            SetThrowDirection();
            SurikenShot();
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
    }
}