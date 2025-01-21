using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace KnifeThrower.Game
{
    public class LevelLostService : MonoBehaviour, ILevelLostService
    {
        private IRemainingTargetsService _remainingTargetsService;
        public bool IsGameEnd { get; set; }
        public bool IsGameLost { get; set; }

        [Inject]
        public void Construct(IRemainingTargetsService remainingTargetsService)
        {
            _remainingTargetsService = remainingTargetsService;
        }

        public void Start()
        {
            ShurikenCollision.OnLastShurikenCollide.AddListener(EndGame);
            IsGameEnd = false;
            IsGameLost = false;
        }

        private void Update()
        {
            if (IsGameEnd && _remainingTargetsService.RemainingTargets > 0)
            {
                IsGameLost = true;
            }
        }

        private void EndGame()
        {
            IsGameEnd = true;
        }

        private void OnDisable()
        {
            ShurikenCollision.OnLastShurikenCollide.RemoveListener(EndGame);
        }
    }
}