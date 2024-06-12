using System;
using UnityEngine;

namespace KnifeThrower.Infrastructure
{
    public abstract class BaseLauncher : MonoBehaviour
    {
        public bool IsReady { get; protected set; }
        private void Start()
        {
            Launch();
        }

        protected abstract void Launch();
    }
}