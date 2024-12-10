using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using YG;

namespace KnifeThrower
{
    public class MeshVariantsOfPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject _LightningEffect;
        [SerializeField] private MeshRenderer _playerMesh;
        
        
        [SerializeField] private MeshFilter _meshComponent;
        
        
        [SerializeField] private Mesh[] _ShurikenMeshes;

        private int _currentShurikenVariant;
        

        private void OnEnable()
        {
            BoostersService.PowerShotPressed.AddListener(SetLightningActive);
            ShurikenCollision.OnShurikenCollide.AddListener(OffLightning);
        }

        

        private void Awake()
        {
            _currentShurikenVariant = YandexGame.savesData.ShopNumberOfSetShuriken;
        }

        private void Start()
        {
            SetCurrentMesh();
            _LightningEffect.SetActive(false);
        }

        private void SetCurrentMesh()
        {
            

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
        
        private void SetLightningActive()
        {
            StartCoroutine(LightningCoroutine());
        }
        
        private void OffLightning()
        {
            StartCoroutine(LightningOffCoroutine());
        }
        
        IEnumerator LightningOffCoroutine()
        {
            while (_playerMesh.enabled)
            {
                yield return new WaitForSeconds(1f);
            }
            _LightningEffect.SetActive(false);
            StopCoroutine(LightningOffCoroutine());
            yield return null;
        }

        IEnumerator LightningCoroutine()
        {
            while (_playerMesh.enabled == false)
            {
                yield return new WaitForSeconds(1f);
            }
            _LightningEffect.SetActive(true);
            StopCoroutine(LightningCoroutine());
            yield return null;
        }

        
    }
}
