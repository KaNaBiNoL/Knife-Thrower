using System;
using UnityEngine;

namespace KnifeThrower.Game
{
    public class RemainingTargetsService: MonoBehaviour, IRemainingTargetsService
    {
        public int RemainingTargets { get; set; }
        public bool IsGameWon { get; private set; }
        public event Action<bool> OnWin;

        private GameObject[] _allTargets;

        private void Awake()
        {
            IsGameWon = false;
        }

        public void Init()
        {
            _allTargets = GameObject.FindGameObjectsWithTag(Tags.Target);
            RemainingTargets = _allTargets.Length;
        }

        private void Update()
        {
            if (RemainingTargets <= 0)
            {
                SendWinMessage();
            }

            else
            {
                Debug.Log($"{RemainingTargets}");
            }
        }

        private void SendWinMessage()
        {
            IsGameWon = true;
            OnWin?.Invoke(IsGameWon);
        }
    }
}