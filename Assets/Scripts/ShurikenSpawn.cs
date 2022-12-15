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
        [SerializeField] private RemainingShurikens _remainingShurikens;
        [SerializeField] private ActiveShurikenController _activeShurikenController;
        

        private GameObject _playershuriken;
        private MeshRenderer _playerMesh;
        
        public static UnityEvent OnShurikenThrowed = new UnityEvent();

        private void Start()
        {
            _playershuriken = GameObject.FindGameObjectWithTag(Tags.PlayerShuriken);
        }

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
            if (Input.GetButtonDown("Fire1") && _activeShurikenController.PlayerMesh.enabled)
            {
                OnShurikenThrowed.Invoke();
                GameObject clone = Instantiate(_shuriken, _playershuriken.transform.position, Quaternion.identity);
            }
        }
    }
}