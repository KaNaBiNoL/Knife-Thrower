using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KnifeThrower
{
    public class ShurikenSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _shuriken;
        [SerializeField] private Vector3 _spawnPoint;

        [SerializeField] private RemainingShurikens _remainingShurikens;
        

        public static UnityEvent OnShurikenThrowed = new UnityEvent();

        private void Update()
        {
            if (_remainingShurikens.ShurikenCount <= 0)
            {
                return;
            }
            SpawnToThrow();
        }

        private void SpawnToThrow()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                OnShurikenThrowed.Invoke();
                GameObject clone = Instantiate(_shuriken, _spawnPoint, Quaternion.identity);
            }
        }
    }
}