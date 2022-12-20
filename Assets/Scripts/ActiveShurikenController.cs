using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeThrower
{
    public class ActiveShurikenController : MonoBehaviour, IActiveShurikenController
    {
        private GameObject _playerShuriken;
        public MeshRenderer PlayerMesh { get; private set; }

        public void Init()
        {
            Debug.Log("Work");
            _playerShuriken = GameObject.FindGameObjectWithTag(Tags.PlayerShuriken);
            PlayerMesh = _playerShuriken.GetComponent<MeshRenderer>();
            ShurikenSpawn.OnShurikenThrowed.AddListener(ThrowImpossible);
            ShurikenCollision.OnShurikenCollide.AddListener(ThrowPossible);
        }

        private void ThrowImpossible()
        {
            PlayerMesh.enabled = false;
        }

        private void ThrowPossible()
        {
            PlayerMesh.enabled = true;
        }
    }
}