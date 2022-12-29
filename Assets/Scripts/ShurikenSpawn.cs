using System.Collections;
using System.Collections.Generic;
using KnifeThrower.Game;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace KnifeThrower
{
    public class ShurikenSpawn : MonoBehaviour, IShurikenSpawn
    {
        private IRemainingShurikens _remainingShurikens;
        private IActiveShurikenController _activeShurikenController;

        private GameObject _playershuriken;
        private MeshRenderer _playerMesh;

        public static UnityEvent OnShurikenThrowed = new UnityEvent();

        [Inject]
        private Shuriken.Factory _shurikenFactory;

        [Inject]
        public void Construct(IActiveShurikenController activeShurikenController,
            IRemainingShurikens remainingShurikens)
        {
            _activeShurikenController = activeShurikenController;
            _remainingShurikens = remainingShurikens;
        }

        public void Init()
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
                Shuriken shuriken = _shurikenFactory.Create();
                shuriken.transform.position = new Vector3(0, 2.87f, -9.57f);
            }
        }
    }
}