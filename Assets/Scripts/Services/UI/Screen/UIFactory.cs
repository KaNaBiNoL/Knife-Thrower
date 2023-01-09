using Zenject;

namespace KnifeThrower.Services
{
    public class UIFactory
    {
        private readonly IInstantiator _instantiator;

        public UIFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        public T Create<T>() where T : ScreenController =>
        _instantiator.Instantiate<T>();
        
    }
}