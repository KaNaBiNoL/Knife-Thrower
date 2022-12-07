using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeThrower
{
    
    public class ShurikenSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _shuriken;
        [SerializeField] private Vector3 _spawnPoint;
        
        
        private void Update()
        {
            SpawnToThrow();
        }

        private void SpawnToThrow()
        {
            if (Input.GetButtonDown("Fire1"))
            {
               GameObject clone = Instantiate(_shuriken, _spawnPoint, Quaternion.identity);
            }
        }
    }
}
