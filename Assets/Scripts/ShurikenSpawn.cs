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
        private IGUIControl _guiControl;

        private MeshRenderer _playerMesh;

        public static UnityEvent OnShurikenThrowed = new UnityEvent();

        [Inject]
        private Shuriken.Factory _shurikenFactory;

        [Inject]
        private ThrowArea _throwArea;

        [Inject]
        public void Construct(IActiveShurikenController activeShurikenController,
            IRemainingShurikens remainingShurikens, IGUIControl guiControl)
        {
            _activeShurikenController = activeShurikenController;
            _remainingShurikens = remainingShurikens;
            _guiControl = guiControl;
        }

        private void Update()
        {
            if (_guiControl.IsGameOn)
            {
                if (_remainingShurikens.ShurikenCount <= 0)
                {
                    return;
                }

                if (_throwArea.IsThrowPrepared)
                {
                    SpawnToThrow();
                }

                return;
            }
        }

        private void SpawnToThrow()
        {
            if (Input.GetButtonUp("Fire1") && _activeShurikenController.PlayerMesh.enabled)
            {
                OnShurikenThrowed.Invoke();
                Shuriken shuriken = _shurikenFactory.Create();
                shuriken.transform.position = new Vector3(0, 2.87f, -9.57f);
            }
        }
    }
}