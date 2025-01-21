using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace KnifeThrower
{
    public class MovingScoreForShot : MonoBehaviour
    {
        [SerializeField] private RectTransform _rt;
        [SerializeField] private TextMeshProUGUI _scoreText;

        [SerializeField] private ShurikenCollision _shurikenCollision;
        [SerializeField] private float _duration = 2f;
        [SerializeField] private Ease _ease;

        private Vector3 _offset = new Vector3(0, 1.2f, 0);

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (_shurikenCollision._isScoreCanShow)
            {
                Play();
                _shurikenCollision._isScoreCanShow = false;
            }
        }

        void Play()
        {
            _rt.DOAnchorPosY(1f, _duration);
            _scoreText.DOFade(0, _duration + 1f).SetEase(_ease);
        }
    }
}