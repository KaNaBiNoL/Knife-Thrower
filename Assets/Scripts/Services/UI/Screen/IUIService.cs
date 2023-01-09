namespace KnifeThrower.Services.Screen
{
    public interface IUIService
    {
        T GetController<T>() where T : ScreenController;
        
        void ShowScreen<T>() where T : ScreenController;
        void HideScreen<T>() where T : ScreenController;

        
    }
}