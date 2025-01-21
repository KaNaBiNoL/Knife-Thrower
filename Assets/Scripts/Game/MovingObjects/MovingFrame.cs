using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace KnifeThrower
{
    public class MovingFrame : MonoBehaviour
    {
        [SerializeField] private Transform _downPoint;
        [SerializeField] private Transform _upPoint;
        [SerializeField] private float _durationToUp;
        [SerializeField] private float _durationToDown;
        [SerializeField] private float _startDelay;
        [SerializeField] private float _midDelay;
        [SerializeField] private Ease _ease;
        

        private Tween _tween;

        void Start()
        {
            _tween?.Kill();
            Sequence sequence = DOTween.Sequence();

            sequence
                .AppendInterval(_startDelay)
                .Append(transform.DOMove(_downPoint.position, _durationToDown, false))
                .AppendInterval(_midDelay)
                .Append(transform.DOMove(_upPoint.position, _durationToUp))
                .SetLoops(-1)
                .SetEase(_ease)
                .SetUpdate(UpdateType.Fixed);
            _tween = sequence;
        }
    }
}