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
        private int _randomMin = 2;
        private int _randomMax = 4;
        private int _shotGold;

        public void Init()
        {
            ShurikenCollision.OnShurikenCollideWithTarget.AddListener(GoldForShot);
        }

        private void GoldForShot()
        {
            _shotGold = Random.Range(_randomMin, _randomMax);
            GoldReward += _shotGold;
        }

        private void OnDestroy()
        {
            ShurikenCollision.OnShurikenCollideWithTarget.RemoveAllListeners();
        }
    }
}