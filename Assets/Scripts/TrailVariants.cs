using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace KnifeThrower
{
    public class TrailVariants : MonoBehaviour
    {
        [SerializeField] private TrailRenderer _trailComponent;
        [SerializeField] private MeshFilter _meshComponent;
        [SerializeField] private GameObject _lightning;
        
        
        [SerializeField] private Material[] _TrailMaterials;
        [SerializeField] private Mesh[] _ShurikenMeshes;

        private int _currentShurikenVariant;
        private int _currentTrailVariant;
        private bool _isPowerShotUsed;

        private void OnEnable()
        {
            
        }

        

        private void Awake()
        {
            _currentShurikenVariant = YandexGame.savesData.ShopNumberOfSetShuriken;
            _currentTrailVariant = YandexGame.savesData.ShopNumberOfSetTrail;
        }

        private void Start()
        {
            SetCurrentMeshAndMaterial();
            SwitchTrailByPowerShot();
        }

        private void SetCurrentMeshAndMaterial()
        {
            switch (_currentTrailVariant)
            {
                case 0:
                    _trailComponent.material = _TrailMaterials[0];
                    break;
                
                case 1:
                    _trailComponent.material = _TrailMaterials[1];
                    break;
                case 2:
                    _trailComponent.material = _TrailMaterials[2];
                    break;
                case 3:
                    _trailComponent.material = _TrailMaterials[3];
                    break;
                case 4:
                    _trailComponent.material = _TrailMaterials[4];
                    break;
            }

            switch (_currentShurikenVariant)
            {
                case 0:
                    _meshComponent.mesh = _ShurikenMeshes[0];
                    break;
                
                case 1:
                    _meshComponent.mesh = _ShurikenMeshes[1];
                    break;
                case 2:
                    _meshComponent.mesh = _ShurikenMeshes[2];
                    break;
                case 3:
                    _meshComponent.mesh = _ShurikenMeshes[3];
                    break;
                case 4:
                    _meshComponent.mesh = _ShurikenMeshes[4];
                    break;
            }
        }
        
        

        private void SwitchTrailByPowerShot()
        {
            if (BoostersService.IsPowerShotPressed)
            {
                _trailComponent.enabled = false;
                _lightning.SetActive(true);
            }
            
        }

        private void OnDisable()
        {
           
        }
    }
}
