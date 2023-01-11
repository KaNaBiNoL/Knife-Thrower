using System;
using DG.Tweening;
using UnityEngine;

namespace KnifeThrower.Game
{
    public class MovingPanel : MonoBehaviour
    {
        [SerializeField] private Transform _fromTransform;
        [SerializeField] private Transform _toTransform;
        [SerializeField] private float  _duration = 3f;
        [SerializeField] private float  _delay = 1f;
        [SerializeField] private Ease _ease;
        

        private Tween _tween;

        private void Start()
        {
            Play();
        }

        private void Play()
        {
            _tween?.Kill();

            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOMove(_toTransform.position, _duration)
                .ChangeStartValue(_fromTransform.position).SetEase(_ease));
            sequence.AppendInterval(_delay);
            sequence.Append(transform.DOMove(_fromTransform.position, _duration)
                .ChangeStartValue(_toTransform.position).SetEase(_ease));
            sequence.AppendInterval(_delay);
            sequence.SetLoops(-1);
            sequence.SetUpdate(UpdateType.Fixed);

            _tween = sequence;




        }
    }
}