using System;

namespace KnifeThrower.Game
{
    public interface IRemainingTargetsService
    {
        int RemainingTargets { get; set; }
         bool IsGameWon { get; }
        event Action<bool> OnWin;

        
    }
}