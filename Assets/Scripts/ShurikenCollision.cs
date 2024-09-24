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
                Destroy(this);
            }
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
    }
}