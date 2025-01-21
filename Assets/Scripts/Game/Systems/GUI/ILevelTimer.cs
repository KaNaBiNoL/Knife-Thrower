namespace KnifeThrower.Game
{
    public interface ILevelTimer
    {
        float Timer { get; set; }
        
        

        void TimerTick();

        void BoosterTimeStop();
    }
}