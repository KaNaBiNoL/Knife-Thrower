using System;
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

        public static float WindSpeed { get; set; }

        private ParticleSystem windParticleSystem;
        private WindZone windZone;

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
    }
}