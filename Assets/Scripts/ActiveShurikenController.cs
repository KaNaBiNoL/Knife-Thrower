using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeThrower
{
    public class ActiveShurikenController : MonoBehaviour, IActiveShurikenController
    {
        public GameObject PlayerShuriken;
        public MeshRenderer PlayerMesh { get; private set; }

        public void Init()
        {
            PlayerShuriken = GameObject.FindGameObjectWithTag(Tags.PlayerShuriken);
            PlayerMesh = PlayerShuriken.GetComponent<MeshRenderer>();
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

        private void OnDisable()
        {
            ShurikenSpawn.OnShurikenThrowed.RemoveListener(ThrowImpossible);
            ShurikenCollision.OnShurikenCollide.RemoveListener(ThrowPossible);
        }
    }
}