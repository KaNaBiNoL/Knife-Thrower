using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace KnifeThrower
{
    public class MeshVariantsOfPlayer : MonoBehaviour
    {
        
        [SerializeField] private MeshFilter _meshComponent;
        
        
        [SerializeField] private Mesh[] _ShurikenMeshes;

        private int _currentShurikenVariant;
        

        private void OnEnable()
        {
            
        }

        private void Awake()
        {
            _currentShurikenVariant = YandexGame.savesData.ShopNumberOfSetShuriken;
        }

        private void Start()
        {
            SetCurrentMesh();
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
            }
        }
    }
}