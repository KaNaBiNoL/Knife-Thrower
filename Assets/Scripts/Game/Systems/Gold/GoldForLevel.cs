using System.Collections;
using System.Collections.Generic;
using KnifeThrower.Game;
using UnityEngine;
using Zenject;

namespace KnifeThrower
{
    public class GoldForLevel : MonoBehaviour, IGoldForLevel
    {
        public int GoldReward { get; set; }
        private int _randomMin = 4;
        private int _randomMax = 7;
        private int _shotGold;

        public void Start()
        {
            ShurikenCollision.OnShurikenCollideWithTarget.AddListener(GoldForShot);
        }

        private void GoldForShot()
        {
            _shotGold = Random.Range(_randomMin, _randomMax);
            GoldReward += _shotGold;
        }

        private void OnDisable()
        {
            ShurikenCollision.OnShurikenCollideWithTarget.RemoveListener(GoldForShot);
        }
    }
}