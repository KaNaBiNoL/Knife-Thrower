using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KnifeThrower
{
    public class RemainingShurikens : MonoBehaviour, IRemainingShurikens
    {
        private GameObject[] _shurikenList;
        public int ShurikenCount { get; private set; }
        public event Action OnLastShurikenSet;

        private int _index = 0;

        public void Init()
        {
            _shurikenList = GameObject.FindGameObjectsWithTag(Tags.ShurikenModel);
            ShurikenCount = _shurikenList.Length + 1; // +1 is a player started shuriken
            ShurikenSpawn.OnShurikenThrowed.AddListener(DecreaseCount);
        }

        private void DecreaseCount()
        {
            if (_shurikenList.Length > _index)
            {
                Destroy(_shurikenList[_index]);
            }

            _index++;
            ShurikenCount--;

            if (ShurikenCount <= 0)
            {
                OnLastShurikenSet?.Invoke();
                GameEventsEnd();
            }
        }

        private void GameEventsEnd()
        {
            ShurikenSpawn.OnShurikenThrowed.RemoveAllListeners();
            ShurikenCollision.OnShurikenCollide.RemoveAllListeners();
        }
    }
}