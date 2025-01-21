using System;
using System.Collections;
using System.Collections.Generic;
using KnifeThrower.Game;
using Unity.VisualScripting;
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
        private bool _isSpawnBoosterUsed = false;
        private Vector3 _startPosition = new Vector3(0, 2.87f, -9.57f);

        public static UnityEvent OnShurikenThrowed = new UnityEvent();

        [Inject]
        private Shuriken.Factory _shurikenFactory;
        
        [Inject]
        private ShurikenClone.FactoryClone _shurikenFactoryClone;

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

        private void OnEnable()
        {
            
        }

        public void Start()
        {
            BoostersService.MultiShurikenPressed.AddListener(SwitchToMultiShuriken);
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
                shuriken.transform.position = _startPosition;
                
                if (_isSpawnBoosterUsed == true)
                {
                    SpawnMultiShuriken();
                    _isSpawnBoosterUsed = false;
                }
            }

           
        }
        
        private void SwitchToMultiShuriken()
        {
            _isSpawnBoosterUsed = true;
        }

        private void SpawnMultiShuriken()
        {
            ShurikenClone shurikenLeft = _shurikenFactoryClone.Create();
            shurikenLeft.gameObject.tag = Tags.LeftShurikenClone;
            shurikenLeft.transform.position = _startPosition + Vector3.left;
            
            ShurikenClone shurikenRight = _shurikenFactoryClone.Create();
            shurikenRight.gameObject.tag = Tags.RightShurikenClone;
            shurikenRight.transform.position = _startPosition + Vector3.right;
            
            ShurikenClone shurikenUp = _shurikenFactoryClone.Create();
            shurikenUp.gameObject.tag = Tags.UpShurikenClone;
            shurikenUp.transform.position = _startPosition + Vector3.up;
            
            ShurikenClone shurikenDown = _shurikenFactoryClone.Create();
            shurikenDown.gameObject.tag = Tags.DownShurikenClone;
            shurikenDown.transform.position = _startPosition + Vector3.down;
        }
        
        private void OnDisable()
        { 
            BoostersService.MultiShurikenPressed.RemoveListener(SwitchToMultiShuriken);
        }
    }
}