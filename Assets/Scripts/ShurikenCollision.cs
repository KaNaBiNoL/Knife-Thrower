using System;
using System.Collections;
using System.Collections.Generic;
using KnifeThrower.Game;
using ModestTree;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace KnifeThrower
{
    public class ShurikenCollision : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _shotScoreText;
        [SerializeField] private GameObject _canvasHolder;
        [SerializeField] private GameObject _shotEffect;
        [SerializeField] private AudioSource _hitSound;
        [SerializeField] private AudioSource _targetHitSound;
        [SerializeField] private GameObject _trailHolder;

        private Transform _scoreTransform;

        private Rigidbody _rb;
        public bool _isScoreCanShow = false;

        public bool AllowRotation { get; private set; }

        public static UnityEvent OnShurikenCollide = new UnityEvent();
        public static UnityEvent OnShurikenCollideWithTarget = new UnityEvent();
        public static UnityEvent OnShurikenCollideNotWithTarget = new UnityEvent();
        public static UnityEvent OnLastShurikenCollide = new UnityEvent();

        private IRemainingShurikens _remainingShurikens;
        private ILevelLostService _levelLostService;
        private IScoreService _scoreService;

        [Inject]
        public void Construct(IScoreService scoreService, IRemainingShurikens remainingShurikens,
            ILevelLostService levelLostService)
        {
            _levelLostService = levelLostService;
            _remainingShurikens = remainingShurikens;
            _scoreService = scoreService;
        }

        private void Start()
        {
            _shotScoreText.text = "";
            _rb = GetComponent<Rigidbody>();
            AllowRotation = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            AllowToAppear(_shotEffect.transform);
            _shotEffect.transform.SetParent(null);
            _shotEffect.SetActive(true);
            if (collision.gameObject.CompareTag(Tags.Target))
            {
                _targetHitSound.Play();
                OnShurikenCollideWithTarget.Invoke();
                AllowToAppear(_shotScoreText.transform);
                _shotScoreText.text = _scoreService.ScoreForShot.ToString();
                _canvasHolder.transform.SetParent(null);
                _isScoreCanShow = true;
            }
            else
            {
                if (gameObject.CompareTag("ShurikenWithForce"))
                {
                    OnShurikenCollideNotWithTarget.Invoke();
                }
            }

            if (collision.gameObject.CompareTag(Tags.Target) || collision.gameObject.CompareTag(Tags.Environment))
            {
                _hitSound.Play();
                if (_remainingShurikens.IsLastShurikenWillBeThrowed)
                {
                    OnLastShurikenCollide?.Invoke();
                }

                OnShurikenCollide?.Invoke();
                AllowRotation = false;
                Destroy(_rb);
                transform.parent = collision.transform;
            }
            

            StartCoroutine(TrailOff());
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.Border))
            {
                OnShurikenCollide?.Invoke();
                if (gameObject.CompareTag("ShurikenWithForce"))
                {
                    OnShurikenCollideNotWithTarget.Invoke();
                }

                Destroy(gameObject);
            }
        }

        private void AllowToAppear(Transform trans)
        {
            trans.LookAt(Camera.main.transform.position);
            trans.Rotate(0, 180.0f, 0);
        }

        IEnumerator TrailOff()
        {
            for (int i = 0; i < 2; i++)
            {
                if (i == 1)
                {
                    _trailHolder.SetActive(false);
                    Destroy(this);
                    StopCoroutine(TrailOff());
                }

                yield return new WaitForSeconds(0.5f);
            }
        }

        
    }
}