using System;
using System.Collections;
using UnityEngine;

namespace KnifeThrower.Game
{
    public class RemainingTargetsService : MonoBehaviour, IRemainingTargetsService
    {
        public int RemainingTargets { get; set; }
        public bool IsGameWon { get; private set; }
        private bool _isWinMessageCanBeSend;
        public event Action<bool> OnWin;

        private GameObject[] _allTargets;

        private void Awake()
        {
            IsGameWon = false;
            _isWinMessageCanBeSend = true;
        }

        public void Start()
        {
            _allTargets = GameObject.FindGameObjectsWithTag(Tags.Target);
            RemainingTargets = _allTargets.Length;
        }

        private void Update()
        {
            if (RemainingTargets <= 0 && _isWinMessageCanBeSend)
            {
                SendWinMessage();
                _isWinMessageCanBeSend = false;
            }
        }

        private void SendWinMessage()
        {
            StartCoroutine(WinCoroutine());
            
        }

        IEnumerator WinCoroutine()
        {

            for (int i = 2; i > 0; i--)
            {

                if (i == 1)
                {
                    IsGameWon = true;
                    OnWin?.Invoke(IsGameWon);
                    StopCoroutine(WinCoroutine());

                }

                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}