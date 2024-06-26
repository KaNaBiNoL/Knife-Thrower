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
            if (collision.gameObject.CompareTag(Tags.Target))
            {
                OnShurikenCollideWithTarget.Invoke();
                _shotScoreText.transform.LookAt(Camera.main.transform.position);
                _shotScoreText.transform.Rotate(0, 180.0f, 0);
                _shotScoreText.text = _scoreService.ScoreForShot.ToString();
                _canvasHolder.transform.SetParent(null);
                _isScoreCanShow = true;
            }
            else
            {
                OnShurikenCollideNotWithTarget.Invoke();
            }

            if (collision.gameObject.CompareTag(Tags.Target) || collision.gameObject.CompareTag(Tags.Environment))
            {
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
                OnShurikenCollideNotWithTarget.Invoke();
                Destroy(gameObject);
            }
        }
    }
}