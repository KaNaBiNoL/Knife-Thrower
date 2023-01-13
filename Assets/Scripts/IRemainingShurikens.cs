using System;

namespace KnifeThrower
{
    public interface IRemainingShurikens
    {
        public int ShurikenCount { get; }
        bool IsLastShurikenWillBeThrowed { get; }

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