using System;

namespace KnifeThrower.Services
{
    public abstract class ScreenController
    {
        protected abstract Type ScreenType { get; }

        public abstract void Show();
        public abstract void Hide();

        protected virtual void OnShowBegin()
        {
        }

        protected virtual void OnShowEnd()
        {
        }

        protected virtual void OnHideBegin()
        {
        }

        protected virtual void OnHideEnd()
        {
        }
    }

    public abstract class ScreenController<TScreen> : ScreenController where TScreen : BaseScreen
    {
        private IAssetService _assetService;
        protected TScreen Screen { get; private set; }

        protected sealed override Type ScreenType => typeof(TScreen);

        public ScreenController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        public sealed override void Show()
        {
            OnShowBegin();
            Screen.Show();
            OnShowEnd();
        }

        public sealed override void Hide()
        {
            OnHideBegin();
            Screen.Hide();
            OnHideEnd();
        }

        protected override void OnShowBegin()
        {
            if (Screen == null)
            {
                CreateScreen();
            }
            base.OnShowBegin();
        }

        private void CreateScreen()
        {
            TScreen prefab = _assetService.Load<TScreen>(ScreenPath());
            Screen = UnityEngine.Object.Instantiate(prefab);
        }

        private string ScreenPath()
        {
            return $"Screen/{ScreenType.Name}";
        }
    }
}