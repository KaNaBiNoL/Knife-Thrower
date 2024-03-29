﻿using System;
using UnityEngine;
using UnityEngine.WSA;

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