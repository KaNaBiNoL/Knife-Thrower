using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeThrower
{
    public class MillRotation : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 0.3f;
        
        

        
        void FixedUpdate()
        {
            DoRotation();
        }

        private void DoRotation()
        {
            gameObject.transform.Rotate(_rotationSpeed, 0, 0);
        }
    }
}
