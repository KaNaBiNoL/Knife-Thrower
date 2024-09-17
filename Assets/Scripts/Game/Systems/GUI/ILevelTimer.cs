namespace KnifeThrower.Game
{
    public interface ILevelTimer
    {
        float Timer { get; set; }
        
        public void Init()
        {
        }

        void TimerTick();

        void BoosterTimeStop();
    }
}