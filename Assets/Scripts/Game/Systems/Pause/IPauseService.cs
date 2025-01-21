using System;

namespace KnifeThrower.Game
{
    public interface IPauseService
    {
        event Action<bool> OnChanged;
        bool IsPaused { get; }

        

        void TogglePause();
    }
}