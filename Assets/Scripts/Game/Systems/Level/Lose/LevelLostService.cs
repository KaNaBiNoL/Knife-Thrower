using System;
using UnityEngine;
using Zenject;

namespace KnifeThrower.Game
{
    public class LevelLostService : MonoBehaviour, ILevelLostService
    {
        private IRemainingTargetsService _remainingTargetsService;
        private IRemainingTargetsService _remainingTargetsService1;
        public bool IsGameEnd { get; set; }
        public bool IsGameLost { get; set; }

        [Inject]
        public void Construct(IRemainingTargetsService remainingTargetsService)
        {
            _remainingTargetsService1 = remainingTargetsService;
        }

         private void Start()
         {
             IsGameEnd = false;
             IsGameLost = false;
         }

      /*   private void Update()
         {
             if (_remainingTargetsService.RemainingTargets > 0)
             {
                 IsGameLost = true;
                 Debug.Log("Game Lost");
             }
         } */
    }
}