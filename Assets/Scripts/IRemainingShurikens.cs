using System;

namespace KnifeThrower
{
    public interface IRemainingShurikens
    {
        public int ShurikenCount { get; }
        event Action OnLastShurikenSet;

        public void Init()
        {
        }

        private void DecreaseCount()
        {
        }

        private void GameEventsEnd()
        {
        }
    }
}