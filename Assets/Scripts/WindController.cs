using System;
using System.Collections;
using DG.Tweening;
using TMPro;
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
        [SerializeField] private GameObject _windDirectionImage;
        [SerializeField] private TextMeshProUGUI _windSpeedText;
        private float _boosterTime = 10f;
        private Vector3 _rightRotation = new Vector3(0, 0, 180f);

        public static float WindSpeed { get; set; }

        private ParticleSystem windParticleSystem;
        private WindZone _windZone;

        private void OnEnable()
        {
            BoostersService.WindStopPressed.AddListener(OffWind);
        }

        private void Awake()
        {
            windParticleSystem = windParticlesGameObject.GetComponent<ParticleSystem>();
            _windZone = windZoneGameObject.GetComponent<WindZone>();
            WindSpeed = _windZone.windMain;
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
            SetDirectionImage();
            SetWindSpeedText();
        }

        private void SetWindSpeedText()
        {
            if (IsWindActive)
            {
                _windSpeedText.text = $"{WindSpeed} m/s";
            }

            else
            {
                _windSpeedText.text = "0 m/s";
            }
            
        }

        private void SetDirectionImage()
        {
            _windDirectionImage.SetActive(IsWindActive);
            if (IsWindStartsOnLeftSide)
            {
                _windDirectionImage.transform.DORotate(Vector3.zero, 0.01f, RotateMode.Fast);
            }
            else
            {
                _windDirectionImage.transform.DORotate(_rightRotation, 0.01f, RotateMode.Fast);
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
            
            for (int i = 10; i > 0; i--)
        {
            _boosterTime--;
            if (_boosterTime == 0)
            {
                IsWindActive = true;
                windParticlesGameObject.SetActive(true);
                SetWind();
                StopCoroutine(Booster());
                _boosterTime = 10f;
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