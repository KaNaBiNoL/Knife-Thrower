using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace KnifeThrower.Game.Systems.GUI
{
    public class ScoreTextOnTarget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _shotScoreText;

        private int _scoreForTarget;
        private Vector3 _yOffset = new Vector3(0, 0.2f, 0);
        private IScoreService _scoreService;

        [Inject]
        public void Construct(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        void Start()
        {
            ShurikenCollision.OnShurikenCollideWithTarget.AddListener(CreateScoreVisible);
            _shotScoreText.text = "";
        }

        void Update()
        {
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("PlayerShuriken"))
            {
                
            }
        }

        void CreateScoreVisible()
        {
        }
    }
}