using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeThrower
{
    public class GUIControl :  MonoBehaviour, IGUIControl
    {
        public bool IsGamePaused { get; set; }
        public bool IsGameOn { get; set; }
        public bool IsGameWinOrLost{ get; set; }

        public void Init()
        {
            IsGameOn = true;
            IsGamePaused = false;
            IsGameWinOrLost = false;
        }
    }
}
