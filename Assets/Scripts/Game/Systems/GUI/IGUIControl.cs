namespace KnifeThrower
{
    public interface IGUIControl
    {
        public bool IsGamePaused { get; set; }
        public bool IsGameOn { get; set; }
        public bool IsGameWinOrLost{ get; set; }

        public void Init(){}
    }
}