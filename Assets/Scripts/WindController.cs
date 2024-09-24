using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace KnifeThrower
{
    public class WindController : MonoBehaviour
    {
        [SerializeField] private GameObject windZoneGameObject;
        [SerializeField] private GameObject windParticlesGameObject;
        [SerializeField] public bool IsWindActive;
        [SerializeField] public bool IsWindStartsOnLeftSide;
        [SerializeField] private Transform _leftWindTargetTransform;
        [SerializeField] private Transform _rightWindTargetTransform;
        [SerializeField] private Transform _leftParticleTargetTransform;
        [SerializeField] private Transform _rightParticleTargetTransform;
        private int _boosterTime = 10;

        public static float WindSpeed { get; set; }

        private ParticleSystem windParticleSystem;
        private WindZone windZone;

        private void OnEnable()
        {
            BoostersService.WindStopPressed.AddListener(OffWind);
        }

        private void Awake()
        {
            windParticleSystem = windParticlesGameObject.GetComponent<ParticleSystem>();
            windZone = windZoneGameObject.GetComponent<WindZone>();
            WindSpeed = windZone.windMain;
        }

        private void Start()
        {
            SetWind();
        }

        private void SetWind()
        {
            if (IsWindActive)
            {
                SetWindSide();
            }

            else
            {
                windParticlesGameObject.SetActive(false);
            }
        }

        private void OffWind()
        {
            IsWindActive = false;
            StartCoroutine(Booster());
            SetWind();
        }

        IEnumerator Booster()
        {
            
            for (int i = 10; i >= 0; i--)
        {
            _boosterTime--;
            if (_boosterTime == 0)
            {
                IsWindActive = true;
                SetWind();
                StopCoroutine(Booster());
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private void SetWindSide()
    {
        if (IsWindStartsOnLeftSide)
        {
            windZoneGameObject.transform.position = _leftWindTargetTransform.position;
            windParticlesGameObject.transform.position = _leftParticleTargetTransform.position;
            windZoneGameObject.transform.rotation = _leftWindTargetTransform.rotation;
            windParticlesGameObject.transform.rotation = _leftParticleTargetTransform.rotation;
        }

        else
        {
            windZoneGameObject.transform.position = _rightWindTargetTransform.position;
            windParticlesGameObject.transform.position = _rightParticleTargetTransform.position;
            windZoneGameObject.transform.rotation = _rightWindTargetTransform.rotation;
            windParticlesGameObject.transform.rotation = _rightParticleTargetTransform.rotation;
        }
        
        
    }

    private void OnDisable()
    {
        BoostersService.WindStopPressed.RemoveListener(OffWind);
    }
    }

}